using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    public static Stack instance;

    float distanceBetweenObjects;
    [SerializeField] private Transform prevObject;
    [SerializeField] private Transform parent;

    public Transform PrevObject{ get {return prevObject;}  set {prevObject = value;} }

    private void Awake()
    {
        if(instance == null) instance = this;
    }

    void Start()
    {
        distanceBetweenObjects = prevObject.localScale.y;
    }

    public void PickUp(GameObject pickedObject)
    {
        pickedObject.transform.parent = parent;
        Vector3 desPos = prevObject.localPosition;
        desPos.y += distanceBetweenObjects;

        pickedObject.transform.localPosition = desPos;

        prevObject = pickedObject.transform;
    }

    
}
