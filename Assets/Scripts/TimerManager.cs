using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    float _startTime = 30;
    float _endTime;

    [SerializeField]
    Slider _timer;

    void Start()
    {
        _endTime = _startTime;
        _timer.maxValue = _startTime;
        _timer.value = _endTime;
    }

    void Update()
    {
        if(_endTime > 0)
        {
            Debug.Log("in UP");
            _endTime -= Time.deltaTime;
            _timer.value = _endTime;
        }
    }
}
