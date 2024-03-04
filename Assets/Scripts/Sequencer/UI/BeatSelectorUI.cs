using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BeatSelectorUI : MonoBehaviour
{
    [SerializeField] private Button _beat4Btn;
    [SerializeField] private Button _beat8Btn;
    [SerializeField] private Button _beat12Btn;
    [SerializeField] private Button _beat16Btn;

    private TextMeshProUGUI _beat4Txt;
    private TextMeshProUGUI _beat8Txt;
    private TextMeshProUGUI _beat12Txt;
    private TextMeshProUGUI _beat16Txt;

    private void Awake()
    {
        _beat4Btn.onClick.AddListener(() => SelectBeat4());
        _beat8Btn.onClick.AddListener(() => SelectBeat8());
        _beat12Btn.onClick.AddListener(() => SelectBeat12());
        _beat16Btn.onClick.AddListener(() => SelectBeat16());

        _beat4Txt = _beat4Btn.GetComponentInChildren<TextMeshProUGUI>();
        _beat8Txt = _beat8Btn.GetComponentInChildren<TextMeshProUGUI>();
        _beat12Txt = _beat12Btn.GetComponentInChildren<TextMeshProUGUI>();
        _beat16Txt = _beat16Btn.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void SelectBeat4()
    {
        PatternManager.Instance.BeatType = BeatType.beat4;
        SetAllTextDefault();
        _beat4Txt.color = Color.green;
    }

    private void SelectBeat8()
    {
        PatternManager.Instance.BeatType = BeatType.beat8;
        SetAllTextDefault();
        _beat8Txt.color = Color.green;
    }

    private void SelectBeat12()
    {
        PatternManager.Instance.BeatType = BeatType.beat12;
        SetAllTextDefault();
        _beat12Txt.color = Color.green;
    }

    private void SelectBeat16()
    {
        PatternManager.Instance.BeatType = BeatType.beat16;
        SetAllTextDefault();
        _beat16Txt.color = Color.green;
    }

    private void SetAllTextDefault()
    {
        _beat4Txt.color = Color.white;
        _beat8Txt.color = Color.white;
        _beat12Txt.color = Color.white;
        _beat16Txt.color = Color.white;
    }
}
