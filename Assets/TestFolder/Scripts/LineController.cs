using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
	[SerializeField] private GameObject judgeZone;
	[SerializeField] private GameObject perfectZone;
	
    public int index;
	
	private void OnTriggerEnter2D(Collider2D collider)
	{
		
	}
}
