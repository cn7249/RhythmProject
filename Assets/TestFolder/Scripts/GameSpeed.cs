using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    [SerializeField] private GameObject uiNotes;

    private bool speedBool;

    private void Start()
    {
        GameManager.instance.GameSpeedChange += ChangeSpeed;
    }

    public void OnClickTestButton()
    {
        if (!speedBool)
        {
            GameManager.instance.GameSpeedChange(2);
            speedBool = true;
        }
        else
        {
            GameManager.instance.GameSpeedChange(1);
            speedBool = false;
        }
    }

    public void ChangeSpeed(float index)
    {
        GameManager.instance.gameSpeed = index;
    }
}
