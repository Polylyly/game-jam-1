using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteakProductPickup : MonoBehaviour
{
    public static SteakProductPickup instance;

    public Collider Steaktrigger;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Steaktrigger = GetComponent<Collider>();

        //starts off
        Steaktrigger.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void SteakDone()
    {
        Steaktrigger = GetComponent<Collider>();

        //turn on so it can be picked up
        Steaktrigger.enabled = true;
    }

    //ThirdpersonMovement tells cake collider to turn off 
    public void SteakOff()
    {
        Steaktrigger = GetComponent<Collider>();
        Steaktrigger.enabled = false;
    }
}
