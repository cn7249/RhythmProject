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

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        good = GameManager.instance.good;
        perfect = GameManager.instance.perfect;
        judgePosY = GameManager.instance.judgePosY;
    }

    public void JudgeNote(int index)
	{
		var queue = GameManager.instance.queues[index];
		// 최소 판정 범위 안에 노트가 없으면 리턴
        if (queue.Peek().gameObject.transform.position.y >= minJudgeArea)
        {
			Debug.Log("리턴");
            return;
        }
		// good 판정 범위 안에 노트가 있으면
		var obj = queue.Dequeue();
        float objY = obj.GetComponent<NoteBehaviour>().beginPos - judgePosY;

        if (objY > -good * GameManager.instance.gameSpeed && objY < good * GameManager.instance.gameSpeed)
		{
            // perfect 판정 범위 안에 노트가 있으면 perfect 판정
            if (objY > -perfect * GameManager.instance.gameSpeed && objY < perfect * GameManager.instance.gameSpeed)
            {
                // to do perfect
                GameManager.instance.JudgementPerfect();
            }
			// good 판정
			else
			{
                // to do good
                GameManager.instance.JudgementGood();
            }
		}
		// bad 판정
		else
		{
            // to do bad
            GameManager.instance.JudgementBad();
        }

        Destroy(obj);
	}
}
