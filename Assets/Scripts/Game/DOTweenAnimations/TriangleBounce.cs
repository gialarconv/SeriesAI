using System.Collections;
using System.Collections.Generic;
using SeriesAI.Helpers;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace SeriesAI.Animations
{
    public class TriangleBounce : MonoBehaviour
    {
        [SerializeField] private Transform[] _triangles;
        [SerializeField] private float _bounceAmount = 1.2f;
        [SerializeField] private float _bounceDuration = 0.5f;
        [SerializeField] private float _delayBetweenBounces = 0.1f;

        private Sequence _currentSequence;
        
        private void Start()
        {
            UpdateAnimation();
        }
        [ContextMenu(nameof(UpdateAnimation))]
        private void UpdateAnimation()
        {
            if (_currentSequence != null)
            {
                _currentSequence.Kill();
            }

            _currentSequence = CreateBounceSequence();
            _currentSequence.SetLoops(-1);
        }

        private Sequence CreateBounceSequence()
        {
            Sequence sequence = DOTween.Sequence();

            foreach (Transform triangle in _triangles)
            {
                sequence.Append(triangle.DOScale(_bounceAmount, _bounceDuration / 2).SetEase(Ease.OutQuad));
                sequence.Append(triangle.DOScale(1, _bounceDuration / 2).SetEase(Ease.InQuad));
                sequence.AppendInterval(_delayBetweenBounces);
            }

            return sequence;
        }
    }
}