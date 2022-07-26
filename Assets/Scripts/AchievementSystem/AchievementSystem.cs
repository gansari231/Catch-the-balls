using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementSystem : SingletonGeneric<AchievementSystem>
{
    [SerializeField]
    AchievementHolder achievementSOList;
    int currentBallsCollectedAchivementLevel;

    void Start()
    {
        currentBallsCollectedAchivementLevel = 0;
    }

    public void BallsCollectedCountCheck(int ballCount)
    {
        for (int i = 0; i < achievementSOList.ballsCollectedAchievementSO.Achievements.Length; i++)
        {
            if (achievementSOList.ballsCollectedAchievementSO.Achievements[i].requirement == ballCount)
            {
                UIManager.Instance.BallsCollectedAchievementSystem(achievementSOList.ballsCollectedAchievementSO.Achievements[i].name, achievementSOList.ballsCollectedAchievementSO.Achievements[i].info);
                currentBallsCollectedAchivementLevel = i + 1;
            }
        }
    }
}
