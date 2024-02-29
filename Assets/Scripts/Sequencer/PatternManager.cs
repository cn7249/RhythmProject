using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PatternManager : MonoBehaviour
{
    public static PatternManager Instance;

    [SerializeField] private GameObject _grid;
    [SerializeField] private GameObject _bars;
    [SerializeField] private GameObject _notes;

    private XMLManager _xml;
    private GameObject _bar;
    private GameObject _noteBlue;
    private GameObject _noteOrange;

    private int tpm;
    private int totalBar;
    private float hpt; // heights per tick = 640 / 1536

    private void Awake()
    {
        _xml = GetComponent<XMLManager>();
        _bar = Resources.Load<GameObject>("Prefabs/Sequencer/Bar");
        _noteBlue = Resources.Load<GameObject>("Prefabs/Notes/NoteBlue");
        _noteOrange = Resources.Load<GameObject>("Prefabs/Notes/NoteOrange");

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        _xml.LoadXML();
        _xml.PrintList();
        InitParameters();
        MakeBars();
        MakeNotes();
    }

    private void InitParameters()
    {
        tpm = _xml.songInfos.tpm; // Default = 1536 ticks per 1 bar
        totalBar = _xml.songInfos.endTick / tpm;
        hpt = 640f / tpm;
    }

    public void CreateSingleNote(int barNum, float xPos, float yPos)
    {
        // _xml.tracks[0].Add(1536);

        float yScale = _grid.transform.localScale.y;
        float yOffset = _grid.transform.position.y;
        float y = (yPos + 640f * barNum) * yScale + yOffset;

        switch (xPos)
        {
            case -240f: // 1�� Ʈ��
                Instantiate(_noteBlue, new Vector3(xPos, y, 0f), Quaternion.identity, _notes.transform);
                break;
            case -80f: // 2�� Ʈ��
                Instantiate(_noteOrange, new Vector3(xPos, y, 0f), Quaternion.identity, _notes.transform);
                break;
            case 80f: // 3�� Ʈ��
                Instantiate(_noteOrange, new Vector3(xPos, y, 0f), Quaternion.identity, _notes.transform);
                break;
            case 240f: // 4�� Ʈ��
                Instantiate(_noteBlue, new Vector3(xPos, y, 0f), Quaternion.identity, _notes.transform);
                break;
        }
    }

    public void DeleteSingleNote(int barNum, float xPos, float yPos)
    {
        // _xml.tracks[0].Remove(1536);
        Debug.Log("DeleteSingleNote");
    }

    private void MakeBars()
    {
        // _xml.songinfos�� ������ Bar�� ����
        for (int i = 0; i < totalBar; i++)
        {
            TextMeshProUGUI barNum = _bar.GetComponentInChildren<TextMeshProUGUI>();
            barNum.text = "bar " + i.ToString();
            Instantiate(_bar, new Vector3(0f, 640f * i, 0f), Quaternion.identity, _bars.transform);
        }
    }

    private void MakeNotes()
    {
        // _xml.tracks�� ������ Note�� ����
        for (int i = 0; i < 4; i++)
        {
            foreach (int tick in _xml.tracks[i])
            {
                float x = -240f + (160f * i);
                float y = -320f + tick * hpt;

                if (i == 0 || i == 3)
                {
                    Instantiate(_noteBlue, new Vector3(x, y, 0f), Quaternion.identity, _notes.transform);
                }
                else
                {
                    Instantiate(_noteOrange, new Vector3(x, y, 0f), Quaternion.identity, _notes.transform);
                }
            }
        }
    }
}
