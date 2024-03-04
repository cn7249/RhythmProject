using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    // TODO : ������Ʈ �������� �κ� ���� �ʿ�

    private void Start()
    {
        Init();
    }

    protected virtual void Init()
    {

    }

    public void OpenUI()
    {
        if (gameObject != null)
        {
            gameObject.SetActive(true);
        }
    }

    public void CloseUI()
    {
        if (gameObject != null)
        {
            gameObject.SetActive(false);
        }
    }
}
