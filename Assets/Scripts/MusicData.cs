using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IntroUIScene
{
    [Serializable]
    public class MusicData // 만들어져야 아래도 만들어진다.
    {
        public string ArtistName;
        public string MusicTitle;
        public string ImgPathInfo;
        public string MusicPathInfo;

        public MusicData(string artistName, string musicTitle, string imgPathInfo, string musicPathInfo) // 생성자
        {
            ArtistName = artistName;
            MusicTitle = musicTitle;
            ImgPathInfo = imgPathInfo;
            MusicPathInfo = musicPathInfo;
        }
        
    }
    
}
