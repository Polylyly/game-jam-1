using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;
    public float headRotateSpeed = 700f;
    
    public static ThirdPersonMovement instance;

    private bool InLeftHand;
    private bool InRightHand;
    private bool NearOven;

    //private bool eWithinDelay;

    private int eTotal = 0;
    public float maxDelay = .5f;
    public float timeRemaining = .5f;
    private bool eWithinDelay;

    //private float lastClickTime = 0.5f;
    //private const float DoubleClickTime = .2f;
    //private float itemsHeld;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //player has nothing in their hand at beginning of game
        InLeftHand = false;
        InRightHand = false;
        //itemsHeld = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        
        if (direction.magnitude >= 0.1f)
        {
            //float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            controller.Move(direction * speed * Time.deltaTime);
        }

        Vector3 movementDirection = new Vector3(vertical, 0f, -horizontal).normalized;
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, headRotateSpeed * Time.deltaTime);
        }
    }

    //In case other scripts need to tell the player the hand is empty/full
    public void TellLeftHandFalse()
    {
        InLeftHand = false;
    }
    public void TellLeftHandTrue()
    {
        InLeftHand = true;
    }
    public void TellRightHandFalse()
    {
        InRightHand = false;
    }
    public void TellRightHandTrue()
    {
        InLeftHand = true;
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Fridge")
        {
            //left mouse button
            if (Input.GetMouseButton(0))
            {
                Debug.Log("Left Click");

            if (Input.GetKeyDown(KeyCode.E))
            {
                //pressed e + 1
                eTotal += 1;
                //reset time
                timeRemaining = maxDelay;
                //start countdown
                timeRemaining -= Time.deltaTime;

                if (InLeftHand == false)
                {
                    EggItem.instance.GrabEggLeft();
                    InLeftHand = true;
                }

            }

            //right mouse button
            if (Input.GetMouseButton(1))
            {
                if (InRightHand == false)
            }


            if((eTotal == 2) && (timeRemaining < maxDelay))
            {
                eTotal = 0;
                Debug.Log("double click!");
                if(InRightHand == false)
                {
                    EggItem.instance.GrabEggRight();
                    InRightHand = true;
                }
            }

            //notes to self/easy copy and paste :))

            //EggItem.instance.GrabEggRight();
            //InRightHand = true;
            //Input.GetKey(KeyCode.E)
            //Debug.Log("grabbed w left");
            //EggItem.instance.GrabEggLeft();
            //InLeftHand = true;
            //Debug.Log("grabbed w right");
            //EggItem.instance.GrabEggRight();
            //InRightHand = true;
        }

        if (other.gameObject.tag == "Oven")
        {
            Debug.Log("near oven");
            if (Input.GetMouseButton(0))
            {
                //in something in left hand...
                if (InLeftHand == true)
                {
                    //put the left hand item in left slot
                    EggItem.instance.DropEggLeft();
                    InLeftHand = false;
                }
            }
            if (Input.GetMouseButton(1))
            {
                if (InRightHand == true)
                {
                    EggItem.instance.DropEggRight();
                    InRightHand = false;
                }
            }

            //Debug.Log("grabbed w right");
            //EggItem.instance.GrabEggRight();
            //InRightHand = true;
        }
    }
}

