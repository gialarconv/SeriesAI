using UnityEngine;

namespace SeriesAI.Game
{
    public class CharacterFlipper : MonoBehaviour
    {
        [SerializeField] private Transform characterTransform;
        
        private bool isFacingRight = true;

        public void FlipCharacter(float direction)
        {
            if (!isFacingRight && direction > 0f)
            {
                Flip();
            }
            else if (isFacingRight && direction < 0f)
            {
                Flip();
            }
        }

        private void Flip()
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = characterTransform.localScale;
            localScale.x *= -1f;
            characterTransform.localScale = localScale;
        }
    }
}