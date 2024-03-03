using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
	
	public int index;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var obj = collision.gameObject;
        if (obj.CompareTag("    "))
        {
            GameManager.instance.queues[index].Enqueue(obj);
            Debug.Log("en");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var obj = collision.gameObject;
        if (obj.CompareTag("Note"))
        {
            GameManager.instance.queues[index].Dequeue();
            // todo bad, destroy
            Debug.Log("de");
        }
    }
}
