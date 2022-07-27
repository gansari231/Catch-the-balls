using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : SingletonGeneric<TimerManager>
{
    float _startTime = 15;
    public float _endTime;

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
        if(_endTime > 0 && UIManager.Instance.startGame)
        {
            _endTime -= Time.deltaTime;
            _timer.value = _endTime;
        }
        else if(Mathf.Abs(_timer.value) <= 0 && UIManager.Instance.startGame)
        {
            _timer.value = 1;           
            Debug.Log("In IF");
            InputHandler.Instance.AddDataToList(UIManager.Instance._score);
            UIManager.Instance.GameCompleteSequence();

        }
    }
}
