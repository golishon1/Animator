using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomAnimBlend : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private readonly int _spring = Animator.StringToHash("Spring");
    private readonly int _color = Animator.StringToHash("Color");
    private readonly int _up = Animator.StringToHash("Up");
    private readonly int _right = Animator.StringToHash("Right");
    private readonly int _line = Animator.StringToHash("Line");



    public void BlendAnimation()
    {
        _animator.SetFloat(_spring, Random.Range(0,1f));
        _animator.SetFloat(_color, Random.Range(0,1f));
        _animator.SetFloat(_up, Random.Range(0,1f));
        _animator.SetFloat(_right, Random.Range(0,1f));
        _animator.SetFloat(_line, Random.Range(0,1f));
    }
}
