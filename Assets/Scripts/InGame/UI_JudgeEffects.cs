using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_JudgeEffects : MonoBehaviour
{
    [SerializeField] private GameObject perfectFX;
    [SerializeField] private GameObject goodFX;
    [SerializeField] private GameObject badFX;

    private void Awake()
    {
        SetAllFXsDeactivate();
    }

    public void SetActivePerfectFX()
    {
        SetAllFXsDeactivate();
        perfectFX.SetActive(true);
    }

    public void SetActiveGoodFX()
    {
        SetAllFXsDeactivate();
        goodFX.SetActive(true);
    }

    public void SetActiveBadFX()
    {
        SetAllFXsDeactivate();
        badFX.SetActive(true);
    }

    private void SetAllFXsDeactivate()
    {
        perfectFX.SetActive(false);
        goodFX.SetActive(false);
        badFX.SetActive(false);
    }

    
}
