using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Player))]
public class PlayerState : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _gravity;
    [SerializeField] private float _rotationAngle;
    [SerializeField] private float _rollSpeed;
    [SerializeField] private float _gravityMultiply;

    private CharacterController _characterController;
    private Vector3 _movmentVelocity;
    private PlayerInput _playerInput;
    private float _verticalVelocity;
    private int _attackAnimation = Animator.StringToHash("Attack");
    private int _rollAnimation = Animator.StringToHash("Roll");
    private int _speedAnimator = Animator.StringToHash("Speed");
    private int _airBorneAnimator = Animator.StringToHash("AirBorne");
    private Animator _animator;
    private Player _player;
    private bool _isAttack;
    private bool _isLive = true;
    private AudioSource _audioSource;

    public bool IsAttack => _isAttack;
    public bool IsLive => _isLive;

    private enum CharacterState
    {
        Normal, Attacking, Die, Roll
    }

    private CharacterState _currentState;

    private void OnEnable()
    {
        _player.Dying += SwitchToDie;
    }

    private void OnDisable()
    {
        _player.Dying -= SwitchToDie;
    }

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _playerInput = GetComponent<PlayerInput>();
        _player = GetComponent<Player>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        switch (_currentState)
        {
            case CharacterState.Normal:
                CalculatePlayerMovment();
                break;
            case CharacterState.Attacking:
                break;
            case CharacterState.Die:
                break;
            case CharacterState.Roll:
                _movmentVelocity = transform.forward * _rollSpeed * Time.deltaTime;
                break;

        }

        if (_characterController.isGrounded == false)
            _verticalVelocity = _gravity;
        else
            _verticalVelocity = _gravity * _gravityMultiply;

        _movmentVelocity += _verticalVelocity * Vector3.up * Time.deltaTime;

        _characterController.Move(_movmentVelocity);
    }

    public void OutRoll()
    {
        SwitchStateTo(CharacterState.Normal);
    }

    public void OutAttack()
    {
        _isAttack = false;
    }

    public void InAttack()
    {
        _isAttack = true;
    }

    private void CalculatePlayerMovment()
    {
        if (_playerInput.MouseButtonDown && _characterController.isGrounded)
        {
            SwitchStateTo(CharacterState.Attacking);
            return;
        }
        else if (_playerInput.SpaceKeyDown && _characterController.isGrounded)
        {
            SwitchStateTo(CharacterState.Roll);
            return;
        }

        _movmentVelocity.Set(_playerInput.HorizontalInput, 0f, _playerInput.VerticalInput);
        _movmentVelocity.Normalize();
        _movmentVelocity = Quaternion.Euler(0, _rotationAngle, 0) * _movmentVelocity;

        _animator.SetFloat(_speedAnimator, _movmentVelocity.magnitude);
        _animator.SetBool(_airBorneAnimator, !_characterController.isGrounded);

        _movmentVelocity *= _moveSpeed * Time.deltaTime;

        if (_movmentVelocity != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(_movmentVelocity);

        PlayAudioStep();
    }

    private void SwitchStateTo(CharacterState newState)
    {
        _playerInput.ClearCache();

        switch (_currentState)
        {
            case CharacterState.Normal:
                break;
            case CharacterState.Attacking:
                break;
            case CharacterState.Die:
                break;
            case CharacterState.Roll:
                break;
        }

        switch (newState)
        {
            case CharacterState.Normal:
                _isAttack = false;
                break;
            case CharacterState.Attacking:
                _isAttack = true;
                _animator.SetTrigger(_attackAnimation);
                _player.CurrentWeapon.Shoot();

                newState = CharacterState.Normal;
                break;
            case CharacterState.Die:
                _isLive = false;
                break;
            case CharacterState.Roll:
                _animator.SetTrigger(_rollAnimation);
                break;
        }

        _currentState = newState;;
    }

    private void SwitchToDie()
    {
        SwitchStateTo(CharacterState.Die);
    }

    private void PlayAudioStep()
    {
        if(_playerInput.HorizontalInput == 0 && _playerInput.VerticalInput == 0)
            _audioSource.Play();
    }
}