using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridBtnBehaviour : MonoBehaviour, IPointerDownHandler
{
    private BarBehaviour _currentBarScript;
    private Vector3 _pos;

    private void Awake()
    {
        _currentBarScript = GetComponentInParent<BarBehaviour>();
        _pos = this.transform.localPosition;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 좌클릭 시 노트 생성
            PatternManager.Instance.CreateSingleNote(_currentBarScript.CurrentBarNum, _pos.x, _pos.y);
        }
    }
}
