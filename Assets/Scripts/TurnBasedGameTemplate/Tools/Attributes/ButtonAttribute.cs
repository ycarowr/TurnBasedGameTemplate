using System;

namespace TurnBasedGameTemplate
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ButtonAttribute : Attribute
    {
        public ButtonAttribute(string label) => Label = label;

        public ButtonAttribute()
        {
        }

        public string Label { get; }
    }
}