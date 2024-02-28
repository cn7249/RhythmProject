using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

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

    private int tpm; // Default = 1536 ticks per 1 bar
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
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        
    }

    public void SaveXmlSequence()
    {
        _xml.SaveXML();
    }

    public void LoadXmlSequence()
    {
        DestroyAllLoadedObjects();
        LoadDefaultSettings();
        _xml.LoadXML();
        InitParameters();
        MakeBars();
        MakeNotes();
    }

    private void InitParameters()
    {
        tpm = _xml.songInfos.tpm;
        totalBar = _xml.songInfos.endTick / tpm;
        hpt = 640f / tpm;
    }

    public void CreateSingleNote(int barNum, float xPos, float yPos)
    {
        // GridBtnBehaviour.cs 에서 호출

        int index = (int)((xPos + 240f) / 160f);
        int tick = (int)((yPos + 320f) * (1 / hpt) + (tpm * barNum));
        bool isNoteExists = _xml.tracks[index].Contains(tick);

        if (!isNoteExists)
        {
            float yScale = _grid.transform.localScale.y;
            float yOffset = _grid.transform.position.y;
            float y = (yPos + 640f * barNum) * yScale + yOffset;

            switch (index)
            {
                case 0: // 1번 트랙
                    Instantiate(_noteBlue, new Vector3(xPos, y, 0f), Quaternion.identity, _notes.transform);
                    break;
                case 1: // 2번 트랙
                    Instantiate(_noteOrange, new Vector3(xPos, y, 0f), Quaternion.identity, _notes.transform);
                    break;
                case 2: // 3번 트랙
                    Instantiate(_noteOrange, new Vector3(xPos, y, 0f), Quaternion.identity, _notes.transform);
                    break;
                case 3: // 4번 트랙
                    Instantiate(_noteBlue, new Vector3(xPos, y, 0f), Quaternion.identity, _notes.transform);
                    break;
            }

            _xml.tracks[index].Add(tick);
        }

    }

    public void DeleteSingleNote(float xPos, float yPos, GameObject note)
    {
        // NoteBehaviour.cs 에서 호출

        int index = (int)((xPos + 240f) / 160f);
        int tick = (int)((yPos + 320f) * (1 / hpt));
        bool isNoteExists = _xml.tracks[index].Contains(tick);

        if (isNoteExists)
        {
            _xml.tracks[index].Remove(tick);
            Destroy(note);
        }
    }

    private void MakeBars()
    {
        // _xml.songinfos의 정보로 Bar를 생성
        for (int i = 0; i < totalBar; i++)
        {
            TextMeshProUGUI barNum = _bar.GetComponentInChildren<TextMeshProUGUI>();
            barNum.text = "bar " + i.ToString();
            Instantiate(_bar, new Vector3(0f, 640f * i, 0f), Quaternion.identity, _bars.transform);
        }
    }

    private void MakeNotes()
    {
        // _xml.tracks의 정보로 Note를 생성
        for (int i = 0; i < 4; i++)
        {
            foreach (int tick in _xml.tracks[i])
            {
                float x = -240f + (160f * i);
                float y = -320f + tick * hpt;

                if (i == 0 || i == 3) // 1번, 4번 트랙은 파란색 노트 생성
                {
                    Instantiate(_noteBlue, new Vector3(x, y, 0f), Quaternion.identity, _notes.transform);
                }
                else // 2번, 3번 트랙은 주황색 노트 생성
                {
                    Instantiate(_noteOrange, new Vector3(x, y, 0f), Quaternion.identity, _notes.transform);
                }
            }
        }
    }

    private void DestroyAllLoadedObjects()
    {
        // 불러온 모든 note와 bar 제거

        if (_bars.transform.childCount != 0) // _bars 에게 자식이 있다면
        {
            Transform[] allBars = _bars.GetComponentsInChildren<Transform>();

            foreach (Transform child in allBars)
            {
                if (child.name == _bars.name) // _bars 자기 자신은 제외
                    continue;

                Destroy(child.gameObject);
            }
        }

        if (_notes.transform.childCount != 0) // _notes 에게 자식이 있다면
        {
            Transform[] allNotes = _notes.GetComponentsInChildren<Transform>();

            foreach (Transform child in allNotes)
            {
                if (child.name == _notes.name) // _notes 자기 자신은 제외
                    continue;

                Destroy(child.gameObject);
            }
        }

    }

    private void LoadDefaultSettings()
    {
        _grid.transform.position = Vector3.zero;
        _grid.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
