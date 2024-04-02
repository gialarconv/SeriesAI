using System;
using JetBrains.Annotations;
using TMPro;

namespace SeriesAI.Game
{
    [Serializable]
    public class LevelCanvasElements
    {
        public TextMeshProUGUI gemCountText;
        [CanBeNull] public SignElements signElements;
    }
}