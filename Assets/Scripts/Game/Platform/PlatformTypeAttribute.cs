using System;

namespace SeriesAI.Game
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public sealed class PlatformTypeAttribute : Attribute
    {
        public PlatformType Type { get; private set; }

        public PlatformTypeAttribute(PlatformType type)
        {
            Type = type;
        }
    }
}