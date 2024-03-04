using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class GameSpeed : MonoBehaviour
{
    [SerializeField] private GameObject uiNotes;

    private bool speedBool;
    private float speedUnit = 0.1f;

    private void Start()
    {
        InGameManager.instance.GameSpeedChange += ChangeSpeed;
    }

    public void SpeedDown(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            InGameManager.instance.GameSpeedChange(InGameManager.instance.gameSpeed - speedUnit);
        }
    }

    public void SpeedUp(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            InGameManager.instance.GameSpeedChange(InGameManager.instance.gameSpeed + speedUnit);
        }
    }

    public void OnClickTestButton()
    {
        if (!speedBool)
        {
            InGameManager.instance.GameSpeedChange(5);
            speedBool = true;
        }
        else
        {
            InGameManager.instance.GameSpeedChange(1);
            speedBool = false;
        }
    }

    public void ChangeSpeed(float index)
    {
        InGameManager.instance.gameSpeed = index;
    }
}
