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

public class RankingManager : MonoBehaviour
{
    public static RankingManager instance;
    
    public Dictionary<string, List<RankingEntry>> rankingMap = new Dictionary<string, List<RankingEntry>>();
    public string SongName { get; set; }

    [SerializeField] private GameObject contentPanel;
    [SerializeField] private GameObject contentPrefab;

    [SerializeField] private GameObject rankingCanvas;


    private void Awake()
    {
        instance = this; // TODO �̱����� ���� �ʿ�

        LoadRankingMap();

        /*AddRankingEntry("ª��ġ��", "test1", 10);
        AddRankingEntry("ª��ġ��", "test2", 100);
        AddRankingEntry("ª��ġ��", "test3", 10);
        AddRankingEntry("ª��ġ��", "test1", 150);*/

        SaveRankingMap();
    }

    #region �� �� ���� �߰�
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
              
        Debug.Log(rankingMap);
    }
    #endregion


    #region ���� ����
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


    //TODO => UI �Ŵ��� �ڸ� ������ ���� �ʿ�
    #region ���� ���
    public void ShowRanking()
    {
        rankingCanvas.SetActive(true);

        int ranking = 1;
        int prevScore;

        foreach (Transform child in contentPanel.GetComponent<Transform>())
        {
            Destroy(child.gameObject);
        }

        if (rankingMap.ContainsKey(SongName))
        {
            prevScore = rankingMap[SongName][0].Score;

            for (int i = 0; i < rankingMap[SongName].Count; ++i)
            {
                RankingEntry rankingEntry = rankingMap[SongName][i];

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


    #region Save and Load in Json

    // get save file path
    public string GetSaveFilePath(string fileName = "rankingData.json") // TODO=> string �� ���� �߰��ϰ� Util Ŭ������ ���� �ʿ�
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

            rankingMap.Clear(); // ��ųʸ� ����

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
