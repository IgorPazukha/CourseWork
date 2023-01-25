using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnerGroup : MonoBehaviour
{
    private Spawner[] _spawner;

    public event UnityAction HasDieAllEnemy;

    private void Awake()
    {
        _spawner = FindObjectsOfType<Spawner>();
    }

    private void Update()
    {
        Extande();
    }

    private void Extande()
    {
        foreach (var spawn in _spawner)
        {
            if(spawn.IsWork == true)
            {
                break;
            }
            else
            {
                HasDieAllEnemy?.Invoke();
            }
        }
    }
}