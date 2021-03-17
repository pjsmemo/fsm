using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJS.StateMachine
{
    /// <summary>
    /// 딱히 쓸일은 없을 것 같은데...
    /// 개념 잡기 위해서 만들어 보았다..
    /// </summary>
    public abstract class State<T> : MonoBehaviour where T : System.Enum
    {
        public abstract T state { get; }
        protected StateMachine<T> _stateMachine;

        public virtual void Initlize (StateMachine <T> stateMacine)
        {
            _stateMachine = stateMacine;
            _stateMachine?.AddState(state, this);
        }

        protected virtual void OnDestroy ()
        {
            _stateMachine?.RevState(state);
        }
    }
}