using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggItem : MonoBehaviour
{

    public static EggItem instance;

    public Transform LeftHandEmpty;
    public Transform RightHandEmpty;

    public Transform LeftOvenSlot;
    public Transform RightOvenSlot;

    private GameObject cloneEggLeft;
    private GameObject cloneEggRight;
    public GameObject Egg;

    public GameObject Egg;

    private bool InLeftHand;
    private bool InRightHand;

    //private GameObject cloneEgg;

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
        //cloneEgg = GameObject.FindGameObjectWithTag("CloneofEgg");
        
    }

    public void GrabEggLeft()
    {
        //Debug.Log("test");
        Instantiate(Egg, LeftHandEmpty);
        InLeftHand = true;

        cloneEggLeft = Instantiate(Egg, LeftHandEmpty);
        cloneEggLeft.tag = "Egg";

    }
    public void GrabEggRight()
    {
        //Debug.Log("test");
        Instantiate(Egg, RightHandEmpty);
        InRightHand = true;

        cloneEggRight = Instantiate(Egg, RightHandEmpty);
        cloneEggRight.tag = "Egg";

    }
    public void DropEggLeft()
    {
        //find child of left hand empty
        GameObject LeftHandEmpty = GameObject.Find("Left Hand");
        cloneEggLeft = LeftHandEmpty.transform.GetChild(0).gameObject;

        //destroy and replace in slot
        Destroy(cloneEggLeft);
        Instantiate(Egg, LeftOvenSlot);

        //OvenPickup.instance.LeftSlotFill();
    }

    public void DropEggRight()
    {
        
        //Find child of right hand empty
        GameObject RightHandEmpty = GameObject.Find("Right Hand");
        cloneEggRight = RightHandEmpty.transform.GetChild(0).gameObject;

        //destroy and replace in slot
        Destroy(cloneEggRight);
        Instantiate(Egg, RightOvenSlot);

    }
}