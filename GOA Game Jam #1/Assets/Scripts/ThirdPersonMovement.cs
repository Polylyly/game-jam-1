using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;


    public static ThirdPersonMovement instance;

    private bool InLeftHand;
    private bool InRightHand;
    private float itemsHeld;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //player has nothing in their hand at beginning of game
        InLeftHand = false;
        InRightHand = false;
        itemsHeld = 0;
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
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Fridge")
        {
            if (itemsHeld == 0)
            {
                Debug.Log("both hands empty!");
                if (Input.GetKey(KeyCode.E))
                {
                    EggItem.instance.GrabEggLeft();
                    InLeftHand = true;
                    itemsHeld += 1;
                }
            }
            else if (itemsHeld == 1)
            {
                if (InLeftHand == false)
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        EggItem.instance.GrabEggLeft();
                        InLeftHand = true;
                        itemsHeld += 1;
                    }
                }
                else if (InRightHand == false)
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        EggItem.instance.GrabEggRight();
                        InRightHand = true;
                        itemsHeld += 1;
                    }
                }
            }
            else if (itemsHeld == 2)
            {
                Debug.Log("hands full!");
            }
            //Input.GetKey(KeyCode.E)
                    //Debug.Log("grabbed w left");
                    //EggItem.instance.GrabEggLeft();
                    //InLeftHand = true;
                    
                    //Debug.Log("grabbed w right");
                    //EggItem.instance.GrabEggRight();
                    //InRightHand = true;
        }
    }
}

