using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

public class NoteGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _notes;

    private GameObject _noteBlue;
    private GameObject _noteOrange;

    private XMLManager _xml;

    private int tpm; // Default = 1536 ticks per 1 bar
    private float hpt; // heights per tick = 640 / 1536
    private float tempo;
    private float hps;


    private void Awake()
    {
        _xml = GetComponent<XMLManager>();
        _noteBlue = Resources.Load<GameObject>("Prefabs/Notes/NoteBlue");
        _noteOrange = Resources.Load<GameObject>("Prefabs/Notes/NoteOrange");
    }

    private void Start()
    {
        LoadNotes("xmlTest2.xml");
    }

    //private void Update()
    //{
    //    MoveNotes();
    //}
    //
    //private void MoveNotes()
    //{
    //    float speed = hps * Time.deltaTime * GameManager.instance.gameSpeed;
    //    _notes.transform.position -= new Vector3(0f, speed, 0f);
    //}

    public bool LoadNotes(string fileName)
    {
        _xml.fileName = fileName;

        if (File.Exists(_xml.GetFilePath))
        {
            _xml.LoadXML();
            InitParameters();
            MakeNotes();
            return true;
        }
        else
        {
            return false; // ������ ������ ��ο� ������ false ��ȯ
        }
    }

    private void InitParameters()
    {
        tpm = _xml.songInfos.tpm;
        hpt = 640f / tpm;
        tempo = _xml.songInfos.tempo;
        hps = 8f / 3f * tempo;
    }

    private void MakeNotes()
    {
        // _xml.tracks�� ������ Note�� ����
        for (int i = 0; i < 4; i++)
        {
            foreach (int tick in _xml.tracks[i])
            {
                float x = -240f + (160f * i);
                float y = 760f + tick * hpt; // ������ ���� bar 2����ŭ ������ ����

                if (i == 0 || i == 3) // 1��, 4�� Ʈ���� �Ķ��� ��Ʈ ����
                {
                    var obj = Instantiate(_noteBlue, new Vector3(x, y, 0f), Quaternion.identity, _notes.transform);
                    SetNoteInfo(obj, i, y);
                }
                else // 2��, 3�� Ʈ���� ��Ȳ�� ��Ʈ ����
                {
                    var obj = Instantiate(_noteOrange, new Vector3(x, y, 0f), Quaternion.identity, _notes.transform);
                    SetNoteInfo(obj, i, y);
                }
            }
        }
    }

    private void SetNoteInfo(GameObject obj, int i, float y)
    {
        obj.GetComponent<NoteBehaviour>().beginPos = y;
        obj.GetComponent<NoteBehaviour>().hps = hps;
        obj.GetComponent<NoteBehaviour>().index = i;
        GameManager.instance.queues[i].Enqueue(obj);
    }
}
