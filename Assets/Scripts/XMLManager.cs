using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using UnityEngine;
using UnityEngine.XR;

public class XMLManager : MonoBehaviour
{
    string filePath = "Assets/Resources/XML/";
    string fileName = "xmlTest.xml";

    SongInfo songInfos = new SongInfo();

    List<int>[] tracks = new List<int>[]
    {
        new List<int> { },
        new List<int> { },
        new List<int> { },
        new List<int> { }
    };

    private void Start()
    {
        tracks[0].Add(1536);
        tracks[1].Add(3072);
        tracks[2].Add(4068);
        tracks[3].Add(6144);

        SaveXML();
    }

    private void SaveXML()
    {
        // Xml ����(����, ���ڵ� ��� ����)
        XmlDocument doc = new XmlDocument();
        doc.AppendChild(doc.CreateXmlDeclaration("1.0", "utf-8", "no"));

        // ���� root ��� ����
        XmlElement root = doc.CreateElement("root"); // root
        doc.AppendChild(root);

        // "root" �ڽ� ��� ����
        XmlElement header = doc.CreateElement("header"); 
        XmlElement tempo = doc.CreateElement("tempo"); 
        XmlElement note_list = doc.CreateElement("note_list"); 

        root.AppendChild(header); // root/header
        root.AppendChild(tempo); // root/tempo
        root.AppendChild(note_list);// root/note_list

        // "header" �ڽ� ��� ����
        XmlElement songInfo = doc.CreateElement("songinfo");

        songInfo.SetAttribute("tempo", songInfos.tempo.ToString());
        songInfo.SetAttribute("tpm", songInfos.tpm.ToString());
        songInfo.SetAttribute("start_tick", songInfos.startTick.ToString());
        songInfo.SetAttribute("end_tick", songInfos.endTick.ToString());
        songInfo.SetAttribute("tick", songInfos.tick.ToString());
        songInfo.SetAttribute("ms", songInfos.ms.ToString());
        songInfo.SetAttribute("tps", songInfos.tps.ToString());

        header.AppendChild(songInfo);

        // "tempo" �ڽ� ��� ����
        XmlElement tempoChild = doc.CreateElement("tempo");

        tempoChild.SetAttribute("tick", songInfos.startTick.ToString());
        tempoChild.SetAttribute("tempo", songInfos.tempo.ToString());
        tempoChild.SetAttribute("tps", songInfos.tps.ToString());

        tempo.AppendChild(tempoChild);

        // "note_list" ������ track�� note ���� �Ҵ�
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

        // Xml ����
        doc.Save(filePath + fileName);
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
