using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using UnityEngine;
using UnityEngine.XR;

public class xmlTest : MonoBehaviour
{
    string filePath = "Assets/Resources/XML/";
    string fileName = "xmlTest.xml";

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
        XmlDocument doc = new XmlDocument();

        XmlElement root = doc.CreateElement("root"); // root
        doc.AppendChild(root);

        XmlElement header = doc.CreateElement("header"); 
        XmlElement tempo = doc.CreateElement("tempo"); 
        XmlElement note_list = doc.CreateElement("note_list"); 

        root.AppendChild(header); // root/header
        root.AppendChild(tempo); // root/tempo
        root.AppendChild(note_list);// root/note_list


        for (int i = 3; i < 7; i++)
        {
            XmlElement track = doc.CreateElement("track");
            track.SetAttribute("idx", i.ToString()); // <track idx="3">
            note_list.AppendChild(track); // root/note_list/track

            foreach (int data in tracks[i - 3])
            {
                XmlElement notes = doc.CreateElement("note");
                notes.SetAttribute("tick", data.ToString());
                track.AppendChild(notes); // root/note_list/track/note
            }
        }

        doc.Save(filePath + fileName);
    }

}


