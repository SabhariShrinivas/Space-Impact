using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameplayUIController : MonoBehaviour
{
    public static GameplayUIController instance;
    [SerializeField] private Text waveInfoText, shipDestroyedInfoText, meteorDestroyedInfoText;
    private int waveCount, shipDestroyedCount, meteorDestroyedCount;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void SetWave()
    {
        waveCount++;
        waveInfoText.text = "Wave " + waveCount;
    }
    public void setShipDestroyed()
    {
        shipDestroyedCount++;
        shipDestroyedInfoText.text = shipDestroyedCount + "x";
    }
    public void setMeteorDestroy()
    {
        meteorDestroyedCount++;
        meteorDestroyedInfoText.text = meteorDestroyedCount + "x";
    }
    public void SetInfo(int infoType)
    {
        switch (infoType)
        {
            case 1:
                waveCount++;
                waveInfoText.text = "Wave " + waveCount;
                break;

            case 2:
                shipDestroyedCount++;
                shipDestroyedInfoText.text = shipDestroyedCount + "x";
                break;

            case 3:
                meteorDestroyedCount++;
                meteorDestroyedInfoText.text = meteorDestroyedCount + "x";
                break;
        }
    }
    public int GetWave()
    {
        return waveCount;
    }
    public int GetShipDestroyed()
    {
        return shipDestroyedCount;
    }
    public int GetMeteorDestroyed()
    {
        return meteorDestroyedCount;
    }
}
