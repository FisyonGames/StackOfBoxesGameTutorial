using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAndMovementController : MonoBehaviour
{
    public static AnimationAndMovementController instance;

    [SerializeField] private Animator characterAnimator;
    [SerializeField] [Range(5,25)] private float movementSpeed = 5.0f;
    [SerializeField] [Range(5,25)] private float speedForLeftRightMovement = 5.0f;
    [SerializeField] private float leftClampXPositionValue = -3.0f;
    [SerializeField] private float rightClampXPositionValue = 3.0f;
    private bool isInEndOfTrack = false;
    private bool isMoving = false;
    private bool isKicking = false;

    public bool IsInEndOfTrack { get{ return isInEndOfTrack; } set { isInEndOfTrack = value;}}

    private void Awake()
    {
        if(instance == null) instance = this;
    }

    void Start()
    {
        isMoving = false;
        isInEndOfTrack = false;
        isKicking = false;
    }
    
    void Update()
    {
        // İlk hareket için ekrana veya klavye-mouse için herhangi bir tuşa basılacak.
        if (Input.touchCount > 0 || Input.anyKeyDown)
        {
            isMoving = true;
        }

        if(isMoving)
        {
            if(!characterAnimator.GetBool("isMoving")) characterAnimator.SetBool("isMoving", true);
            Movement();
        }
        if(isInEndOfTrack)
        {
            if(isMoving) isMoving = false;
            characterAnimator.SetBool("isMoving", false);
            transform.position = Vector3.MoveTowards (transform.position, new Vector3(0f, transform.position.y, transform.position.z), speedForLeftRightMovement * Time.deltaTime);
            if(transform.position.x == 0f) isKicking = true;
        }
        if(isKicking)
        {
            characterAnimator.SetBool("isKicking", true);
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
