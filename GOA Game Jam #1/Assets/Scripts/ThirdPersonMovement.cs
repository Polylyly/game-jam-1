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
    private bool InLeftOvenSlot;
    private bool InRightOvenSlot;
    //private bool NearOven;

    public Transform LeftHandEmpty;
    public Transform RightHandEmpty;
    GameObject LeftHandItem;
    GameObject RightHandItem;


    //private bool eWithinDelay;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //player has nothing in their hand at beginning of game
        InLeftHand = false;
        InRightHand = false;
        InLeftOvenSlot = false;
        InRightOvenSlot = false;
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

    //oven is filled- tells player that 
    public void LeftOvenSlotFill()
    {
        InLeftOvenSlot = true;
    }
    public void RightOvenSlotFill()
    {
        InRightOvenSlot = true;
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Fridge")
        {
            //left mouse button
            if (Input.GetMouseButton(0))
            {
                Debug.Log("Left Click");
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
                {
                    EggItem.instance.GrabEggRight();
                    InRightHand = true;
                }
            }
        }

        if (other.gameObject.tag == "Second Fridge")
        {
            //left mouse button
            if (Input.GetMouseButton(0))
            {
                Debug.Log("Left Click");
                if (InLeftHand == false)
                {
                    SteakItem.instance.GrabSteakLeft();
                    InLeftHand = true;
                }

            }

            //right mouse button
            if (Input.GetMouseButton(1))
            {
                if (InRightHand == false)
                {
                    SteakItem.instance.GrabSteakRight();
                    InRightHand = true;
                }
            }
        }

        if (other.gameObject.tag == "Oven")
        {
            Debug.Log("near oven");
            if (Input.GetMouseButton(0))
            {
                //in something in left hand...
                if ((InLeftHand == true) && (InLeftOvenSlot == false))
                {
                    //find out what is the child of the left hand
                    LeftHandItem = LeftHandEmpty.transform.GetChild(0).gameObject;

                    //if what is in the left hand is tagged with Egg...
                    if (LeftHandItem.tag == "Egg")
                    {
                        EggItem.instance.DropEggLeft();
                        InLeftHand = false;
                    }
                    //if not an egg, child must be tagged with.. 
                    else if (LeftHandItem.tag == "Steak")
                    {
                        SteakItem.instance.DropSteakLeft();
                        InLeftHand = false;
                    }
                }
            }
            if (Input.GetMouseButton(1))
            {
                if ((InRightHand == true) && (InRightOvenSlot == false))
                {
                    RightHandItem = RightHandEmpty.transform.GetChild(0).gameObject;

                    if (RightHandItem.tag == "Egg")
                    {
                        EggItem.instance.DropEggRight();
                        InRightHand = false;
                    }
                    else if (RightHandItem.tag == "Steak")
                    {
                        SteakItem.instance.DropSteakRight();
                        InRightHand = false;
                    }
                }
            }
        }

        //for throwing away ingredients
        if (other.gameObject.tag == "Sink")
        {

            if ((Input.GetMouseButton(0)) && (InLeftHand == true))
            {
                LeftHandItem = LeftHandEmpty.transform.GetChild(0).gameObject;
                Destroy(LeftHandItem);
                InLeftHand = false;
            }

            if ((Input.GetMouseButton(1)) && (InRightHand == true))
            {
                RightHandItem = RightHandEmpty.transform.GetChild(0).gameObject;
                Destroy(RightHandItem);
                InRightHand = false;
            }
        }
    }
}
