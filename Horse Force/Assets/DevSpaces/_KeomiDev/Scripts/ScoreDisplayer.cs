using UnityEngine;
using TMPro;
public class ScoreDisplayer : MonoBehaviour
{
    private GameManager gameManager;

    public TextMeshProUGUI HighScoreV;
    public TextMeshProUGUI CurrScoreV;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        HighScoreV.text = gameManager.highScore.ToString();

        CurrScoreV.text = gameManager.getCurrScore().ToString();

    }
}
