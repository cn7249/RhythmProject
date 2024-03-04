using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    // TODO : 컴포넌트 가져오는 부분 적용 필요

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
