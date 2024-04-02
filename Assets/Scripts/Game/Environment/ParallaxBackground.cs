using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private Transform _mainCameraTransform;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Vector2 _parallaxEffectMultiplier;

    private Transform _cameraTransform;
    private Vector3 _lastCameraPosition;
    private float _textureUnitSizeX;

    private void Start()
    {
        _cameraTransform = _mainCameraTransform != null ? _mainCameraTransform : Camera.main.transform;
        _lastCameraPosition = _cameraTransform.position;
        
        if (_spriteRenderer == null)
            _spriteRenderer = GetComponent<SpriteRenderer>();
        
        var sprite = _spriteRenderer.sprite;
        var texture = sprite.texture;
        _textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }

    private void LateUpdate()
    {
        Vector3 deltaMovement = _cameraTransform.position - _lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * _parallaxEffectMultiplier.x, deltaMovement.y * _parallaxEffectMultiplier.y);
        _lastCameraPosition = _cameraTransform.position;


        if (!(Mathf.Abs(_cameraTransform.position.x - transform.position.x) >= _textureUnitSizeX)) 
            return;
        
        var offsetPositionX = (_cameraTransform.position.x - transform.position.x) % _textureUnitSizeX;
        transform.position = new Vector3(_cameraTransform.position.x + offsetPositionX, transform.position.y);
    }
}