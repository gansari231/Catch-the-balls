using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class InputHandler : SingletonGeneric<InputHandler>
{
    [SerializeField]
    public TMP_InputField _nameInput;
    [SerializeField]
    string _fileName;
    List<HighscoreElement> entries = new List<HighscoreElement>();

    void Start()
    {
        entries = FileHandler.ReadFromJSON<HighscoreElement>(_fileName);
    }

    public void AddDataToList(int score)
    {
        entries.Add(new HighscoreElement(_nameInput.text, score));
        FileHandler.SaveToJSON<HighscoreElement>(entries, _fileName);
    }

    public void StartGame()
    {
        if(_nameInput.text.Length == 0)
        {
            Debug.Log("Enter name!!!");          
        }
        else
        {
            UIManager.Instance.StartGame();
        }       
    }
}
