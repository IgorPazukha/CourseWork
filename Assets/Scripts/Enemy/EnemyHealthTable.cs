using UnityEngine;

public class EnemyHealthTable : MonoBehaviour
{
    [SerializeField] private float _destroyTime;
    [SerializeField] private Vector3 _offset;

    private void Start()
    {
        Destroy(gameObject, _destroyTime);
        transform.localPosition += _offset;
    }
}