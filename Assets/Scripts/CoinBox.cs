﻿using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Animator))]
public class CoinBox : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _enabledSprite;
    [SerializeField] private SpriteRenderer _disabledSprite;
    [SerializeField] private int _maxNumberOfCoins = 2;
    private int _coinsRemaining;
    private Animator _animator;

    private void Awake()
    {
        _coinsRemaining = _maxNumberOfCoins;
        _enabledSprite.enabled = true;
        _disabledSprite.enabled = false;
        _animator = GetComponentInChildren<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (_coinsRemaining > 0
            && col.WasPlayer()
            && col.WasBottom())
        {
            GameManager.Instance.AddCoin();
            _coinsRemaining--;

            if (_animator != null) { _animator.SetTrigger("flipCoin"); }
            
            if (_coinsRemaining <= 0)
            {
                _enabledSprite.enabled = false;
                _disabledSprite.enabled = true;
            }
        }
    }
}
