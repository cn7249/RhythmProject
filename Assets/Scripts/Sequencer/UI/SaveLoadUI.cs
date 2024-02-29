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
        else // �� ���� ���� ��
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
            _noFileAlertTxt.SetActive(true); // ������ ������ ��� �ؽ�Ʈ ǥ��
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
