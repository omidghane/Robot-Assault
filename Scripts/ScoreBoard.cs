using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int score;
    TMP_Text ScoreText;

    private void Start() {
        ScoreText = GetComponent<TMP_Text>();
        ScoreText.text = "start";
    }
    public void increaseScore(int IncreaseAmountScore)
    {
        score += IncreaseAmountScore;
        ScoreText.text = score.ToString();
        // Debug.Log($" new score : {score}");
    }
}
