using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_JudgeFXs : MonoBehaviour
{
    private Animation anim;

    private void Awake()
    {
        anim = GetComponent<Animation>();
    }

    private void OnEnable()
    {
        anim.Play();
    }
}
