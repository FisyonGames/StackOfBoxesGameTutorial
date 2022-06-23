using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private bool isKicked;

    private Transform truckBedToStack;
    private Rigidbody rigidbody;

    private Vector3 targetPositionToLerp;
    private float lerpSpeed = 5.0f;
    private float lerpDuration = 1.0f;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        truckBedToStack = GameObject.FindGameObjectWithTag("TruckBedToStack").transform;
    }

    public bool IsKicked 
    { 
        get { return isKicked; } 
        set 
        { 
            isKicked = value;
            SetValuesBeforeStackToTruckBed();
        } 
    }

    private void FixedUpdate()
    {
        if(isKicked)
        {
            //transform.position = Vector3.Lerp(transform.position, targetPositionToLerp, lerpSpeed * Time.deltaTime);
            StartCoroutine(LerpPosition(targetPositionToLerp, lerpDuration));
        }
    }

    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;
        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += lerpSpeed * Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        isKicked = false;
    }

    void OnTriggerEnter(Collider obj)
    {
        if(obj.tag == "Obstacle")
        {
            int index = transform.GetSiblingIndex();
            
            for (int i = index; i < transform.parent.childCount; i++)
            {
                Destroy(transform.parent.GetChild(i).gameObject);
            }
        }
    }

    void SetValuesBeforeStackToTruckBed()
    {
        float zTargetValueToLerp = truckBedToStack.childCount / 8;
        float yTargetValueToLerp = (truckBedToStack.childCount % 8) / 4;
        float xTargetValueToLerp = (truckBedToStack.childCount % 8) % 4;

        targetPositionToLerp = new Vector3( truckBedToStack.position.x + xTargetValueToLerp * transform.lossyScale.x,
                                            truckBedToStack.position.y + yTargetValueToLerp * transform.lossyScale.y,
                                            truckBedToStack.position.z - zTargetValueToLerp * transform.lossyScale.z
                                          );
        
        transform.parent = truckBedToStack;
    }

}
