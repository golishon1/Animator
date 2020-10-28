using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChangeColor : StateMachineBehaviour
{

    public static event Action OnEnter;
    public static event Action OnExit;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnEnter?.Invoke();
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnExit?.Invoke();
    }

    
}
