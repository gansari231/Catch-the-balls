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
    TextMeshProUGUI _gameCompleteText;

    [SerializeField]
    CanvasRenderer _achievementPanel;
    [SerializeField] 
    HighscoreHandler highscoreHandler;
    HighscoreElement highscoreElement;

    [SerializeField]
    GameObject _gameAreaPanel;
    [SerializeField]
    GameObject _gameComponentsPanel;
    [SerializeField]
    GameObject _mainMenuPanel;
    [SerializeField]
    GameObject _player;
    [SerializeField]
    GameObject _gameCompletePanel;
    [SerializeField]
    GameObject _highscoreTable;

    public int _score;
    public bool startGame;

    void Start()
    {
        _score = 0;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        startGame = true;
        _mainMenuPanel.SetActive(false);
        _gameAreaPanel.SetActive(true);
        _gameComponentsPanel.SetActive(true);
        _player.SetActive(true);
        SpawnManager.Instance.StartGame();
    }

    void RestartGame()
    {
        Time.timeScale = 1;
        InputHandler.Instance._nameInput.text = "";
        startGame = false;
        _mainMenuPanel.SetActive(true);
        _gameAreaPanel.SetActive(false);
        _gameComponentsPanel.SetActive(false);
        _player.SetActive(false);
        _gameCompleteText.gameObject.SetActive(true);
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

    public void GameCompleteSequence()
    {
        _gameCompleteText.text = _gameCompleteText.text + _score + " points!!!!!";
        _gameCompletePanel.SetActive(true);
        highscoreHandler.UpdateMaxHighscore(new HighscoreElement(InputHandler.Instance._nameInput.text, _score));
        _player.SetActive(false);
        StartCoroutine(GameEnd());
    }

    IEnumerator GameEnd()
    {
        yield return new WaitForSeconds(5.0f);
        _gameCompletePanel.SetActive(false);
        RestartGame();
    }

    public void ShowHighScoreTable()
    {
        _mainMenuPanel.SetActive(false);
        _highscoreTable.SetActive(true);
    }

    public void CloseHighScoreTable()
    {
        _mainMenuPanel.SetActive(true);
        _highscoreTable.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
