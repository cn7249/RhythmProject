using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridController : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    [SerializeField] private Transform _grid;
    private Vector2 defaultPos;
    private Vector2 startingPos;
    private Vector2 moveOffset;

    private float mouseScroll;

    private void Start()
    {

    }

    private void Update()
    {
        UpdateGridScale();
    }

    // ���콺 �ٷ� Grid Ȯ��,���
    private void UpdateGridScale()
    {
        mouseScroll = Input.GetAxis("Mouse ScrollWheel");
        _grid.localScale += new Vector3(0f, mouseScroll, 0f);
    }

    // Grid Ŭ�� ��
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        defaultPos = _grid.position;
        startingPos = eventData.position;
    }

    // �巡�� ���� ��
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        moveOffset = eventData.position - startingPos;
        _grid.position = new Vector2(0f, defaultPos.y + moveOffset.y);
    }

    
}
