using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using IntroUIScene.MusicSelectController;

namespace IntroUIScene
{
    public class AudioManager : MonoBehaviour
    {
        private AudioSource _audioSource;
        private AudioClip audioClip;
        private MusicSelectController _musicData;
    
        // Start is called before the first frame update
        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            audioClip = Resources.Load<AudioClip>($"{_musicData.musicDatas}");
            _audioSource.PlayOneShot(audioClip, 0.7f);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        
        
    }
}
