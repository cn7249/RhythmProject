using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private TMP_Text playerScore;

    private void Start()
    {
        GameManager.instance.JudgementBad += UpdateScore;
        GameManager.instance.JudgementGood += UpdateScore;
        GameManager.instance.JudgementPerfect += UpdateScore;

        UpdateScore();
    }

    private void UpdateScore()
    {
        playerScore.text = $"HP : {GameManager.instance.hp}\n";
        playerScore.text += $"Score : {GameManager.instance.score}\n";
        playerScore.text += $"Combo : {GameManager.instance.combo}\n";
    }
}
