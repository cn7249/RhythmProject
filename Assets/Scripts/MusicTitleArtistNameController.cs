using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using IntroUIScene;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;


namespace IntroUIScene // 폴더링, 그룹화 역할 표면상
{
    
    public class MusicTitleArtistNameController : MonoBehaviour
    {
        [SerializeField] private Image albumImage;
        [SerializeField] private TMP_Text musicTitle;
        [SerializeField] private TMP_Text artistName;
        private Sprite imageSource;
        private MusicData _musicData;
        private MusicSelectController _controller;
        private string curMusicData;
        private int count;

        public void Init(MusicData data, MusicSelectController controller)
        {
            _controller = controller;
            _musicData = data;
            imageSource = Resources.Load<Sprite>($"{data.ImgPathInfo}");
            albumImage.sprite = imageSource;
            musicTitle.text = data.MusicTitle;
            artistName.text = data.ArtistName;
            
        }

        public void ButtonClickFunction()
        {
            var song = _controller.ClickOnce(_musicData);
            count++;
            if (curMusicData == song && count == 2)
            {
                SceneManager.LoadScene("InGameScene");
                return;
            }
            else if (curMusicData != song)
            {
                count = 0;
            }
            curMusicData = song;
        }
    }
}
