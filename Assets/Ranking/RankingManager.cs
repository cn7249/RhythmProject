using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class RankingManager : MonoBehaviour
{
    public static RankingManager instance;
    
    public Dictionary<int, List<RankingEntry>> rankingMap = new Dictionary<int, List<RankingEntry>>();


    // UI TEST 삭제 필요
    [SerializeField] private InputField songIdInputField;
    [SerializeField] private InputField userNameInputField;
    [SerializeField] private InputField scoreInputField;

    [SerializeField] private GameObject contentPanel;
    [SerializeField] private GameObject contentPrefab;


    private void Awake()
    {
        instance = this; // TODO 싱글톤은 개선 필요
    }

    
    public void AddRankingEntry(int songId, string userName, int record)
    {
        RankingEntry newRankingEntry = new RankingEntry(userName, record);

        if(rankingMap.ContainsKey(songId))
        {
            rankingMap[songId].Add(newRankingEntry);
            MergeSort(rankingMap[songId]);
        }
        else
        {
            rankingMap.Add(songId, new List<RankingEntry>() { newRankingEntry });
        }
              
        
        Debug.Log(rankingMap);
    }


    #region 병합 정렬
    private void MergeSort(List<RankingEntry> list)
    {
        if (list.Count <= 1)
            return;

        int mid = list.Count / 2;
        List<RankingEntry> left = new List<RankingEntry>(list.GetRange(0, mid));
        List<RankingEntry> right = new List<RankingEntry>(list.GetRange(mid, list.Count - mid));

        MergeSort(left);
        MergeSort(right);

        Merge(list, left, right);
    }

    private void Merge(List<RankingEntry> list, List<RankingEntry> left, List<RankingEntry> right)
    {
        int i = 0, j = 0, k = 0;

        while (i < left.Count && j < right.Count)
        {
            if (left[i].Score >= right[j].Score)
            {
                list[k++] = left[i++];
            }
            else
            {
                list[k++] = right[j++];
            }
        }

        while (i < left.Count)
        {
            list[k++] = left[i++];
        }

        while (j < right.Count)
        {
            list[k++] = right[j++];
        }
    }
    #endregion

    #region 순위 출력
    public void ShowRanking(int songId)
    {
        int ranking = 1;
        int prevScore;

        foreach (Transform child in contentPanel.GetComponent<Transform>())
        {
            Destroy(child.gameObject);
        }

        if (rankingMap.ContainsKey(songId))
        {
            prevScore = rankingMap[songId][0].Score;

            for (int i = 0; i < rankingMap[songId].Count; ++i)
            {
                RankingEntry rankingEntry = rankingMap[songId][i];

                if (prevScore != rankingEntry.Score)
                    ++ranking;

                GameObject newContent = Instantiate(contentPrefab, contentPanel.GetComponent<Transform>());
                newContent.GetComponent<Content>().SetInform(ranking, rankingEntry.UserName, rankingEntry.Score);

                prevScore = rankingEntry.Score;
            }
        }
        else { return; }
    }
    #endregion



    // UI TEST 삭제 필요
    public void submitTestInformation()
    {
        int songId = int.Parse(songIdInputField.text);
        string userName = userNameInputField.text;
        int score = int.Parse(scoreInputField.text);
        AddRankingEntry(songId, userName, score);
    }
    // UI TEST 삭제 필요
}
