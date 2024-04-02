using DG.Tweening;
using UnityEngine;

namespace SeriesAI.Game
{
    public class CollectibleItem : MonoBehaviour
    {
        [SerializeField] private float _shrinkDuration = 0.5f;
        [SerializeField] private float _floatDuration = 1f;
        [SerializeField] private float _floatDistance = 0.5f;

        private Vector3 initialPosition;
        private Tweener floatTween;

        private void Start()
        {
            initialPosition = transform.position;
            ItemLoopAnimation();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                CollectItem();
            }
        }

        private void ItemLoopAnimation()
        {
            floatTween = transform.DOMoveY(initialPosition.y + _floatDistance, _floatDuration)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.InOutSine);
        }

        private void CollectItem()
        {
            GameEventManager.ItemCollected();
            floatTween.Kill();
            GetComponent<PolygonCollider2D>().enabled = false;
            transform.DOScale(Vector3.zero, _shrinkDuration).OnComplete(() => gameObject.SetActive(false));
        }

        public void RestartItem()
        {
            GetComponent<PolygonCollider2D>().enabled = true;
            gameObject.SetActive(true);
            transform.localScale = Vector3.one;
            ItemLoopAnimation();
        }
    }
}