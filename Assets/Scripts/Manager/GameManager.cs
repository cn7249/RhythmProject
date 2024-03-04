using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletoneBase<GameManager>
{
	public UIManager UI;
	public RankingManager Ranking;
	
	private void Awake()
	{
		//base.Awake();
    }

    public override void Init()
    {
        UI = UIManager.Instance;
		Ranking = RankingManager.Instance;
    }
}
