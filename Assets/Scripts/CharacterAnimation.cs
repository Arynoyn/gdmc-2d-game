using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
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
        float speed = _mover.Speed;
        _animator.SetFloat("speed", Mathf.Abs(speed));

        if (speed != 0)
        {
            _spriteRenderer.flipX = speed > 0;
        }
    }
}
