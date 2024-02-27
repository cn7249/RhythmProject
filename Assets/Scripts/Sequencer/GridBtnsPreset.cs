using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBtnsPreset : MonoBehaviour
{
    [SerializeField] private GameObject _beat4;
    private GameObject _gridBtn;

    private void Awake()
    {
        _gridBtn = Resources.Load<GameObject>("Prefabs/Sequencer/GridBtn");
    }

    private void Start()
    {
        MakeBeatGrid();
    }

    private void MakeBeatGrid()
    {

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                float x = -240f + (160f * i);
                float y = -320f + (160f * j);
                Vector3 pos = new Vector3(x, y, 0f);

                Instantiate(_gridBtn, pos, Quaternion.identity, _beat4.transform);
            }
        }
    }
}
