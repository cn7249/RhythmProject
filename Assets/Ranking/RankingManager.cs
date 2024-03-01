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
        instance = this; // TODO �̱����� ���� �ʿ�
    }

    public void AddRankingEntry(int songId, string userName, int record)
    {
        RankingEntry newRankingEntry = new RankingEntry(userName, record);

        if(true) // TODO : ��ųʸ��� �����ϴ��� �Ǵ��ϴ� �ͺ���
        {
            GetRankingList(songId).Add(newRankingEntry);
        }
        

        //TODO
        SortRankingList(1);
    }

    private void SortRankingList(int songId)
    {
        //TODO �� ��Ʈ ���� ����
        throw new NotImplementedException(); 
    }

    public List<RankingEntry> GetRankingList(int songId)
    {
        return new List<RankingEntry>(); //TODO
    }

    
}
