using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private IMove _playerMovementController;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;


    private void Awake()
    {
        _playerMovementController = GetComponent<IMove>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    private void Update()
    {
        _animator.SetFloat("speed", Mathf.Abs(_playerMovementController.Speed));

        if (_playerMovementController.Speed != 0)
        {
            _spriteRenderer.flipX = _playerMovementController.Speed > 0;
        }
    }
}
