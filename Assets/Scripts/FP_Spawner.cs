using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FP_Spawner : MonoBehaviour
{
    public GameObject _objectToSpawn;
    public float _spawnRate;
    float _lateSpawn;

    public void Spawn()
    {
        if(_objectToSpawn != null && _lateSpawn + _spawnRate < Time.time )
        {
            Instantiate(_objectToSpawn, transform.position, transform.rotation);
            _lateSpawn = Time.time;
        }
    }
}
