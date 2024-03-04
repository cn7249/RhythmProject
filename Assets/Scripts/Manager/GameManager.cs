using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletoneBase<GameManager>
{
	[SerializeField] private GameObject judgeLine;
	
	public Queue<GameObject>[] queues = new Queue<GameObject>[4];

	public Action JudgementBad;
    public Action JudgementGood;
    public Action JudgementPerfect;
	public Action<float> GameSpeedChange;

	public string songXML;

    public float judgePosY;
	public float gameSpeed;

	public float good;
	public float perfect;

	public int maxHp;
	public int badDamage;
	public int goodHeal;
	public int perfectHeal;
	public int goodScore;
	public int perfectScore;

    public int hp;
	public int combo;
	public int score;

	public UIManager UI;
	public RankingManager Ranking;
	
	private void Awake()
	{
		base.Awake();

		instance = this;
		for (int i = 0; i < queues.Length; i++)
		{
			queues[i] = new Queue<GameObject>();
		}
        judgePosY = judgeLine.transform.position.y;

        JudgementBad += Bad;
        JudgementGood += Good;
        JudgementPerfect += Perfect;

		hp = maxHp;

		songXML = "shortcut_110_cut";
    }

    public override void Init()
    {
        UI = UIManager.Instance;
		Ranking = RankingManager.Instance;
    }

    private void Bad()
    {
        Debug.Log("���");
        hp = Mathf.Max(hp - badDamage, 0);
		combo = 0;
    }

	private void Good()
    {
        Debug.Log("��");
        hp = Mathf.Min(hp + goodHeal, maxHp);
		combo++;
		score += goodScore;
    }

	private void Perfect()
    {
        Debug.Log("����");
        hp = Mathf.Min(hp + perfectHeal, maxHp);
        combo++;
        score += perfectScore;
    }

}
