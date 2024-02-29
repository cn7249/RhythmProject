using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using IntroUIScene;

namespace IntroUIScene // 폴더링, 그룹화 역할 표면상
{
    
    public class MusicTitleArtistNameController : MonoBehaviour
    {
        [SerializeField] private Image albumImage;
        [SerializeField] private TMP_Text musicTitle;
        [SerializeField] private TMP_Text artistName;
        private Sprite imageSource;
        private int clickCount = 0;
        private MusicData _musicData;
        private MusicSelectController _controller;
        public void Init(MusicData data, MusicSelectController controller)
        {
            _controller = controller;
            _musicData = data;
            imageSource = Resources.Load<Sprite>($"{data.ImgPathInfo}");
            Debug.Log($"{data.ImgPathInfo}");
            albumImage.sprite = imageSource;
            musicTitle.text = data.MusicTitle;
            artistName.text = data.ArtistName;
        }

        public void ButtonClickFunction()
        {
            
                clickCount++;
               
                
                if (clickCount == 1)
                {
                    _controller.ClickOnce(_musicData);
                }
                else if (clickCount == 2)
                {
                    // 게임실행함수 입력
                    clickCount = 0;
                }
            
        }
    }
}
