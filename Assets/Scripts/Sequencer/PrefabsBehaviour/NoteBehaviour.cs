using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class NoteBehaviour : MonoBehaviour, IPointerDownHandler
{
    private Vector3 _pos;

    public float posY;
    public float hps;
    public int index;
    private float good;
    private float judgePosY;
    private float gameSpeed = 1;

    private Transform trans;

    private void Awake()
    {
        _pos = this.transform.localPosition;

        good = InGameManager.instance.good;

        trans = this.gameObject.transform;

        judgePosY = InGameManager.instance.judgePosY;

        InGameManager.instance.GameSpeedChange += ChangeSpeed;
    }

    private void OnDestroy()
    {
        InGameManager.instance.GameSpeedChange -= ChangeSpeed;
    }

    private void Update()
    {
        float speed = hps * Time.deltaTime * gameSpeed;
        posY = trans.position.y;

        trans.position -= new Vector3(0f, speed, 0f);

        if (posY - judgePosY < - good * gameSpeed)
        {
            var queue = InGameManager.instance.queues[index];
            if (this.gameObject == queue.Peek().gameObject)
            {
                var obj = queue.Dequeue();
                InGameManager.instance.JudgementBad();
                Destroy(this.gameObject);
            }
        
        }
    }

    private void ChangeSpeed(float speed)
    {
        var posY = (this.posY - judgePosY) * speed / gameSpeed + judgePosY - this.posY;
        trans.position += new Vector3(0, posY, 0);
        gameSpeed = speed;
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
