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

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //player has nothing in their hand at beginning of game
        InLeftHand = false;
        InRightHand = false;
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
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Fridge")
        {
            //&& ItemsCarried < 2
            if (Input.GetKey(KeyCode.E))
            {
                if (InLeftHand == false)
                {
                    EggItem.instance.GrabEggLeft();
                    InLeftHand = true;
                }
                else if (InRightHand == false)
                {
                    EggItem.instance.GrabEggRight();
                    InRightHand = true;
                }
            }
        }
    }
}
