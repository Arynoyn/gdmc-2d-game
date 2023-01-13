using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CoinAudio : MonoBehaviour
{
    private AudioSource _audioSource;
    private void Awake() { _audioSource = GetComponent<AudioSource>(); }

    void Start()
    {
        GameManager.Instance.OnCoinsChanged += PlayCoinDingAudio;
    }

    private void OnDestroy() { GameManager.Instance.OnCoinsChanged -= PlayCoinDingAudio; }
    private void PlayCoinDingAudio(int coins) { _audioSource.Play(); }
}
