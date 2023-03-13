using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenPickup : MonoBehaviour
{

    public static OvenPickup instance;

    public Transform LeftSlot;
    public Transform RightSlot;

    private bool InLeftOvenSlot;
    private bool InRightOvenSlot;

    GameObject LeftOvenIngredient;
    GameObject RightOvenIngredient;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InLeftOvenSlot = false;
        InRightOvenSlot = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LeftOvenSlotFill()
    {
        InLeftOvenSlot = true;

        LeftOvenIngredient = LeftSlot.transform.GetChild(0).gameObject;
    }
    public void RightOvenSlotFill()
    {
        InRightOvenSlot = true;

        RightOvenIngredient = RightSlot.transform.GetChild(0).gameObject;
    }

    public void SteaknEggsRecipe()
    {
        //start timer --> yield results 
    }
}
