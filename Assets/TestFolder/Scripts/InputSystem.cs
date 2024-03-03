using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class InputSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] _lineLights;
    [SerializeField] private Image[] _keyImgs;

    private Color defaultColor;
    private Color activatedColor;

    public void OnClickNote0(InputAction.CallbackContext context)
	{
        if (context.started)
        {
            _lineLights[0].SetActive(true);
            _keyImgs[0].color = activatedColor;
        }
        else if (context.canceled)
        {
            _lineLights[0].SetActive(false);
            _keyImgs[0].color = defaultColor;
        }
    }
	
	public void OnClickNote1(InputAction.CallbackContext context)
	{
        if (context.started)
        {
            _lineLights[1].SetActive(true);
            _keyImgs[1].color = activatedColor;
        }
        else if (context.canceled)
        {
            _lineLights[1].SetActive(false);
            _keyImgs[1].color = defaultColor;
        }
    }
	
	public void OnClickNote2(InputAction.CallbackContext context)
	{
        if (context.started)
        {
            _lineLights[2].SetActive(true);
            _keyImgs[2].color = activatedColor;
        }
        else if (context.canceled)
        {
            _lineLights[2].SetActive(false);
            _keyImgs[2].color = defaultColor;
        }
    }
	
	public void OnClickNote3(InputAction.CallbackContext context)
	{
        if (context.started)
        {
            _lineLights[3].SetActive(true);
            _keyImgs[3].color = activatedColor;
        }
        else if (context.canceled)
        {
            _lineLights[3].SetActive(false);
            _keyImgs[3].color = defaultColor;
        }
    }

    private void KeyInput(InputAction.CallbackContext context, int index)
    {
        if (context.started)
        {
            _lineLights[index].SetActive(true);
            _keyImgs[index].color = activatedColor;
        }
        else if (context.canceled)
        {
            _lineLights[index].SetActive(false);
            _keyImgs[index].color = defaultColor;
        }
    }

}
