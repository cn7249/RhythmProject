using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class NotePSBehaviour : MonoBehaviour, IPointerDownHandler
{
    private Vector3 _pos;

    public float beginPos;
    public float hps;
    public int index;
    private float good;
    private float judgePosY;
    private float gameSpeed;

    private Transform trans;

    private void Awake()
    {
        _pos = this.transform.localPosition;

        good = GameManager.instance.good;

        trans = this.gameObject.transform;
    }

    private void Start()
    {
        judgePosY = GameManager.instance.judgePosY;
        gameSpeed = GameManager.instance.gameSpeed;

        GameManager.instance.GameSpeedChange += ChangeSpeed;
    }

    private void OnDestroy()
    {
        GameManager.instance.GameSpeedChange -= ChangeSpeed;
    }

    private void Update()
    {
        float speed = hps * Time.deltaTime * gameSpeed;
        beginPos = trans.position.y;

        trans.position -= new Vector3(0f, speed, 0f);

        if (beginPos - judgePosY < - good * gameSpeed)
        {
            var queue = GameManager.instance.queues[index];
            if (this.gameObject == queue.Peek().gameObject)
            {
                var obj = queue.Dequeue();
                GameManager.instance.JudgementBad();
                Destroy(this.gameObject);
            }
        
        }
    }

    private void ChangeSpeed(float speed)
    {
        var posY = (beginPos - judgePosY) * speed / gameSpeed + judgePosY - beginPos;
        trans.position += new Vector3(0, posY, 0);
        gameSpeed = speed;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButtonDown(1))
        {
            // 우클릭 시 노트 제거
            PatternManager.Instance.DeleteSingleNote(_pos.x, _pos.y, this.gameObject);
        }
    }
}
