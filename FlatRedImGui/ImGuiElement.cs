using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FlatRedImGui
{
    /// <summary>
    /// Represents a set of UI controls that can be manipulated and rendered
    /// </summary>
    public abstract class ImGuiElement: INotifyPropertyChanged
    {
        private readonly Dictionary<string, object> _notifyPropertyChangedObjects = new Dictionary<string, object>();
        private bool _disablePropertyNotificationEvents;

        public event PropertyChangedEventHandler PropertyChanged;
        public bool IsVisible { get; set; }

        public void Render()
        {
            if (IsVisible)
            {
                CustomRender();
            }
        }
        
        /// <summary>
        /// Custom logic for each item for how the item should be rendered.  This will only be called if the element
        /// has `IsVisible` set to `true`.
        /// </summary>
        protected abstract void CustomRender();

        /// <summary>
        /// Temporarily disables property changed events from being dispatched until the returned IDisposable
        /// is disposed.
        /// </summary>
        /// <returns></returns>
        protected IDisposable DisablePropertyChangedNotifications()
        {
            return new EventNotificationDisabler(this);
        }

        protected T Get<T>([CallerMemberName] string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            return _notifyPropertyChangedObjects.TryGetValue(propertyName, out var value)
                ? (T) value
                : default;
        }

        protected void Set(object value, [CallerMemberName] string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            var hasExistingValue = _notifyPropertyChangedObjects.TryGetValue(propertyName, out var existingValue);
            if (hasExistingValue && existingValue == value)
            {
                return;
            }

            _notifyPropertyChangedObjects[propertyName] = value;

            if (!_disablePropertyNotificationEvents)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private class EventNotificationDisabler : IDisposable
        {
            private readonly ImGuiElement _element;

            public EventNotificationDisabler(ImGuiElement element)
            {
                _element = element;
                _element._disablePropertyNotificationEvents = true;
            }
            
            public void Dispose()
            {
                _element._disablePropertyNotificationEvents = false;
            }
        }
    }
}