using System;
using UnityEngine;

namespace StateMachine
{
    public class BaseStateMachine : MonoBehaviour 
    {
        public Action OnChangeState;
        protected BaseState currentState;

        public void SwitchState(BaseState state)
        {
            if (currentState != null)
            {
                currentState.OnExit();
            }

            currentState = state;
            currentState.OnEnter();
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
