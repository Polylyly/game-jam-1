using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteakItem : MonoBehaviour
{

    public static SteakItem instance;

    public Transform LeftHandEmpty;
    public Transform RightHandEmpty;

    public Transform LeftOvenSlot;
    public Transform RightOvenSlot;

    private GameObject cloneSteakLeft;
    private GameObject cloneSteakRight;
    public GameObject Steak;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void GrabSteakLeft()
    {

        cloneSteakLeft = Instantiate(Steak, LeftHandEmpty);
        cloneSteakLeft.tag = "Steak";

    }
    public void GrabSteakRight()
    {

        cloneSteakRight = Instantiate(Steak, RightHandEmpty);
        cloneSteakRight.tag = "Steak";

    }
    public void DropSteakLeft()
    {
        //find child of left hand empty
        GameObject LeftHandEmpty = GameObject.Find("Left Hand");
        cloneSteakLeft = LeftHandEmpty.transform.GetChild(0).gameObject;

        //destroy and replace in slot
        Destroy(cloneSteakLeft);
        Instantiate(Steak, LeftOvenSlot);

        //tell player oven is full 
        ThirdPersonMovement.instance.LeftOvenSlotFill();
        OvenPickup.instance.LeftOvenSlotFill();
    }

    public void DropSteakRight()
    {

        //Find child of right hand empty
        GameObject RightHandEmpty = GameObject.Find("Right Hand");
        cloneSteakRight = RightHandEmpty.transform.GetChild(0).gameObject;

        //destroy and replace in slot
        Destroy(cloneSteakRight);
        Instantiate(Steak, RightOvenSlot);

        //tell player oven is full 
        ThirdPersonMovement.instance.RightOvenSlotFill();
        OvenPickup.instance.RightOvenSlotFill();
    }
}
