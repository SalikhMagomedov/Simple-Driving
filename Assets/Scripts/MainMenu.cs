using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText;

    private void Start()
    {
        highScoreText.text = $"High Score: {PlayerPrefs.GetInt(ScoreSystem.HighScoreKey, 0)}";
    }

    public void Play()
    {
        SceneManager.LoadSceneAsync(1);
    }
}