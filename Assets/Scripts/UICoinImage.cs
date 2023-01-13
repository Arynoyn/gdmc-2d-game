using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICoinImage : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        GameManager.Instance.OnCoinsChanged += Pulse;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnCoinsChanged -= Pulse;
    }

    private void Pulse(int coins)
    {
        _animator.SetTrigger("pulse");
    }
}
