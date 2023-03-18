using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeProductPickup : MonoBehaviour
{
    public static CakeProductPickup instance; 

    public Collider Caketrigger;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Caketrigger = GetComponent<Collider>();
        
        //starts off
        Caketrigger.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("pressed return");
            Caketrigger.enabled = !Caketrigger.enabled;
        }*/

    }

    //the oven tells cakeproductpickup Cakedone() so the trigger collider activates 
    public void CakeDone()
    {
        //Debug.Log("heard CakeDone");
        Caketrigger = GetComponent<Collider>();

        //turn on so it can be picked up
        Caketrigger.enabled = true;
        //Debug.Log(Caketrigger.enabled);
    }

    //ThirdpersonMovement tells cake collider to turn off 
    public void CakeOff()
    {
        Caketrigger = GetComponent<Collider>();
        Caketrigger.enabled = false;
    }
}
