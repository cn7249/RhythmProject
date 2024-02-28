using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum JudgeType
{
	Bad,
	Good,
	Perfect
}

public class Judge : MonoBehaviour
{
	// 플레이어가 노트 키 입력 시 호출
    public void JudgeNote()
	{
		// 최소 판정 범위 안에 노트가 없으면 리턴
		if (true)
			return;
		// good 판정 범위 안에 노트가 있으면
		if (true)
		{
			// perfect 판정 범위 안에 노트가 있으면 perfect 판정
			if (true)
			{
				// to do perfect
			}
			// good 판정
			else
			{
				// to do good
			}
		}
		// bad 판정
		else
		{
			// to do bad
		}
	}
}
