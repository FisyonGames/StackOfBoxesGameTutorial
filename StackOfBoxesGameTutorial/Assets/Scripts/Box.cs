using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
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
