using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : SingletonGeneric<UIManager>
{
    [SerializeField]
    TextMeshProUGUI _scoreText;
    int _score;

    private void Start()
    {
        _score = 0;
    }

    public void UpdateScore(GameObject Ball)
    {
        if(Ball.CompareTag("BadBall"))
        {
            _score -= 10;        
        }
        else
        {
            _score += 10;
        }
        _scoreText.text = "Score : " + _score;
    }
}
