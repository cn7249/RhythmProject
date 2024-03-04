using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SingletoneBase<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T instance;

    public static T Instance
    {
        get 
        {
            if(instance == null)
            {
                string typeName = typeof(T).FullName;
                GameObject go = new GameObject(typeName);
                instance = go.AddComponent<T>();
            }

            return instance;
        }
    }



    private void Awake()
    {
        Init();
    }

    public virtual void Init()
    {

    }
}
