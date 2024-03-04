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
        private MusicData curMusicData;

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
            _controller.ClickOnce(_musicData);

            if (curMusicData == _musicData)
            {
                SceneManager.LoadScene("InGameScene");
                return;
            }
            curMusicData = _musicData;
        }
    }
}
