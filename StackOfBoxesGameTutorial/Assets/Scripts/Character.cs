using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider coll)
	{
		if(coll.tag == "Box")
		{
			Stack.instance.PickUp(coll.gameObject, true, "Untagged");
		}
        if(coll.tag == "EndOfTrack")
		{
			AnimationAndMovementController.instance.IsInEndOfTrack = true;
		}
	}
}
