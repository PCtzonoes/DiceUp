using System;
using System.Collections.Generic;
using UnityEngine;

namespace Helper
{
    public abstract class AGenericEventListener<T> : ScriptableObject
    {
        private readonly HashSet<Action<T>> _actionEventHashSet = new HashSet<Action<T>>();

        public void Subscribe(Action<T> action)
        {
            _actionEventHashSet.Add(action);
        }

        public void Unsubscribe(Action<T> action)
        {
            _actionEventHashSet.Remove(action);
        }

        /// <summary>
        /// Call all the actions in the HashSet, assumes the actions are not null.
        /// </summary>
        public void InvokeActions(T value)
        {
            if (_actionEventHashSet.Count == 0)
            {
                Debug.LogWarning("No actions subscribed to this event", this);
                return;
            }

            foreach (var action in _actionEventHashSet)
            {
                action.Invoke(value);
            }
        }
    }
}