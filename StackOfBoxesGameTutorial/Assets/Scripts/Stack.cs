using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    public static Stack instance;

    float distanceBetweenObjects;
    [SerializeField] private Transform previousObject;
    [SerializeField] private Transform parent;

    public Transform PreviousObject { get {return previousObject; }  set { previousObject = value;} }

    private void Awake()
    {
        if(instance == null) instance = this;
    }

    void Start()
    {
        distanceBetweenObjects = previousObject.localScale.y;
    }
    private void Update()
    {

    }
    public void PickUp(Transform pickedObject)
    {
        previousObject = Boxes.instance.transform.GetChild(Boxes.instance.transform.childCount - 1);

        pickedObject.parent = parent;

        Vector3 desPos = previousObject.localPosition;
        desPos.y += distanceBetweenObjects;

        pickedObject.localPosition = desPos;
        pickedObject.localRotation = previousObject.localRotation;
        pickedObject.GetComponent<Rigidbody>().isKinematic = true;

        previousObject = pickedObject;
    }

    
}
