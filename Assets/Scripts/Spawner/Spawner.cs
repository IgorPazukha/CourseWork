using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Collider _collider;

    private List<SpawnerPoint> _spawnObject;
    private List<Enemy> _enemys;
    private bool _isSpawned;
    private bool _isDie;
    private bool _isWork = true;

    public bool IsWork => _isWork;

    private void Awake()
    {
        var spawnPointArray = transform.parent.GetComponentsInChildren<SpawnerPoint>();
        _spawnObject = new List<SpawnerPoint>(spawnPointArray);
        _enemys = new List<Enemy>();
    }

    private void Update()
    {
        Debug.Log(_enemys.Count);

        if (_isSpawned == false || _enemys.Count == 0)
            return;

        _isDie = true;

        foreach(var enemy in _enemys)
        {
            if(enemy.IsDie == false)
            {
                _isDie = false;
                break;
            }    
        }

        if(_isDie == true)
        {
            _isWork = false;
            _enemys.Clear();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            SpawnCharacters();
        }   
    }

    private void SpawnCharacters()
    {
        if (_isSpawned)
            return;

        _isSpawned = true;

        foreach (var point in _spawnObject)
        {
            if (point.EnemyToSpawn != null)
            {
                GameObject spawnedGameObject = Instantiate(point.EnemyToSpawn, point.transform.position, Quaternion.identity);
                _enemys.Add(spawnedGameObject.GetComponent<Enemy>());
            }     
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, _collider.bounds.size);
    }
}