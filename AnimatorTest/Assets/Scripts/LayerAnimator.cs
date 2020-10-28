using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LayerAnimator : MonoBehaviour
{
    private readonly int _move = Animator.StringToHash("Move");
    private readonly int _aim = Animator.StringToHash("Aim");
    
    
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationClip _shoot2;
    [SerializeField] private AnimationClip _shoot1;
    private AnimatorOverrideController _animatorOverrideController;

    private void Start()
    {
        _animatorOverrideController = new AnimatorOverrideController(_animator.runtimeAnimatorController);
        _animator.runtimeAnimatorController = _animatorOverrideController;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _animator.SetTrigger(_move);
        }

        if (Input.GetMouseButtonDown(0))
        {
          
            _animator.SetTrigger(_aim);
            _animatorOverrideController["shoot2"] = _shoot1;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            _animatorOverrideController["shoot"] = _shoot2;
            _animator.SetTrigger(_aim);
        }
        else
        {
            _animator.ResetTrigger(_aim);
        }
    }
}
