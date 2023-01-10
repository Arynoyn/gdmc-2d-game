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
        GameManager.Instance.OnCoinsChanged += _ => _audioSource.Play();
    }
}
