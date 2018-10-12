using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    private int score;
    private Text uiScore;

    void Start()
    {
        uiScore = gameObject.GetComponent<Text>();

        uiScore.text = score.ToString();
    }

    public void IncrementScore(int points)
    {
        score += points;
        uiScore.text = score.ToString();
    }
}