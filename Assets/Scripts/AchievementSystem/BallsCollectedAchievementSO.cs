using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "BallsCollectedAchievementSO", menuName = "ScriptableObjects/Achievement/NewBallsCollectedAchievmentSO")]
public class BallsCollectedAchievementSO : ScriptableObject
{
    public AchievementType[] Achievements;

    [Serializable]
    public class AchievementType
    {
        public enum BallsAchievements
        {
            None,
            Amateur,
            PROOOO,
            Hacker
        }

        public string name;
        public string info;
        public BallsAchievements selectAchievement;
        public int requirement;
    }
}
