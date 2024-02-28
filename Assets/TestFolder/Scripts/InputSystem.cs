using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    public void OnClickNote0(InputAction.CallbackContext context)
	{
		if (context.started)
		{
			InputSystemManager.instance.OnNotes[0]();
		}
	}
	
	public void OnClickNote1(InputAction.CallbackContext context)
	{
		if (context.started)
		{
			Debug.Log("d");
		}
	}
	
	public void OnClickNote2(InputAction.CallbackContext context)
	{
		if (context.started)
		{
			Debug.Log("j");
		}
	}
	
	public void OnClickNote3(InputAction.CallbackContext context)
	{
		if (context.started)
		{
			Debug.Log("k");
		}
	}
}
