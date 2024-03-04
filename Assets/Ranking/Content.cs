using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Content : MonoBehaviour
{
    [SerializeField] private Text rank;
    [SerializeField] private Text userName;
    [SerializeField] private Text score;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetInform(int rank, string userName, int score)
    {
        this.rank.text = rank.ToString();
        this.userName.text = userName;
        this.score.text = score.ToString();
    }
}
