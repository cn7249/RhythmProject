using System;
using System.Collections;
using System.Collections.Generic;using System.Net.Mime;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace IntroUIScene
{
    public class MusicSelectController : MonoBehaviour
    {
        
        public GameObject thumbnailTitleName;
        public Transform contentTransform;
        [SerializeField] private Image albumImage;
        [SerializeField] private TMP_Text musicTitle;
        [SerializeField] private TMP_Text artistName;
        private Sprite imageSource;
        private AudioSource _audioSource;
        private AudioClip audioClip;
        private MusicSelectController _musicData;

        private Button rankingButton;
        
        
        // Start is called before the first frame update
        void Start()
        {
            GetMusicData();
            _audioSource = GetComponent<AudioSource>();

            // Added By Kang
            rankingButton = Util.FindChild<Button>(gameObject, "RankingButton", true);
            rankingButton.onClick.AddListener(GameManager.Instance.Ranking.ShowRanking);
        }
        
        

        public string ClickOnce(MusicData data)
        {
            if (audioClip != null)
            {
                AudioStop();
            }
            imageSource = Resources.Load<Sprite>($"{data.ImgPathInfo}");
            Debug.Log($"{data.ImgPathInfo}");
            // audioSource = Resources.Load<>()
            albumImage.sprite = imageSource;
            musicTitle.text = data.MusicTitle;
            artistName.text = data.ArtistName;
            audioClip = Resources.Load<AudioClip>($"{data.MusicPathInfo}");
            _audioSource.PlayOneShot(audioClip, 0.7f);

            // 매니저에 곡 제목 전달
            string song = data.MusicPathInfo.Replace("Musics/", "");
            GameManager.Instance.Ranking.songName = song;
            GameManager.Instance.songName = song;

            return song;
        }

        public void AudioStop()
        {
            _audioSource.Stop();
        }

        private void GetMusicData()
        {
            foreach (var musicData in musicDatas)
            {
                Debug.Log($"아티스트: {musicData.ArtistName}, 음악 제목: {musicData.MusicTitle}, 이미지 경로: {musicData.ImgPathInfo}, 음악 경로: {musicData.MusicPathInfo}");
                
                // todo 프리팹 하나씩 만들기
                MusicTitleArtistNameController controller = Instantiate(thumbnailTitleName, contentTransform).GetComponent<MusicTitleArtistNameController>(); // instantiate 종류가 여러개 있다. 부모를 content로 잡아줘서 설정해주었다. 그러면 방향을 vector3로 넣지 않아도 된다.
                controller.Init(musicData, this);
                thumbnailTitleName.SetActive(true);
            }
            
        }
        

        public List<MusicData> musicDatas = new List<MusicData> // musicdata.cs 에서 만들게 아니라 여기서 만들어도됨
        {
            new MusicData("AOA", "단발머리", "Images/MusicImages/shortcut", "Musics/shortcut"),
        };
    }
    
}
