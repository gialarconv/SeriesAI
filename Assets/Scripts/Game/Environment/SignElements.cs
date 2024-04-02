using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace SeriesAI.Game
{
    [Serializable]
    public class SignElements
    {
        public GameObject signPanel;
        public TextMeshProUGUI signText;
        public Button closeButton;
        public PlayerInput playerInput;
    }
}