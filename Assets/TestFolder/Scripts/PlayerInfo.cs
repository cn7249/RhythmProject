using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text playerScore;
    [SerializeField] private TMP_Text gameSpeed;

    private void Start()
    {
        GameManager.instance.JudgementBad += UpdateScore;
        GameManager.instance.JudgementGood += UpdateScore;
        GameManager.instance.JudgementPerfect += UpdateScore;
        GameManager.instance.GameSpeedChange += UpdateGameSpeed;

        UpdateScore();
        UpdateGameSpeed(GameManager.instance.gameSpeed);
    }

    private void UpdateScore()
    {
        playerScore.text = $"HP : {GameManager.instance.hp}\n";
        playerScore.text += $"Score : {GameManager.instance.score}\n";
        playerScore.text += $"Combo : {GameManager.instance.combo}\n";
    }

    private void UpdateGameSpeed(float speed)
    {
        gameSpeed.text = $"Speed : {speed.ToString("F1")}";
    }
}
