using System.Collections.Generic;
using UnityEngine;

namespace Helper
{
    [CreateAssetMenu(menuName = "GameEvent/Default")]
    public class GameEvent : ScriptableObject
    {
        private readonly HashSet<IGameEventCaller> _eventCallers = new();

        public void Invoke()
        {
            foreach (var eventListener in _eventCallers) eventListener.RaiseEvent();
        }

        public void Register(IGameEventCaller gameEventListener)
        {
            _eventCallers.Add(gameEventListener);
        }

        public void Remove(IGameEventCaller gameEventListener)
        {
            _eventCallers.Remove(gameEventListener);
        }
    }
}