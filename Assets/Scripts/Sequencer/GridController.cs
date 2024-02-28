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

    // 마우스 휠로 Grid 확대,축소
    private void UpdateGridScale()
    {
        mouseScroll = Input.GetAxis("Mouse ScrollWheel");
        _grid.localScale += new Vector3(0f, mouseScroll, 0f);
    }

    // Grid 클릭 시
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        defaultPos = _grid.position;
        startingPos = eventData.position;
    }

    // 드래그 중일 때
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        moveOffset = eventData.position - startingPos;
        _grid.position = new Vector2(0f, defaultPos.y + moveOffset.y);
    }

    
}
