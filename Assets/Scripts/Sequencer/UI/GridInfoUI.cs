using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GridInfoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentBar;
    [SerializeField] private TextMeshProUGUI _totalBar;
    [SerializeField] private TextMeshProUGUI _currentScale;

    private void FixedUpdate()
    {
        _currentBar.text = PatternManager.Instance.GetCurrentBar.ToString();
        _totalBar.text = PatternManager.Instance.GetTotalBar.ToString();
        _currentScale.text = (PatternManager.Instance.GetGridScale * 100).ToString("N0") + "%";
    }

}
