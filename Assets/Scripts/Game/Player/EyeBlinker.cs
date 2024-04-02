using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace SeriesAI.Game
{
    public class EyeBlinker : MonoBehaviour
    {
        [SerializeField] private Transform[] eyesTransforms;
        [SerializeField] private float blinkDuration = 0.1f;

        private void Start()
        {
            StartCoroutine(BlinkRoutine());
        }

        private IEnumerator BlinkRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(2f, 5f));
                Blink();
            }
        }

        private void Blink()
        {
            foreach (var eyeTransform in eyesTransforms)
            {
                eyeTransform.DOScaleY(0.05f, blinkDuration).OnComplete(() => eyeTransform.DOScaleY(0.2f, blinkDuration));
            }
        }
    }
}