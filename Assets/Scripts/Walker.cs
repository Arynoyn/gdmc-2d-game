using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Walker : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _maxDistance = 0.1f;
    [SerializeField] private int _layerMask;
    
    private Collider2D _collider2D;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _renderer;
    private Vector2 _direction = Vector2.left;


    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _direction * (_speed * Time.fixedDeltaTime));
    }

    private void LateUpdate()
    {
        if (ReachedEdge())
        {
            SwitchDirection();
        }
    }

    private bool ReachedEdge()
    {
        Bounds bounds = _collider2D.bounds;
        float x = _direction == Vector2.left
            ? bounds.min.x
            : bounds.max.x;
        float y = bounds.min.y;
        
        Vector2 colliderEdge = new Vector2(x, y);
        Debug.DrawRay(colliderEdge, Vector2.down * _maxDistance, Color.red);
        
        RaycastHit2D raycastHit = Physics2D.Raycast(colliderEdge, Vector2.down, _maxDistance);
        return raycastHit.collider == null;
    }

    private void SwitchDirection()
    {
        _direction *= -1;
        _renderer.flipX = !_renderer.flipX;
    }
}
