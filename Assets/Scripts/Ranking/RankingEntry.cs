using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RankingEntry
{
    public RankingEntry(string UserName, int Score)
    {
        userName = UserName;
        score = Score;
    }

    [SerializeField] private string userName;
    public string UserName => userName;

    [SerializeField] private int score;
    public int Score => score;


    // 프로퍼티는 json 저장 안되는 것 같다.
}

