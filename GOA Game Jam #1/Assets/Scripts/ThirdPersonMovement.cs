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

    private int eTotal;
    private int qTotal;
    public float maxDelay = 1f;
    public float eTimeRemaining;
    public float qTimeRemaining;
    private bool eWithinDelay;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //player has nothing in their hand at beginning of game
        InLeftHand = false;
        InRightHand = false;
        eTotal = 0;
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
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Oven")
        {
            
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Fridge")
        {
            Debug.Log("near fridge");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("pressed E!");
                //pressed e + 1
                eTotal += 1;

                if (InLeftHand == false)
                {
                    EggItem.instance.GrabEggLeft();
                    InLeftHand = true;
                }
            }

            if (eTotal == 1)
            {
                
                //reset time
                eTimeRemaining = maxDelay;
                //start countdown
                eTimeRemaining -= Time.deltaTime;
            }

            if(eTimeRemaining <= 0)
            {
                //time ran out
                Debug.Log("time ran out!");
                eTimeRemaining = maxDelay;
            }
            if ((eTotal == 2) && (eTimeRemaining < maxDelay))
            {
                Debug.Log("double click!");
                if (InRightHand == false)
                {
                    EggItem.instance.GrabEggRight();
                    InRightHand = true;
                }

                eTotal = 0;
            }


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
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Pressed Q");
                //pressed e - 1
                eTotal -= 1;

                if (InLeftHand == true)
                {
                    EggItem.instance.DropEggLeft();
                    InLeftHand = false;
                }
            }

            if (eTotal == 1)
            {
                //reset time
                qTimeRemaining = maxDelay;
                //start countdown
                qTimeRemaining -= Time.deltaTime;
            }

            if (qTimeRemaining <= 0)
            {
                //time ran out
                Debug.Log("time ran out!");
                qTimeRemaining = maxDelay;
            }
            if ((eTotal == 0) && (qTimeRemaining < maxDelay))
            {
                Debug.Log("double click!");
                if (InRightHand == true)
                {
                    EggItem.instance.DropEggRight();
                    InRightHand = false;
                }

                qTotal = 0;
            }
        }
    }
}
