using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes : MonoBehaviour
{
    public static Boxes instance = null;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void SetNewPositionAfterKick()
    {
        foreach (Transform child in transform)
        {
            Vector3 pos = child.transform.localPosition;
            pos.y -= 1.0f;
            child.transform.localPosition = pos;
        }
    }

    public void KickAgainstBox()
    {
        if (transform.childCount != 0)
        {
            //if(transform.GetChild(0).tag == "Box") SetNewPositionAfterKick();
            transform.GetChild(0).gameObject.GetComponent<Box>().IsKicked = true;
            SetNewPositionAfterKick();
        }
    }
}
