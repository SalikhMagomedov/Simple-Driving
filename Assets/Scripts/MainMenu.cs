using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text energyText;
    [SerializeField] private Button playButton;
    [SerializeField] private int maxEnergy;
    [SerializeField] private int energyRechargeDuration;
    [SerializeField] private AndroidNotificationHandler androidNotificationHandler;

    private int _energy;
    
    private const string EnergyKey = "Energy";
    private const string EnergyReadyKey = "EnergyReady";
    
    private void Start()
    {
        highScoreText.text = $"High Score: {PlayerPrefs.GetInt(ScoreSystem.HighScoreKey, 0)}";
        _energy = PlayerPrefs.GetInt(EnergyKey, maxEnergy);

        if (_energy == 0)
        {
            var energyReady = PlayerPrefs.GetString(EnergyReadyKey, string.Empty);

            if (energyReady == string.Empty)
            {
                return;
            }

            var energyReadyTime = DateTime.Parse(energyReady);

            if (DateTime.Now > energyReadyTime)
            {
                _energy = maxEnergy;
                PlayerPrefs.SetInt(EnergyKey, _energy);
            }
            else
            {
                playButton.interactable = false;
                Invoke(nameof(EnergyRecharged), (energyReadyTime - DateTime.Now).Seconds);
            }
        }
        
        energyText.text = $"Play ({_energy})";
    }

    private void EnergyRecharged()
    {
        playButton.interactable = true;
        _energy = maxEnergy;
        PlayerPrefs.SetInt(EnergyKey, _energy);
        energyText.text = $"Play ({_energy})";
    }

    public void Play()
    {
        if (_energy < 1)
        {
            return;
        }

        _energy--;
        PlayerPrefs.SetInt(EnergyKey, _energy);

        if (_energy == 0)
        {
            var energyReady = DateTime.Now.AddMinutes(energyRechargeDuration);
            PlayerPrefs.SetString(EnergyReadyKey, energyReady.ToString());
#if UNITY_ANDROID
            androidNotificationHandler.ScheduleNotification(energyReady);
#endif
        }
        
        SceneManager.LoadSceneAsync(1);
    }
}