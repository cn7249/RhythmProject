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
        InGameManager.instance.JudgementBad += UpdateScore;
        InGameManager.instance.JudgementGood += UpdateScore;
        InGameManager.instance.JudgementPerfect += UpdateScore;
        InGameManager.instance.GameSpeedChange += UpdateGameSpeed;

        UpdateScore();
        UpdateGameSpeed(InGameManager.instance.gameSpeed);
    }

    private void UpdateScore()
    {
        playerScore.text = $"HP : {InGameManager.instance.hp}\n";
        playerScore.text += $"Score : {InGameManager.instance.score}\n";
        playerScore.text += $"Combo : {InGameManager.instance.combo}\n";
    }

    private void UpdateGameSpeed(float speed)
    {
        gameSpeed.text = $"{speed.ToString("F1")}";
    }
}
