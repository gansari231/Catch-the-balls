using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : SingletonGeneric<SpawnManager>
{
    [SerializeField]
    GameObject[] _ballPrefabs;

    float _duration = 1.5f;
    float _spawnPosY = 5.0f;

    public void StartGame()
    {
        InvokeRepeating("SpawnBall", 1.5f, _duration);
    }

    void SpawnBall()
    {
        if(TimerManager.Instance._endTime > 0 && UIManager.Instance.startGame)
        {
            int _ballIndex = Random.Range(0, _ballPrefabs.Length);
            float _spawnPosX = Random.Range(1.5f, -1.5f);
            Instantiate(_ballPrefabs[_ballIndex], new Vector3(_spawnPosX, _spawnPosY, 0), Quaternion.identity);           
        }    
    }
}
