using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeInputKeyUI : MonoBehaviour
{
    [SerializeField] public List<Text> notes;

    public void UpdateUI(int index, string key)
    {
        switch (index)
        {
            case 0:
                notes[0].text = key;
                break;

            case 1:
                notes[1].text = key; 
                break;

            case 2:
                notes[2].text = key;
                break;

            case 3:
                notes[3].text = key;
                break;
        }
    }
}
