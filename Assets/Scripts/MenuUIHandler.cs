using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    private void Start()
    {
        nameInputField.onEndEdit.AddListener(name => SetPlayerName(name));
        bestScoreText.SetText("Best Score: " + 
            DataManager.Instance.BestPlayerName + ": " + 
            DataManager.Instance.BestScore);
    }

    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }

    public void ExitGame()
    {
        DataManager.Instance.SaveAllData();
        GameManager.Instance.ExitGame();    
    }

    public void SetPlayerName(string name)
    {
        DataManager.Instance.PlayerName = name;
    }
}
