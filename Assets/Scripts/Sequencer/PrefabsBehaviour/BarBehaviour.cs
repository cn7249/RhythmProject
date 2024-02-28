using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BarBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int CurrentBarNum // 현재 Bar의 순번을 return 합니다.
    { 
        get { return int.Parse(_currentBarTxt.text.Replace("bar ", "")); }
    }

    private Image _barImage;
    private TextMeshProUGUI _currentBarTxt;
    private GameObject _beat4;
    private GameObject _beat8;
    private GameObject _beat12;
    private GameObject _beat16;

    private UnityEngine.Color redColor;
    private UnityEngine.Color defaultColor;
    private bool isPointerIn;
    private bool isPresetExists;


    private void Awake()
    {
        _barImage = GetComponentInChildren<Image>();
        _currentBarTxt = this.GetComponentInChildren<TextMeshProUGUI>();

        _beat4 = Resources.Load<GameObject>("Prefabs/Sequencer/InputPresets/Beat(4)");
        _beat8 = Resources.Load<GameObject>("Prefabs/Sequencer/InputPresets/Beat(8)");
        _beat12 = Resources.Load<GameObject>("Prefabs/Sequencer/InputPresets/Beat(12)");
        _beat16 = Resources.Load<GameObject>("Prefabs/Sequencer/InputPresets/Beat(16)");

        redColor = new Vector4(150f / 255f, 72f / 255f, 72f / 255f, 134f / 255f);
        defaultColor = new Vector4(0f / 255f, 0f / 255f, 0f / 255f, 134f / 255f);
        isPointerIn = false;
        isPresetExists = false;
    }

    void Update()
    {
        SelectBar();
    }

    void SelectBar()
    {
        // 마우스 좌클릭 시 bar 선택
        if (Input.GetMouseButtonDown(0))
        {
            if (isPointerIn)
            {
                _barImage.color = redColor;
                CreatePreset();
            }
            else
            {
                _barImage.color = defaultColor;
                DestroyPreset();
            }
        }
    }

    void CreatePreset()
    {
        isPresetExists = this.transform.childCount > 3 ? true : false;

        if (!isPresetExists)
        {
            Instantiate(_beat4, this.transform);
            isPresetExists = true;
        }
    }

    void DestroyPreset()
    {
        if (isPresetExists)
        {
            Destroy(this.transform.GetChild(3).gameObject);
            isPresetExists = false;
        }
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        isPointerIn = true;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        isPointerIn = false;
    }
}
