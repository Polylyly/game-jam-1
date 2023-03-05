using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggItem : MonoBehaviour
{

    public static EggItem instance;

    public Transform LeftHandEmpty;
    public Transform RightHandEmpty;

    private GameObject cloneEggLeft;
    private GameObject cloneEggRight;
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
        cloneEggLeft = Instantiate(Egg, LeftHandEmpty);
        InLeftHand = true;

    }
    public void GrabEggRight()
    {
        //Debug.Log("test");
        cloneEggRight = Instantiate(Egg, RightHandEmpty);
        InRightHand = true;

    }
    public void DropEggLeft()
    {
        Destroy(cloneEggLeft);
        ThirdPersonMovement.instance.TellLeftHandFalse();
    }

    public void DropEggRight()
    {
        Destroy(cloneEggRight);
        ThirdPersonMovement.instance.TellRightHandFalse();
    }
}