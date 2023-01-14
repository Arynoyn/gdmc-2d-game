using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] private Transform Start;
    [SerializeField] private Transform End;
    [SerializeField] private Transform Sprite;
    [SerializeField, Range(0f,2f)] private float Speed = 1.0f;
    
    
    private float _positionPercentage = 0;
    private int _direction = 1;

    // Update is called once per frame
    void Update()
    {
        _positionPercentage += Time.deltaTime * _direction * Speed;
        Sprite.position = Vector3.Lerp(Start.position, End.position, _positionPercentage);

        if (_positionPercentage >= 1 && _direction == 1)
        {
            _direction = -1;
        }
        else if (_positionPercentage <= 0 && _direction == -1)
        {
            _direction = 1;
        }
    }

    
}
