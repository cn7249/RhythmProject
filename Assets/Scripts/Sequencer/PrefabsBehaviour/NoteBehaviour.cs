using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NoteBehaviour : MonoBehaviour, IPointerDownHandler
{
    private Vector3 _pos;

    private void Awake()
    {
        _pos = this.transform.localPosition;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButtonDown(1))
        {
            // ��Ŭ�� �� ��Ʈ ����
            PatternManager.Instance.DeleteSingleNote(_pos.x, _pos.y, this.gameObject);
        }
    }
}
