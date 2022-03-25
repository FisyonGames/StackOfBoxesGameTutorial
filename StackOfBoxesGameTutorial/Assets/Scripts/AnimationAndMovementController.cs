using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAndMovementController : MonoBehaviour
{
    public static AnimationAndMovementController instance;

    [SerializeField] [Range(5,25)] private float movementSpeed = 5.0f;
    [SerializeField] [Range(5,25)] private float speedForLeftRightMovement = 5.0f;
    [SerializeField] private float leftClampXPositionValue = -3.0f;
    [SerializeField] private float rightClampXPositionValue = 3.0f;
    private bool isInEndOfTrack = false;

    public bool IsInEndOfTrack { get{ return isInEndOfTrack; } set { isInEndOfTrack = value;}}

    private void Awake()
    {
        if(instance == null) instance = this;
    }

    void Start()
    {
        isInEndOfTrack = false;
    }
    
    void Update()
    {
        if(!isInEndOfTrack)
        {
            Movement();
        }
        else
        {
            transform.position = Vector3.MoveTowards (transform.position, new Vector3(0f, transform.position.y,transform.position.z), speedForLeftRightMovement * Time.deltaTime);
        }
    }

    private void Movement()
    {
        transform.position += Vector3.forward * movementSpeed * Time.deltaTime;

        if(Input.GetKey(KeyCode.LeftArrow) || MobileInput.Instance.swipeLeft)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speedForLeftRightMovement);
        }
        if(Input.GetKey(KeyCode.RightArrow) || MobileInput.Instance.swipeRight)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speedForLeftRightMovement);
        }

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, leftClampXPositionValue, rightClampXPositionValue);
        transform.position = clampedPosition;
    }
}
