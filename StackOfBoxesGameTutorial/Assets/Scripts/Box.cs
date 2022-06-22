using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private bool isKicked;
    [SerializeField] private Transform truckStackPoint;

    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public bool IsKicked { get { return isKicked; } set { isKicked = value; } }

    private void Update()
    {
        if(isKicked)
        {
            Debug.Log(gameObject.name + " kutusu ýsKicked: " + isKicked);
            transform.parent = truckStackPoint;

            rigidbody.isKinematic = false;

            Vector3 truckStuckPointPosition = truckStackPoint.position;
            //Debug.Log(gameObject.name + " Slerp Value: " + Vector3.Slerp(transform.position, truckStuckPointPosition, Time.deltaTime * 25.0f));
            //transform.position = Vector3.MoveTowards(transform.position, truckStuckPointPosition, 5.0f * Time.deltaTime);
            rigidbody.AddForce(Vector3.forward * 750.0f);
        }
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

            Stack.instance.PrevObject = transform.parent.GetChild(index - 1);
        }
    }



}
