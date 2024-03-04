using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRankingBoard : UIBase
{
    private Button closeButton;

    protected override void Init()
    {
        closeButton = Util.FindChild<Button>(gameObject, "CloseButton");

        closeButton.onClick.AddListener(CloseUI);

    }
}
