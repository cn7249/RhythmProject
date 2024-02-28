using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField _nameInput;
    [SerializeField] private Button _saveBtn;
    [SerializeField] private Button _loadBtn;

    [SerializeField] private GameObject _noFileAlertTxt;
    [SerializeField] private GameObject _newFileSavedTxt;
    [SerializeField] private GameObject _fileSavedTxt;
    [SerializeField] private GameObject _fileLoadedTxt;

    private void Awake()
    {
        _saveBtn.onClick.AddListener(() => SaveXmlBtn());
        _loadBtn.onClick.AddListener(() => LoadXmlBtn());
    }

    public void SaveXmlBtn()
    {
        SetAllAlertsDeactivate();
        bool isExist = PatternManager.Instance.SaveXmlSequence(_nameInput.text);

        if (isExist)
        {
            _fileSavedTxt.SetActive(true);
        }
        else // 새 파일 생성 시
        {
            _newFileSavedTxt.SetActive(true);
        }
    }

    public void LoadXmlBtn()
    {
        SetAllAlertsDeactivate();
        bool isExist = PatternManager.Instance.LoadXmlSequence(_nameInput.text);

        if (isExist)
        {
            _fileLoadedTxt.SetActive(true);
        }
        else
        {
            _noFileAlertTxt.SetActive(true); // 파일이 없으면 경고 텍스트 표시
        }
    }

    private void SetAllAlertsDeactivate()
    {
        _noFileAlertTxt.SetActive(false);
        _newFileSavedTxt.SetActive(false);
        _fileSavedTxt.SetActive(false);
        _fileLoadedTxt.SetActive(false);
    }
}
