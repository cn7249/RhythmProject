using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingEntry
{
    public RankingEntry(string UserName, int Score)
    {
        this.UserName = UserName;
        this.Score = Score;
    }

    public string   UserName { get; set; }
    public int      Score { get; set; }
}

