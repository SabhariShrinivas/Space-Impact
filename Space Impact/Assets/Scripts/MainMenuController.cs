using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Canvas mainMenuCanvas, highScoreCanvas;
    [SerializeField] private Text shipDestroyedHighScore, meteorDestroyedHighScore, waveSurvivedHighScore;

    public void PlayGame()
    {
        SceneManager.LoadScene(TagManager.GAMEPLAY_LEVEL_NAME);
    }
     public void OpenCloseHighScoreCanvas(bool open)
    {
        mainMenuCanvas.enabled = !open;
        highScoreCanvas.enabled = open;
        if (open)
        {
            DisplayHighScore();
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void DisplayHighScore()
    {
        shipDestroyedHighScore.text = "x" + DataManager.GetData(TagManager.SHIPS_DESTROYED_DATA);
        meteorDestroyedHighScore.text = "x" + DataManager.GetData(TagManager.METEOR_DESTROYEDE_DATA);
        waveSurvivedHighScore.text = "Wave: " + DataManager.GetData(TagManager.WAVE_NUMBER_DATA);
    }
}
