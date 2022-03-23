using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAndMovementController : MonoBehaviour
{
    [SerializeField] [Range(5,25)] private float movementSpeed = 5.0f;
    [SerializeField] [Range(5,25)] private float speedForLeftRightMovement = 5.0f;

    void Start()
    {

    }
    
    void Update()
    {
        //transform.position += Vector3.forward * movementSpeed * Time.deltaTime;

        if(Input.GetKey(KeyCode.LeftArrow) || MobileInput.Instance.swipeLeft)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speedForLeftRightMovement);
        }
        if(Input.GetKey(KeyCode.RightArrow) || MobileInput.Instance.swipeRight)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speedForLeftRightMovement);
        }

        // Eğer yan engeller yoksa...
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -4.1f, 4.1f);
        transform.position = clampedPosition;
    }
}
