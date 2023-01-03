using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private IMove _mover;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;


    private void Awake()
    {
        _mover = GetComponent<IMove>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    private void Update()
    {
        _animator.SetFloat("speed", Mathf.Abs(_mover.Speed));

        if (_mover.Speed != 0)
        {
            _spriteRenderer.flipX = _mover.Speed > 0;
        }
    }
}
