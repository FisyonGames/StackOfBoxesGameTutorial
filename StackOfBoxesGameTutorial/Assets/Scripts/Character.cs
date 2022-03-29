using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Transform parentBoxes;
    void Start()
    {
        
    }

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
        if(coll.tag == "Obstacle")
		{
			DestroyBoxes();
		}
	}

    private void DestroyBoxes()
    {
        for (int i = 0; i < parentBoxes.childCount; i++)
        {
            
        }
    }
}
