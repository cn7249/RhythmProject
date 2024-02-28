using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadUI : MonoBehaviour
{
    [SerializeField] private Button _saveBtn;
    [SerializeField] private Button _loadBtn;

    private void Awake()
    {
        _saveBtn.onClick.AddListener(() => SaveXmlBtn());
        _loadBtn.onClick.AddListener(() => LoadXmlBtn());
    }

    public void SaveXmlBtn()
    {
        PatternManager.Instance.SaveXmlSequence();
    }

    public void LoadXmlBtn()
    {
        PatternManager.Instance.LoadXmlSequence();
    }
}
