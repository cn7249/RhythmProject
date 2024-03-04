using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : SingletoneBase<UIManager>
{
    Dictionary<string, GameObject> UIDictionary = new Dictionary<string, GameObject>();


    public override void Init()
    {
        UIDictionary.Add("UIRankingBoard", Util.Instantiate<UIRankingBoard>("Prefabs/UI", transform));
        UIDictionary.Add("UIResultBoard", Util.Instantiate<UIResultBoard>("Prefabs/UI", transform));

        CloseUI<UIRankingBoard>();
        CloseUI<UIResultBoard>();
    }

    public GameObject GetUI<T>() where T : UIBase
    {
        string UIName = typeof(T).Name;

        return UIDictionary[UIName];
    }

    public void ShowUI<T>() where T : UIBase
    {
        string UIName = typeof(T).Name;

        if (UIDictionary.ContainsKey(typeof(T).Name))
        {
            UIDictionary[UIName].GetComponent<T>().OpenUI();
        }
    }

    public void CloseUI<T>() where T : UIBase
    {
        string UIName = typeof(T).Name;
        UIDictionary[UIName].GetComponent<T>().CloseUI();
    }
}
