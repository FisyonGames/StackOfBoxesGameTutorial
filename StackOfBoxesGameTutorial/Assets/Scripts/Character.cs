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
		}
        if(coll.tag == "EndOfTrack")
		{
			GetComponent<BoxCollider>().enabled = false;
			AnimationAndMovementController.instance.IsInEndOfTrack = true;
		}
	}

}
