
using System;

namespace Common
{
    public interface IValueChangedEventHandler
    {
        void AddOnValueChangedCallback(Action<int> action);

        void RemoveOnValueChangedCallbacks();
    }
}