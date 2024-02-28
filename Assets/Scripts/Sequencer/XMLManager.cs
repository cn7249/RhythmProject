using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using UnityEngine;
using UnityEngine.XR;

public class XMLManager : MonoBehaviour
{
    // 파일 경로와 이름
    string filePath = "Assets/Resources/XML/";
    string fileName = "xmlTest.xml";

    // 곡 정보
    public SongInfo songInfos = new SongInfo();

    // 트랙 별 노트 정보
    public List<int>[] tracks = new List<int>[]
    {
        new List<int> { },
        new List<int> { },
        new List<int> { },
        new List<int> { }
    };

    private void Start()
    {
        // SaveXML();
        // LoadXML();
        // PrintList();
    }

    public void SaveXML()
    {
        SortNotes();

        // Xml 선언(버전, 인코딩 방식 설정)
        XmlDocument doc = new XmlDocument();
        doc.AppendChild(doc.CreateXmlDeclaration("1.0", "utf-8", "no"));

        // 문서 root 요소 정의
        XmlElement root = doc.CreateElement("root"); // root
        doc.AppendChild(root);

        // "root" 자식 요소 정의
        XmlElement header = doc.CreateElement("header"); 
        XmlElement tempo = doc.CreateElement("tempo"); 
        XmlElement note_list = doc.CreateElement("note_list"); 

        root.AppendChild(header); // root/header
        root.AppendChild(tempo); // root/tempo
        root.AppendChild(note_list);// root/note_list

        // "header" 자식 요소 정의
        XmlElement songInfo = doc.CreateElement("songinfo");

        songInfo.SetAttribute("tempo", songInfos.tempo.ToString());
        songInfo.SetAttribute("tpm", songInfos.tpm.ToString());
        songInfo.SetAttribute("start_tick", songInfos.startTick.ToString());
        songInfo.SetAttribute("end_tick", songInfos.endTick.ToString());
        songInfo.SetAttribute("tick", songInfos.tick.ToString());
        songInfo.SetAttribute("ms", songInfos.ms.ToString());
        songInfo.SetAttribute("tps", songInfos.tps.ToString());

        header.AppendChild(songInfo);

        // "tempo" 자식 요소 정의
        XmlElement tempoChild = doc.CreateElement("tempo");

        tempoChild.SetAttribute("tick", songInfos.startTick.ToString());
        tempoChild.SetAttribute("tempo", songInfos.tempo.ToString());
        tempoChild.SetAttribute("tps", songInfos.tps.ToString());

        tempo.AppendChild(tempoChild);

        // "note_list" 하위에 track별 note 정보 할당
        for (int i = 0; i < 4; i++)
        {
            XmlElement track = doc.CreateElement("track");
            track.SetAttribute("idx", (i + 3).ToString()); // <track idx="i">
            note_list.AppendChild(track); // root/note_list/track

            foreach (int data in tracks[i])
            {
                XmlElement notes = doc.CreateElement("note");
                notes.SetAttribute("tick", data.ToString());
                track.AppendChild(notes); // root/note_list/track/note
            }
        }

        // Xml 저장
        doc.Save(filePath + fileName);
    }

    public void LoadXML()
    {
        // XML 불러와서 파일읽기
        XmlDocument doc = new XmlDocument();
        doc.Load(filePath + fileName);

        // root 설정
        XmlElement nodes = doc["root"];

        // "header" -> "songinfo" 속성 읽어오기
        XmlElement header = nodes["header"];
        XmlElement songInfo = header["songinfo"];

        SongInfo readInfo = new SongInfo();

        readInfo.tempo = System.Convert.ToSingle(songInfo.GetAttribute("tempo"));
        readInfo.tpm = System.Convert.ToInt32(songInfo.GetAttribute("tpm"));
        readInfo.startTick = System.Convert.ToInt32(songInfo.GetAttribute("start_tick"));
        readInfo.endTick = System.Convert.ToInt32(songInfo.GetAttribute("end_tick"));
        readInfo.tick = System.Convert.ToInt32(songInfo.GetAttribute("tick"));
        readInfo.ms = System.Convert.ToInt32(songInfo.GetAttribute("ms"));
        readInfo.tps = System.Convert.ToInt32(songInfo.GetAttribute("tps"));

        songInfos = readInfo;

        // 트랙 별 노트 정보 불러오기
        XmlElement noteList = nodes["note_list"];

        ClearNotes();

        for (int i = 0; i < 4; i++)
        {
            XmlNodeList trackNodes = noteList.ChildNodes;
            
            foreach (XmlElement note in trackNodes[i])
            {
                int temp = System.Convert.ToInt32(note.GetAttribute("tick"));
                tracks[i].Add(temp);
            }
            
        }

    }

    public void PrintList()
    {
        // songinfo 속성 출력
        SongInfo a = songInfos;
        UnityEngine.Debug.Log($"tempo={a.tempo}," +
            $" tpm={a.tpm}," +
            $" start_tick={a.startTick}," +
            $" end_tick={a.endTick}," +
            $" tick={a.tick}," +
            $" ms={a.ms}," +
            $" tps={a.tps}");

        // 트랙 별 노트 tick 출력
        for (int i = 0; i < 4; i++)
        {
            foreach (int tick in tracks[i])
            {
                UnityEngine.Debug.Log($"track: {i + 3}, tick: {tick}");
            }
        }
    }

    private void SortNotes()
    {
        foreach (List<int> track in tracks)
        {
            track.Sort();
        }
    }

    private void ClearNotes()
    {
        foreach (List<int> track in tracks)
        {
            track.Clear();
        }
    }
}

[System.Serializable]
public class SongInfo
{
    public float tempo;
    public int tpm;
    public int startTick;
    public int endTick;
    public int tick;
    public int ms;
    public int tps;
}
