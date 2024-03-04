using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    private AudioClip audioClip;

    private void Start()
    {
        audioClip = Resources.Load($"Musics/{InGameManager.instance.songXML}") as AudioClip;
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
