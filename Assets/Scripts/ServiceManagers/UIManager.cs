using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : SingletonGeneric<UIManager>
{
    [SerializeField]
    TextMeshProUGUI _scoreText;
    [SerializeField]
    TextMeshProUGUI _achievementName;
    [SerializeField]
    TextMeshProUGUI _achievementInfo;
    [SerializeField]
    CanvasRenderer _achievementPanel;

    int _score;

    void Start()
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

    public void BallsCollectedAchievementSystem(string AchievementName, string AchievmentInfo)
    {
        _achievementPanel.gameObject.SetActive(true);
        _achievementName.text = " " + AchievementName;
        _achievementInfo.text = " " + AchievmentInfo;
        StartCoroutine(AchievementSystem());
    }

    IEnumerator AchievementSystem()
    {
        yield return new WaitForSeconds(5.0f);
        _achievementPanel.gameObject.SetActive(false);
    }
}
