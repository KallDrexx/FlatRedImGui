using System;

namespace FlatRedImGui
{
    /// <summary>
    /// Denotes that the targeted property is has a text buffer backing it.  Used for string properties as we have
    /// to pass a byte array to ImGui for text inputs.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class HasTextBufferAttribute : Attribute
    {
        public int MaxLength { get; }

        public HasTextBufferAttribute(int maxLength)
        {
            MaxLength = maxLength;
        }
    }
}