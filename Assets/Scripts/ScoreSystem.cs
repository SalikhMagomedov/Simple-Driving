using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreMultiplier = 1f;

    public const string HighScoreKey = "HighScore";

    private float _score;

    private void Update()
    {
        _score += scoreMultiplier * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(_score).ToString();
    }

    private void OnDestroy()
    {
        var currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);

        if (_score > currentHighScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, Mathf.FloorToInt(_score));
        }
    }
}