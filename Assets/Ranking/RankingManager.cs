using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    public static RankingManager instance;
    
    Dictionary<int, List<RankingEntry>> rankingMap = new Dictionary<int, List<RankingEntry>>();

    private void Awake()
    {
        instance = this; // TODO 싱글톤은 개선 필요
    }

    public void AddRankingEntry(int songId, string userName, int record)
    {
        RankingEntry newRankingEntry = new RankingEntry(userName, record);

        if(true) // TODO : 딕셔너리에 존재하는지 판단하는 것부터
        {
            GetRankingList(songId).Add(newRankingEntry);
        }
        

        //TODO
        SortRankingList(1);
    }

    private void SortRankingList(int songId)
    {
        //TODO 퀵 솔트 구현 시작
        throw new NotImplementedException(); 
    }

    public List<RankingEntry> GetRankingList(int songId)
    {
        return new List<RankingEntry>(); //TODO
    }

    
}
