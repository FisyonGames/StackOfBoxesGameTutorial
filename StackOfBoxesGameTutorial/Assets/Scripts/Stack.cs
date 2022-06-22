using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    public static Stack instance;

    float distanceBetweenObjects;
    [SerializeField] private Transform previousObject;
    [SerializeField] private Transform parent;

    public Queue<Transform> stackedBoxes;

    public Transform PrevObject{ get {return previousObject; }  set { previousObject = value;} }

    private void Awake()
    {
        if(instance == null) instance = this;

        stackedBoxes = new Queue<Transform>();
        stackedBoxes.Enqueue(previousObject);
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
        pickedObject.parent = parent;

        stackedBoxes.Enqueue(pickedObject);

        Vector3 desPos = previousObject.localPosition;
        desPos.y += distanceBetweenObjects;

        pickedObject.localPosition = desPos;
        pickedObject.localRotation = previousObject.localRotation;
        pickedObject.GetComponent<Rigidbody>().isKinematic = true;

        previousObject = pickedObject;
    }

    
}
