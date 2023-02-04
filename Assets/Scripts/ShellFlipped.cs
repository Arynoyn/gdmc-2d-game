using System;
using DefaultNamespace;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class ShellFlipped : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private Rigidbody2D _rigidbody2D;
    private Collider2D _collider2D;

    private Vector2 _direction;
    
    private void Start()
    {
        _collider2D = GetComponent<Collider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_direction.x * _speed, _rigidbody2D.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.WasPlayer())
        {
            HandlePlayerCollision(col);
        }
        else
        {
            if (col.WasSide())
            {
                LaunchShell(col);
                
                ITakeShellHit takeShellHit = col.collider.GetComponent<ITakeShellHit>();
                takeShellHit?.HandleShellHit(this);
            }
        }
    }

    private void HandlePlayerCollision(Collision2D col)
    {
        PlayerMovementController playerController = col.collider.GetComponent<PlayerMovementController>();
        if (_direction.magnitude == 0)
        {
            LaunchShell(col);
            if (col.WasTop())
            {
                playerController.Bounce();
            }
        }
        else
        {
            if (col.WasTop())
            {
                _direction = Vector2.zero;
                playerController.Bounce();
            }
            else
            {
                GameManager.Instance.KillPlayer();
            }
        }
    }

    private void LaunchShell(Collision2D col) { 
        float hitDirection = col.contacts[0].normal.x > 0 ? 1f : -1f;
        _direction = new Vector2(hitDirection, 0);
    }
}
