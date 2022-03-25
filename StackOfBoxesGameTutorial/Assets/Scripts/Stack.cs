using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    public static Stack instance;

    float distanceBetweenObjects;
    [SerializeField] private Transform prevObject;
    [SerializeField] private Transform parent;

    private void Awake()
    {
        if(instance == null) instance = this;
    }

    void Start()
    {
        distanceBetweenObjects = prevObject.localScale.y;
    }

    public void PickUp(GameObject pickedObject, bool needTag = false, string tag = null, bool downOrUp = true)
    {
        if(needTag)
        {
            pickedObject.tag = tag;
        }

        pickedObject.transform.parent = parent;
        Vector3 desPos = prevObject.localPosition;
        desPos.y += downOrUp ? distanceBetweenObjects : -distanceBetweenObjects;

        pickedObject.transform.localPosition = desPos;

        prevObject = pickedObject.transform;
    }

    
}
