using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _life;
    [SerializeField] private float _speed;
    [SerializeField] private float _minRandom;
    [SerializeField] private float _maxRandom;

    private float RandomTime;
    private Rigidbody Rigidbody;

    public int Damage => _damage;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        RandomTime = Random.Range(_minRandom, _maxRandom);
        _life += RandomTime;
    }

    private void FixedUpdate()
    {
        Rigidbody.MovePosition(transform.position + transform.forward * _speed * Time.deltaTime);

        _life -= Time.deltaTime;

        if (_life <= 0)
            Destroy(gameObject);
    }
}