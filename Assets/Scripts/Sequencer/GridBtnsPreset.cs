using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBtnsPreset : MonoBehaviour
{
    [SerializeField] private GameObject _beat4;
    [SerializeField] private GameObject _beat8;
    [SerializeField] private GameObject _beat12;
    [SerializeField] private GameObject _beat16;

    private GameObject _gridBtn;
    private GameObject _line;

    private void Awake()
    {
        _gridBtn = Resources.Load<GameObject>("Prefabs/Sequencer/GridBtn");
        _line = Resources.Load<GameObject>("Prefabs/Sequencer/Line");
    }

    private void Start()
    {
        MakeBeatGrid(4f, _beat4.transform);
        MakeBeatGrid(8f, _beat8.transform);
        MakeBeatGrid(12f, _beat12.transform);
        MakeBeatGrid(16f, _beat16.transform);
        SetAllPresetsActive(false);
    }

    private void MakeBeatGrid(float beat, Transform parent)
    {
        float height = 640f / beat;

        // beat 수에 맞춰 Line과 GridBtn 생성
        for (int i = 0; i < beat; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                float x = -240f + (160f * j);
                float y = -320f + (height * i);
                Vector3 pos = new Vector3(x, y, 0f);
                
                _gridBtn.transform.localScale = new Vector3(1f, 4f/ beat, 1f);

                Instantiate(_gridBtn, pos, Quaternion.identity, parent);
            }

            // 맨 아래 Line은 Grid에서 만들어져있으니 제외
            if (i > 0)
            {
                Instantiate(_line, new Vector3(0f, -320f + (height * i), 0f), Quaternion.identity, parent);
            }
        }
    }

    private void SetAllPresetsActive(bool isTrue)
    {
        _beat4.SetActive(isTrue);
        _beat8.SetActive(isTrue);
        _beat12.SetActive(isTrue);
        _beat16.SetActive(isTrue);
    }
}
