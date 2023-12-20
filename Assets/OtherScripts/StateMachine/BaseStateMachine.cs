using System;
using UnityEngine;

namespace StateMachine
{
    public abstract class BaseStateMachine : MonoBehaviour 
    {
        public Action OnChangeState;
        protected BaseState currentState;

        public virtual void SwitchState<T>(T state) where T : BaseState
        {
            if (currentState != null)
            {
                currentState.OnExit();
            }

            currentState = state;
            currentState.OnEnter();
            OnChangeState?.Invoke();
        }

        protected virtual void Update()
        {
            if (currentState != null)
            {
                currentState.OnUpdate();
            }
        }
    }
}
