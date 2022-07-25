using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : SingletonGeneric<SpawnManager>
{
    [SerializeField]
    GameObject[] _ballPrefabs;

    float _duration = 3.0f;
    float _spawnPosY = 5.0f;

    void Start()
    {
        InvokeRepeating("SpawnBall", 5.0f, _duration);
    }

    void SpawnBall()
    {     
        int _ballIndex = Random.Range(0, _ballPrefabs.Length);
        float _spawnPosX = Random.Range(2.0f, -2.0f);
        Instantiate(_ballPrefabs[_ballIndex], new Vector3(_spawnPosX, _spawnPosY, 0), Quaternion.identity);
    }
}
