using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreMultiplier = 1f;

    private float _score;

    private void Update()
    {
        _score += scoreMultiplier * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(_score).ToString();
    }
}