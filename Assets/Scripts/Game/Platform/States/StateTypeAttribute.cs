using System;

namespace SeriesAI.Game
{
    [AttributeUsage(AttributeTargets.Class)]
    public class StateTypeAttribute : Attribute
    {
        public PlatformType Type { get; }

        public StateTypeAttribute(PlatformType type)
        {
            Type = type;
        }
    }

}