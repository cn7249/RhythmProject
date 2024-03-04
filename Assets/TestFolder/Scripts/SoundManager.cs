using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource audioSource;
    private AudioClip audioClip;

    private void Start()
    {
        audioClip = Resources.Load($"Musics/{InGameManager.instance.songXML}") as AudioClip;
        audioSource.clip = audioClip;

        Instance = this;
    }

    public void PlaySource()
    {
        audioSource.Play();

        StartCoroutine(SongEndShowUI(audioSource.clip.length));
        Debug.Log(audioSource.clip.length);
    }

    IEnumerator SongEndShowUI(float time)
    {
        yield return new WaitForSeconds(time);

        UIManager.Instance.ShowUI<UIResultBoard>();
    }
}
