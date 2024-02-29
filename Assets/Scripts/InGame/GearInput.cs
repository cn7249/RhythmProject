using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GearInput : MonoBehaviour
{
    [SerializeField] private GameObject[] _lineLights;
    [SerializeField] private Image[] _keyImgs;

    private Color defaultColor;
    private Color activatedColor;

    private void Awake()
    {
        defaultColor = new Color(48f / 255f, 48f / 255f, 48f / 255f, 255f / 255f);
        activatedColor = new Color(28f / 255f, 202f / 255f, 255f / 255f, 128f / 255f);
    }

    private void Update()
    {
        KeyInput(0);
        KeyInput(1);
        KeyInput(2);
        KeyInput(3);
    }

    private void KeyInput(int idx)
    {
        if (Input.GetKey(SetKey(idx)))
        {
            _lineLights[idx].SetActive(true);
            _keyImgs[idx].color = activatedColor;
        }
        else
        {
            _lineLights[idx].SetActive(false);
            _keyImgs[idx].color = defaultColor;
        }
    }

    private KeyCode SetKey(int idx)
    {
        switch (idx)
        {
            case 0: return KeyCode.D;
            case 1: return KeyCode.F;
            case 2: return KeyCode.J;
            case 3: return KeyCode.K;
            default: return KeyCode.None;
        }
    }

}