using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeriesAI.Utilities
{
    public abstract class SimpleSingleton<T> : MonoBehaviour where T : Component
    {
        private static T _instance;

        public static T Instance => _instance;

        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}