using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUIController : MonoBehaviour
{
    public static GameOverUIController instance;
    [SerializeField] private Canvas playerInfoCanvas, shipsAndMeteorInfoCanvas, gameOverCanvas;
    [SerializeField] Text shipDestroyedFinalInfoText, meteorDestroyedFinalInfoText, waveFinalInfoText;
    [SerializeField] Text shipDestroyedHighScoreInfoText, meteorDestroyedHighScoreInfoText, waveHighScoreInfoText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        gameOverCanvas.enabled = false;
    }
    public void OpenGameOverPanel()
    {
        playerInfoCanvas.enabled = shipsAndMeteorInfoCanvas.enabled = false;
        gameOverCanvas.enabled = true;
        int shipDestroyedFinal = GameplayUIController.instance.GetShipDestroyed();
        int meteorDestroyedFinal = GameplayUIController.instance.GetMeteorDestroyed();
        int waveCountFinal = GameplayUIController.instance.GetWave() -1;

        shipDestroyedFinalInfoText.text = "x" + shipDestroyedFinal;
        meteorDestroyedFinalInfoText.text = "x" + meteorDestroyedFinal;
        waveFinalInfoText.text = "Wave" + waveCountFinal;
        CalculateHighScore(shipDestroyedFinal, meteorDestroyedFinal, waveCountFinal);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(TagManager.MAIN_MENU_LEVEL_NAME);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(TagManager.GAMEPLAY_LEVEL_NAME);
    }
    public void CalculateHighScore(int shipDestroyedCurrent, int meteorDestroyedCurrent, int waveCurrent)
    {
        int shipsDestroyedHighScore = DataManager.GetData(TagManager.SHIPS_DESTROYED_DATA);
        int meteorDestroyedHighScore = DataManager.GetData(TagManager.METEOR_DESTROYEDE_DATA);
        int waveHighScore = DataManager.GetData(TagManager.WAVE_NUMBER_DATA);

        if(shipDestroyedCurrent > shipsDestroyedHighScore) { DataManager.SaveData(TagManager.SHIPS_DESTROYED_DATA, shipDestroyedCurrent); }
        if (meteorDestroyedCurrent > meteorDestroyedHighScore) { DataManager.SaveData(TagManager.METEOR_DESTROYEDE_DATA, meteorDestroyedCurrent); }
        if (waveCurrent > waveHighScore) { DataManager.SaveData(TagManager.WAVE_NUMBER_DATA, waveCurrent); }

        shipDestroyedHighScoreInfoText.text = "x" + DataManager.GetData(TagManager.SHIPS_DESTROYED_DATA);
        meteorDestroyedHighScoreInfoText.text = "x" + DataManager.GetData(TagManager.METEOR_DESTROYEDE_DATA);
        waveHighScoreInfoText.text = "Wave: " + DataManager.GetData(TagManager.WAVE_NUMBER_DATA);
    }
}
