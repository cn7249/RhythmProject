using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPreset : MonoBehaviour
{
    // Beat �Է� ������ �������Դϴ�. �ʿ��ϸ� ���ø� �˴ϴ�.

    private GameObject _gridBtn;
    private GameObject _line;

    private void Awake()
    {
        _gridBtn = Resources.Load<GameObject>("Prefabs/Sequencer/GridBtn");
        _line = Resources.Load<GameObject>("Prefabs/Sequencer/Line");
    }

    public void MakeBeatGrid(float beat, Transform parent)
    {
        float height = 640f / beat;

        // beat ���� ���� Line�� GridBtn ����
        for (int i = 0; i < beat; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                float x = -240f + (160f * j);
                float y = -320f + (height * i);
                Vector3 pos = new Vector3(x, y, 0f);

                _gridBtn.transform.localScale = new Vector3(1f, 4f / beat, 1f);

                Instantiate(_gridBtn, pos, Quaternion.identity, parent);
            }

            // �� �Ʒ� Line�� Grid���� ������������� ����
            if (i > 0)
            {
                Instantiate(_line, new Vector3(0f, -320f + (height * i), 0f), Quaternion.identity, parent);
            }
        }
    }
}
