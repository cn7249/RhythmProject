using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class Util
{

    public static GameObject Instantiate<T>(string path = null, Transform parent = null) where T : UIBase
    {
        if (string.IsNullOrEmpty(path))
            path = "Prefabs";

        string fileName = typeof(T).Name;

        GameObject prefab = Resources.Load<T>($"{path}/{fileName}").gameObject;

        GameObject go = Object.Instantiate(prefab, parent);
        go.name = fileName;

        return go;
    }

    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(go, name, recursive);
        if (transform == null)
            return null;

        return transform.gameObject;
    }

    public static T FindChild<T>(GameObject go, string componentName, bool isRecur = false) where T : UnityEngine.Object
    {
        if (go == null) return null;

        if (!isRecur)
        {
            for (int i = 0; i < go.transform.childCount; ++i)
            {
                Transform transform = go.transform.GetChild(i);
                if (transform.name == componentName)
                {
                    T component = transform.GetComponent<T>();
                    if (component != null)
                        return component;
                }
            }
        }
        else
        {
            foreach (T component in go.GetComponentsInChildren<T>())
            {
                if (componentName == component.name)
                    return component;
            }
        }

        return null;
    }

}