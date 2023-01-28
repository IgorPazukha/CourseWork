using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(AudioSource))]
public class EnemyState : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _gravity;
    [SerializeField] private float _rotationAngle;
    [SerializeField] private float _distanceWait;
    [SerializeField] private float _distanceRun;
    [SerializeField] private int _shootTime;
    [SerializeField] private GameObject[] _items;

    private Animator _animator;
    private NavMeshAgent _navMeshAgent;
    private Transform _targetPlayer;
    private Vector3 _startPosition;
    private Enemy _enemy;
    private AudioSource _audioSource;
    private int _minRandom = 0;
    private int _randomNumber;
    private int attackAnimation = Animator.StringToHash("Attack");
    private int _speedAnimator = Animator.StringToHash("Speed");
    private enum CharacterState
    {
        Move, Attacking, Idle, Die
    }

    private CharacterState _currentState;

    private void OnEnable()
    {
        _enemy.HasDye += ChangeDie;
    }

    private void OnDisable()
    {
        _enemy.HasDye -= ChangeDie;
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        _targetPlayer = FindObjectOfType<Player>().transform;
        _enemy = GetComponent<Enemy>();
        _audioSource = GetComponent<AudioSource>();
        _navMeshAgent.speed = _moveSpeed;
    }

    private void Start()
    {
        _startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        switch (_currentState)
        {
            case CharacterState.Move:
                CalculateEnemyMovment();
                break;
            case CharacterState.Attacking:
                RotateToTarget();
                break;
            case CharacterState.Idle:
                Wait();
                break;
            case CharacterState.Die:
                break;
        }
    }

    public void OutAttack()
    {
        StartCoroutine(ChangeValue());
        SwitchStateTo(CharacterState.Move);
    }

    private void CalculateEnemyMovment()
    {
        if (Vector3.Distance(_targetPlayer.position, transform.position) >= _distanceWait)
            SwitchStateTo(CharacterState.Idle);

        if (Vector3.Distance(_targetPlayer.position, transform.position) >= _navMeshAgent.stoppingDistance)
        {
            _navMeshAgent.SetDestination(_targetPlayer.position);
            _animator.SetFloat(_speedAnimator, 0.2f);
            _audioSource.Play();
        }
        else
        {
            _navMeshAgent.SetDestination(transform.position);
            _animator.SetFloat(_speedAnimator, 0f);
            _audioSource.Stop();

            SwitchStateTo(CharacterState.Attacking);
        }
    }

    private void Wait()
    {
        if (Vector3.Distance(_targetPlayer.position, transform.position) < _distanceWait)
            SwitchStateTo(CharacterState.Move);

        if (Vector3.Distance(transform.position, _startPosition) > _distanceRun)
        {
            _navMeshAgent.SetDestination(_startPosition);
            _animator.SetFloat(_speedAnimator, 0.2f);
        }
        else
        {
            _navMeshAgent.SetDestination(transform.position);
            _animator.SetFloat(_speedAnimator, 0f);
        }
    }

    private void SwitchStateTo(CharacterState newState)
    {
        switch (_currentState)
        {
            case CharacterState.Move:
                break;
            case CharacterState.Attacking:
                break;
            case CharacterState.Idle:
                break;
            case CharacterState.Die:
                break;
        }

        switch (newState)
        {
            case CharacterState.Move:
                break;
            case CharacterState.Attacking:
                Quaternion newRotation = Quaternion.LookRotation(_targetPlayer.position - transform.position);
                transform.rotation = newRotation;
                _animator.SetTrigger(attackAnimation);
                break;
            case CharacterState.Idle:
                break;
            case CharacterState.Die:
                _randomNumber = Random.Range(_minRandom, _items.Length);
                Instantiate(_items[_randomNumber], transform.position, _items[_randomNumber].transform.rotation);
                break;
        }

        _currentState = newState;
    }

    private IEnumerator ChangeValue()
    {
        int wait = 10;
        while (wait > 0)
        {
            if(wait == _shootTime)
                _enemy.CurrentWeapon.Shoot();

            wait--;
            yield return null;
        }
    }

    private void RotateToTarget()
    {
        transform.LookAt(_targetPlayer, Vector3.up);
    }

    private void ChangeDie()
    {
        SwitchStateTo(CharacterState.Die);
    }
}