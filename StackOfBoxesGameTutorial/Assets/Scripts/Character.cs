using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    private void OnTriggerEnter(Collider coll)
	{
		if(coll.tag == "Box")
		{
			Stack.instance.PickUp(coll.gameObject.transform);
            Debug.Log("Box Trigger");
		}
        if(coll.tag == "EndOfTrack")
		{
			AnimationAndMovementController.instance.IsInEndOfTrack = true;
		}
	}

}
