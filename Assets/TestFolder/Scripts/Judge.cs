using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Judge : MonoBehaviour
{
	public static Judge instance;

	public float minJudgeArea;

	private float judgePosY;
	private float good;
	private float perfect;

    private float speed;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        good = InGameManager.instance.good;
        perfect = InGameManager.instance.perfect;
        judgePosY = InGameManager.instance.judgePosY;

        speed = InGameManager.instance.gameSpeed;
    }

    public void JudgeNote(int index)
	{
		var queue = InGameManager.instance.queues[index];
		// 최소 판정 범위 안에 노트가 없으면 리턴
        if (queue.Peek().gameObject.transform.position.y >= minJudgeArea)
        {
			Debug.Log("리턴");
            return;
        }
		// good 판정 범위 안에 노트가 있으면
		var obj = queue.Dequeue();
        float objY = obj.transform.position.y - judgePosY;

        if (objY > -good * speed && objY < good * speed)
		{
            // perfect 판정 범위 안에 노트가 있으면 perfect 판정
            if (objY > -perfect * speed && objY < perfect * speed)
            {
                // to do perfect
                InGameManager.instance.JudgementPerfect();
            }
			// good 판정
			else
			{
                // to do good
                InGameManager.instance.JudgementGood();
            }
		}
		// bad 판정
		else
		{
            // to do bad
            InGameManager.instance.JudgementBad();
        }

        Destroy(obj);
	}


}
