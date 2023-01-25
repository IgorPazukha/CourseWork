using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _shootPosition;
    [SerializeField] protected Bullet Bullet;

    private AudioSource _audioSource;
    public Transform ShootPosition => _shootPosition;
    public AudioSource AudioSource => _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public abstract void Shoot();
}