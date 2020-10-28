using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private MeshRenderer _object;
    [SerializeField] private Color _color;

    private Color _startColor;

    private void OnEnable()
    {
        MoveChangeColor.OnEnter += Enter;
        MoveChangeColor.OnExit += Exit;
    }

    private void OnDisable()
    {
        MoveChangeColor.OnEnter -= Enter;
        MoveChangeColor.OnExit -= Exit;
    }

    private void Enter()
    {
        _object.material.color = _color;
    }

    private void Exit()
    {
        _object.material.color = _startColor;
    }
    void Start()
    {
        _startColor = _object.material.color;
    }

  
}
