using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
	
	public Queue<GameObject>[] queue = new Queue<GameObject>[4];
	public List<GameObject> lineList = new List<GameObject>();
	
	public float speed;
	
	private int hp;
	private int combo;
	private int score;
	
	private void Awake()
	{
		instance = this;
	}
	
	public void JudgementBad()
	{
		
	}
	
	public void JudgementGood()
	{
		
	}
	
	public void JudgementPerfect()
	{
		
	}
	
	
	public void OnClickTest()
	{
		Debug.Log(lineList.Count);
	}
}
