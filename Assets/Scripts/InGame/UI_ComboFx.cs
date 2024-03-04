using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_ComboFX : MonoBehaviour
{
    [SerializeField] private GameObject comboBox;
    private TextMeshProUGUI tmp;

    private int combo;
    private int before;

    private void Awake()
    {
        tmp = comboBox.GetComponent<TextMeshProUGUI>();
        comboBox.SetActive(false);
        combo = 0;
        before = -1;
    }

    private void SetComboActive()
    {
        comboBox.SetActive(false);
        tmp.text = combo.ToString();
        comboBox.SetActive(true);
    }

    private void Update()
    {
        combo = InGameManager.instance.combo;
        CheckCombo();
    }

    private void CheckCombo()
    {
        if (combo > 0 && combo != before)
        {
            SetComboActive();
            before = combo;
        }
    }
}