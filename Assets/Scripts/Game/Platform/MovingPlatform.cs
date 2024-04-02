using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace SeriesAI.Game
{
    public class MovingPlatform : MonoBehaviour
    {
        [SerializeField] private Vector2 _offsetStart;
        [SerializeField] private Vector2 _offsetEnd;
        [SerializeField] private float _moveDuration = 2.0f;
        [SerializeField] private Ease _easeType = Ease.Linear;

        private Vector2 _startPoint;
        private Vector2 _endPoint;
        private Tween _tween;

        private void Start()
        {
            Vector2 initialPosition = transform.position;
            _startPoint = initialPosition + _offsetStart;
            _endPoint = initialPosition + _offsetEnd;

            transform.position = _startPoint;
            MoveToEnd();
        }

        private void MoveToEnd()
        {
            _tween = transform.DOMove(_endPoint, _moveDuration).SetEase(_easeType).OnComplete(MoveToStart);
        }

        private void MoveToStart()
        {
            _tween = transform.DOMove(_startPoint, _moveDuration).SetEase(_easeType).OnComplete(MoveToEnd);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.transform.parent = transform;
            }
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.transform.parent = null;
            }
        }

        private void OnDrawGizmos()
        {
            Vector2 gizmoStart = (Vector2)transform.position + _offsetStart;
            Vector2 gizmoEnd = (Vector2)transform.position + _offsetEnd;

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(gizmoStart, 0.25f);
            Gizmos.DrawSphere(gizmoEnd, 0.25f);

            Gizmos.DrawLine(gizmoStart, gizmoEnd);
        }
    }
}