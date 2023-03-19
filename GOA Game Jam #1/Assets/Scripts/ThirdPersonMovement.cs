using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;
    public float headRotateSpeed = 700f;

    public static ThirdPersonMovement instance;

    public bool InLeftHand;
    public bool InRightHand;
    public bool InLeftOvenSlot;
    public bool InRightOvenSlot;
    public bool InLeftGrillSlot;
    public bool InRightGrillSlot;
    //private bool NearOven;

    public Transform LeftHandEmpty;
    public Transform RightHandEmpty;
    public Transform OvenProductSlot;
    public Transform GrillProductSlot;
    GameObject LeftHandItem;
    GameObject RightHandItem;


    //private bool eWithinDelay;

    private void Awake()
    {
        instance = this;
        Cursor.lockState = CursorLockMode.None;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;

        //player has nothing in their hand at beginning of game
        InLeftHand = false;
        InRightHand = false;
        InLeftOvenSlot = false;
        InRightOvenSlot = false;
        InLeftGrillSlot = false;
        InRightGrillSlot = false;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
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
    public void LeftOvenSlotEmpty()
    {
        InLeftOvenSlot = false;
    }
    public void RightOvenSlotEmpty()
    {
        InRightOvenSlot = false;
    }

    //same but for grill
    public void LeftGrillSlotFill()
    {
        InLeftGrillSlot = true;
    }
    public void RightGrillSlotFill()
    {
        InRightGrillSlot = true;
    }
    public void LeftGrillSlotEmpty()
    {
        InLeftGrillSlot = false;
    }
    public void RightGrillSlotEmpty()
    {
        InRightGrillSlot = false;
    }

    public void OnTriggerStay(Collider other)
    {
        //interaction for egg fridge
        if (other.gameObject.tag == "Fridge")
        {
            //left mouse button
            if (Input.GetMouseButton(0))
            {
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

        //interaction for steak fridge
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

        //for grabbing milk 
        if (other.gameObject.tag == "ThirdFridge")
        {
            //left mouse button
            if (Input.GetMouseButton(0))
            {
                Debug.Log("Left Click");
                if (InLeftHand == false)
                {
                    MilkItem.instance.GrabMilkLeft();
                    InLeftHand = true;
                }

            }

            //right mouse button
            if (Input.GetMouseButton(1))
            {
                if (InRightHand == false)
                {
                    MilkItem.instance.GrabMilkRight();
                    InRightHand = true;
                }
            }
        }

        //for cookin on oven
        if (other.gameObject.tag == "Oven")
        {
            //Debug.Log("near oven");
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
                    else if (LeftHandItem.tag == "Milk")
                    {
                        MilkItem.instance.DropMilkLeft();
                        InLeftHand = false;
                    }
                }
                else
                {
                    Debug.Log("left click but nothing happened");
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
                        //Debug.Log("Check for Right Steak Bug");
                        SteakItem.instance.DropSteakRight();
                        InRightHand = false;
                    }
                    else if (RightHandItem.tag == "Milk")
                    {
                        MilkItem.instance.DropMilkRight();
                        InRightHand = false;
                    }
                }
                else
                {
                    Debug.Log("right click but nothing happened");
                }
            }
        }

        //for cookin on grill
        if (other.gameObject.tag == "Grill")
        {
            if (Input.GetMouseButton(0))
            {
                //in something in left hand...
                if ((InLeftHand == true) && (InLeftGrillSlot == false))
                {
                    //find out what is the child of the left hand
                    LeftHandItem = LeftHandEmpty.transform.GetChild(0).gameObject;

                    //if what is in the left hand is tagged with Egg...
                    if (LeftHandItem.tag == "Egg")
                    {
                        EggItem.instance.GrillDropEggLeft();
                        InLeftHand = false;
                    }
                    //if not an egg, child must be tagged with.. 
                    else if (LeftHandItem.tag == "Steak")
                    {
                        SteakItem.instance.GrillDropSteakLeft();
                        InLeftHand = false;
                    }
                    else if (LeftHandItem.tag == "Milk")
                    {
                        MilkItem.instance.GrillDropMilkLeft();
                        InLeftHand = false;
                    }
                }
            }
            if (Input.GetMouseButton(1))
            {
                if ((InRightHand == true) && (InRightGrillSlot == false))
                {
                    RightHandItem = RightHandEmpty.transform.GetChild(0).gameObject;

                    if (RightHandItem.tag == "Egg")
                    {
                        EggItem.instance.GrillDropEggRight();
                        InRightHand = false;
                    }
                    else if (RightHandItem.tag == "Steak")
                    {
                        SteakItem.instance.GrillDropSteakRight();
                        InRightHand = false;
                    }
                    else if (RightHandItem.tag == "Milk")
                    {
                        MilkItem.instance.GrillDropMilkRight();
                        InRightHand = false;
                    }
                }
            }
        }

        //for picking up cake
        if (other.gameObject.tag == "OvenProduct")
        {
            if (Input.GetMouseButton(0) && (InLeftHand == false))
            {
                Debug.Log("Left Clicked to collect oven product");
                //instantiate in left hand
                GameObject Cakeclone = OvenProductSlot.transform.GetChild(0).gameObject;

                Instantiate(Cakeclone, LeftHandEmpty);
                Destroy(Cakeclone);

                //left hand true
                InLeftHand = true;
                InLeftOvenSlot = false;
                InRightOvenSlot = false;

                //tell oven empty
                OvenPickup.instance.LeftOvenSlotEmpty();
                //should already be false but covering my bases!

                //deactivate collider
                CakeProductPickup.instance.CakeOff();
            }
            if ((Input.GetMouseButton(1)) && (InRightHand == false))
            {
                Debug.Log("Right Clicked to collect oven product");

                //instantiate in left hand
                GameObject Cakeclone = OvenProductSlot.transform.GetChild(0).gameObject;

                Instantiate(Cakeclone, RightHandEmpty);
                Destroy(Cakeclone);

                //right hand true
                InRightHand = true;
                InRightOvenSlot = false;
                InLeftOvenSlot = false;

                //tell oven empty
                OvenPickup.instance.RightOvenSlotEmpty();
                //should already be false but covering my bases!

                //deactivate collider
                CakeProductPickup.instance.CakeOff();
            }
        }

        //for picking up steak
        if (other.gameObject.tag == "GrillProduct")
        {
            Debug.Log("NEAR GRILL W STEAK IN IT");

            if (Input.GetMouseButton(0) && (InLeftHand == false))
            {
                Debug.Log("Left Clicked to collect grill product");
                //instantiate in left hand
                GameObject Steakclone = GrillProductSlot.transform.GetChild(0).gameObject;

                Instantiate(Steakclone, LeftHandEmpty);
                Destroy(Steakclone);

                //left hand true
                InLeftHand = true;
                InLeftGrillSlot = false;
                InRightGrillSlot = false;

                //tell grill empty
                GrillPickup.instance.LeftGrillSlotEmpty();
                //should already be false but covering my bases!

                //deactivate collider
                SteakProductPickup.instance.SteakOff();
            }
            if ((Input.GetMouseButton(1)) && (InRightHand == false))
            {
                Debug.Log("Right Clicked to collect Steak product");

                //instantiate in left hand
                GameObject Steakclone = GrillProductSlot.transform.GetChild(0).gameObject;

                Instantiate(Steakclone, RightHandEmpty);
                Destroy(Steakclone);

                //right hand true
                InRightHand = true;
                InRightGrillSlot = false;
                InLeftGrillSlot = false;

                //tell grill empty
                GrillPickup.instance.RightGrillSlotEmpty();
                //should already be false but covering my bases!

                //deactivate collider
                SteakProductPickup.instance.SteakOff();
            }
        }

        //for dropping off products
        if (other.gameObject.tag == "Table")
        {
            Debug.Log("near table");
            if (InLeftHand == true)
            {
                GameObject LeftHandEmpty = GameObject.Find("Left Hand");
                LeftHandItem = LeftHandEmpty.transform.GetChild(0).gameObject;

                if ((LeftHandItem.tag == "Cake") || (LeftHandItem.tag == "SteaknEggs"))
                {
                    Debug.Log("left hand has product!");
                    if (LeftHandItem.tag == "Cake")
                    {
                        PlayerPrefs.SetInt("CakeCount", PlayerPrefs.GetInt("CakeCount") + 1);
                    }
                    if (LeftHandItem.tag == "SteaknEggs")
                    {
                        PlayerPrefs.SetInt("SnECount", PlayerPrefs.GetInt("SnECount") + 1);
                    }

                    Destroy(LeftHandItem);
                    InLeftHand = false;

                }
            }

            if (InRightHand == true)
            {
                GameObject RightHandEmpty = GameObject.Find("Right Hand");
                RightHandItem = RightHandEmpty.transform.GetChild(0).gameObject; 

                if ((RightHandItem.tag == "Cake") || (RightHandItem.tag == "SteaknEggs"))
                {
                    Debug.Log("Right hand has product!");
                    if (RightHandItem.tag == "Cake")
                    {
                        PlayerPrefs.SetInt("CakeCount", PlayerPrefs.GetInt("CakeCount") + 1);
                    }
                    if (RightHandItem.tag == "SteaknEggs")
                    {
                        PlayerPrefs.SetInt("SnECount", PlayerPrefs.GetInt("SnECount") + 1);
                    }

                    Destroy(RightHandItem);
                    InRightHand = false;

                }

            }
        }
           
        //for throwing away ingredients
        if (other.gameObject.tag == "Sink")
        {

            if (Input.GetMouseButton(0) && (InLeftHand == true))
            {
                LeftHandItem = LeftHandEmpty.transform.GetChild(0).gameObject;
                Destroy(LeftHandItem);
                InLeftHand = false;
            }
            else
            {
                Debug.Log("nothing in hand ig");
            }

            if (Input.GetMouseButton(1) && (InRightHand == true))
            {
                RightHandItem = RightHandEmpty.transform.GetChild(0).gameObject;
                Destroy(RightHandItem);
                InRightHand = false;
            }
            else
            {
                Debug.Log("nothing in hand ig");
            }

        }
    }
}
