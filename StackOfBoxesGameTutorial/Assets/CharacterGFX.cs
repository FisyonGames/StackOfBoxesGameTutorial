using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGFX : MonoBehaviour
{
    public Transform boxes;
    public void Kick()
    {
        //Debug.Log("Tekme atıldı...");
        
        if(boxes.childCount != 0)
        {
            
            Debug.Log("boxes.GetChild(0).gameObject..." + boxes.GetChild(0).gameObject);
            boxes.GetChild(0).gameObject.GetComponent<Box>().IsKicked = true;
        }

    }
}
