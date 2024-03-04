using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class RankingMap
{
    public string key;
    public List<RankingEntry> values = new List<RankingEntry>();
}

[System.Serializable]
public class RankingMapWrap
{
    public List<RankingMap> RankingMapList = new List<RankingMap>();
}

public class RankingManager : SingletoneBase<RankingManager>
{    
    public Dictionary<string, List<RankingEntry>> rankingMap = new Dictionary<string, List<RankingEntry>>();
    public string songName { get; set; }


    public override void Init()
    {
        LoadRankingMap();

        //SaveRankingMap();
    }

    #region 곡 별 순위 추가
    public void AddRankingEntry(string songName, string userName, int record)
    {
        RankingEntry newRankingEntry = new RankingEntry(userName, record);

        if(rankingMap.ContainsKey(songName))
        {
            rankingMap[songName].Add(newRankingEntry);
            MergeSort(rankingMap[songName]);
        }
        else
        {
            rankingMap.Add(songName, new List<RankingEntry>() { newRankingEntry });
        }

        SaveRankingMap();

        Debug.Log(rankingMap);
    }
    #endregion


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
    public void ShowRanking()
    {
        UIManager.Instance.ShowUI<UIRankingBoard>();

        GameObject contentsPanel = Util.FindChild(UIManager.Instance.GetUI<UIRankingBoard>(), "ContentsPanel", true);

        int ranking = 1;
        int prevScore;

        foreach (Transform child in contentsPanel.GetComponent<Transform>())
        {
            Destroy(child.gameObject);
        }

        if (songName == null) return;

        if (rankingMap.ContainsKey(songName))
        {
            prevScore = rankingMap[songName][0].Score;

            for (int i = 0; i < rankingMap[songName].Count; ++i)
            {
                RankingEntry rankingEntry = rankingMap[songName][i];

                if (prevScore != rankingEntry.Score)
                    ++ranking;

                GameObject newContent = Util.Instantiate<UIContent>("Prefabs/UI", contentsPanel.GetComponent<Transform>());

                newContent.GetComponent<UIContent>().SetInform(ranking, rankingEntry.UserName, rankingEntry.Score);

                prevScore = rankingEntry.Score;
            }
        }
        else { return; }
    }
    #endregion


    #region Save and Load in Json

    // get save file path
    public string GetSaveFilePath(string fileName = "rankingData.json") // TODO=> string 형 인자 추가하고 Util 클래스로 이전 필요
    {
        string filePath = Path.Combine(Application.dataPath, fileName);

        if(!File.Exists(filePath))
        {
            File.WriteAllText(filePath, string.Empty);
        }

        Debug.Log(filePath);

        return filePath;
    }

    // save
    public void SaveRankingMap()
    {
        string filePath = GetSaveFilePath();

        RankingMapWrap rankingMapWrap = new RankingMapWrap();

        foreach (var ranking in rankingMap)
        {
            RankingMap entry = new RankingMap
            {
                key = ranking.Key,
                values = ranking.Value
            };

            rankingMapWrap.RankingMapList.Add(entry);
        }

        string jsonData = JsonUtility.ToJson(rankingMapWrap, true);
        File.WriteAllText(filePath, jsonData);
    }

    // load
    public void LoadRankingMap()
    {
        string filePath = GetSaveFilePath();

        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);

            RankingMapWrap rankingMapWrap = JsonUtility.FromJson<RankingMapWrap>(jsonData);

            rankingMap.Clear(); // 딕셔너리 비우기

            foreach (var entry in rankingMapWrap.RankingMapList)
            {
                rankingMap.Add(entry.key, entry.values);
            }

            Debug.Log(typeof(RankingMapWrap).Name + "Data Loaded :" + filePath);
        }
        else
        {
            Debug.Log(typeof(RankingMapWrap).Name + "Data Not Loaded :" + filePath);
        }
       
    }

    #endregion
}
