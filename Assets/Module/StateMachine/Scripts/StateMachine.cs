using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PJS.StateMachine
{
    /// <summary>
    /// 딱히 쓸일은 없을 것 같은데...
    /// 개념 잡기 위해서 만들어 보았다..
    /// 만들고 써본적이 없다...
    /// </summary>
    public class StateMachine<T> : MonoBehaviour where T : System.Enum
    {
        private Dictionary<T, State<T>> mStateDic;
        public State<T> currentState;

        public void AddState (T state, State<T> stateObject)
        {
            if (mStateDic == null)
            {
                mStateDic = new Dictionary<T, State<T>>();
            }

            if (mStateDic.ContainsKey(state))
            {
                mStateDic[state] = stateObject;
            }
            else
            {
                mStateDic.Add(state, stateObject);
            }
        }

        public void SetState(T state)
        {
            currentState = mStateDic[state];
        }

        public void RevState (T state)
        {
            if (mStateDic == null) { return; }

            if (mStateDic.ContainsKey(state))
            {
                mStateDic.Remove(state);
            }
        }
    }
}