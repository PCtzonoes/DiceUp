using UnityEngine;
using UnityEngine.Events;

namespace Helper
{
    public class GameEventListener : MonoBehaviour, IGameEventCaller
    {
        [SerializeField] protected GameEvent gameEvent;
        [SerializeField] protected UnityEvent unityEvent;

        private void OnEnable()
        {
            OnEnableGameEvent();
        }

        private void OnDisable()
        {
            OnDisableGameEvent();
        }

        public virtual void RaiseEvent()
        {
            unityEvent.Invoke();
        }

        protected virtual void OnEnableGameEvent()
        {
            gameEvent.Register(this);
        }

        protected virtual void OnDisableGameEvent()
        {
            gameEvent.Remove(this);
        }
    }
}