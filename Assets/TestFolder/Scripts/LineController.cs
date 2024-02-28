using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
	[SerializeField] private GameObject perfectZone;
	[SerializeField] private GameObject effect;
	
	public int index;
	
	public void Init()
	{
		// 에러
		//InputSystemManager.instance.OnNotes[index] += LineEffect;
	}
	
	// 키 입력 이펙트
	private void LineEffect()
	{
		StopCoroutine(OffEffect());
		// todo
		effect.SetActive(true);
		
		StartCoroutine(OffEffect());
	}
	
	IEnumerator OffEffect()
	{
		yield return new WaitForSeconds(0.5f);
		effect.SetActive(false);
	}
}
