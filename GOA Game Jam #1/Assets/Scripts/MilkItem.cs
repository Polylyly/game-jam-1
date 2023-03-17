using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkItem : MonoBehaviour
{

    public static MilkItem instance;

    public Transform LeftHandEmpty;
    public Transform RightHandEmpty;

    public Transform LeftOvenSlot;
    public Transform RightOvenSlot;
    public Transform LeftGrillSlot;
    public Transform RightGrillSlot;

    private GameObject cloneMilkLeft;
    private GameObject cloneMilkRight;
    public GameObject Milk;


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

    public void GrabMilkLeft()
    {

        Milk = GameObject.Find("OGMilk");
        cloneMilkLeft = Instantiate(Milk, LeftHandEmpty);
        cloneMilkLeft.tag = "Milk";

    }
    public void GrabMilkRight()
    {

        Milk = GameObject.Find("OGMilk");
        cloneMilkRight = Instantiate(Milk, RightHandEmpty);
        cloneMilkRight.tag = "Milk";

    }
    public void DropMilkLeft()
    {
        //find child of left hand empty
        GameObject LeftHandEmpty = GameObject.Find("Left Hand");
        cloneMilkLeft = LeftHandEmpty.transform.GetChild(0).gameObject;

        //destroy and replace in slot
        Destroy(cloneMilkLeft);
        Instantiate(Milk, LeftOvenSlot);

        //tell player oven is full 
        ThirdPersonMovement.instance.LeftOvenSlotFill();
        OvenPickup.instance.LeftOvenSlotFill();
    }
    public void GrillDropMilkLeft()
    {
        //find child of left hand empty
        GameObject LeftHandEmpty = GameObject.Find("Left Hand");
        cloneMilkLeft = LeftHandEmpty.transform.GetChild(0).gameObject;

        //destroy and replace in slot
        Destroy(cloneMilkLeft);
        Instantiate(Milk, LeftGrillSlot);

        //tell player grill is full 
        ThirdPersonMovement.instance.LeftGrillSlotFill();
        GrillPickup.instance.LeftGrillSlotFill();
    }

    public void DropMilkRight()
    {

        //Find child of right hand empty
        GameObject RightHandEmpty = GameObject.Find("Right Hand");
        cloneMilkRight = RightHandEmpty.transform.GetChild(0).gameObject;

        //destroy and replace in slot
        Destroy(cloneMilkRight);
        Instantiate(Milk, RightOvenSlot);

        //tell player oven is full 
        ThirdPersonMovement.instance.RightOvenSlotFill();
        OvenPickup.instance.RightOvenSlotFill();
    }
    public void GrillDropMilkRight()
    {

        //Find child of right hand empty
        GameObject RightHandEmpty = GameObject.Find("Right Hand");
        cloneMilkRight = RightHandEmpty.transform.GetChild(0).gameObject;

        //destroy and replace in slot
        Destroy(cloneMilkRight);
        Instantiate(Milk, RightGrillSlot);

        //tell player grill is full 
        ThirdPersonMovement.instance.RightGrillSlotFill();
        GrillPickup.instance.RightGrillSlotFill();
    }
}