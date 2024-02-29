using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLine : MonoBehaviour
{
    [SerializeField] private GameObject linePrefab;
	[SerializeField] private Transform linesSpawnTrans;
	
	
	private int lineSize = 4;
	
	private void Start()
	{
		var lineList = GameManager.instance.lineList;
		lineList.Clear();
		for (int i = 0; i < lineSize; i++)
		{
			var obj = Instantiate(linePrefab, new Vector2((-0.75f * lineSize / 2) + i * 1, 0), Quaternion.identity, linesSpawnTrans);
			LineController lineCon = obj.GetComponent<LineController>();
			lineCon.index = i;
			lineCon.Init();
			lineList.Add(obj);
		}
	}
}
