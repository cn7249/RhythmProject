using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIContent : UIBase
{
    private Text rank;
    private Text userName;
    private Text score;

    protected override void Init()
    {
        rank = Util.FindChild<Text>(gameObject, "Rank");
        userName = Util.FindChild<Text>(gameObject, "UserName");
        score = Util.FindChild<Text>(gameObject, "Score");
    }

    public void SetInform(int rank, string userName, int score)
    {
        this.rank.text = rank.ToString();
        this.userName.text = userName;
        this.score.text = score.ToString();
    }
}
