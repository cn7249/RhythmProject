using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputSystemManager : MonoBehaviour
{
    public static InputSystemManager instance;
	
	public List<Action> OnNotes;
	
	private void Awake()
	{
		instance = this;
	}
	
}
