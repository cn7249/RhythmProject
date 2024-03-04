using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletoneBase<GameManager>
{
	public UIManager UI;
	public RankingManager Ranking;

    public string songName;
    public int gameSpeed = 1;

    public override void Init()
    {
        UI = UIManager.Instance;
		Ranking = RankingManager.Instance;

        songName = string.Empty;
    }
}
