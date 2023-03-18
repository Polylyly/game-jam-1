using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrillPickup : MonoBehaviour
{

    public static GrillPickup instance;

    public Transform LeftSlot;
    public Transform RightSlot;
    public Transform GrillProductSlot;

    public bool InLeftGrillSlot;
    public bool InRightGrillSlot;
    public string IngredientType1;
    public string IngredientType2;

    public GameObject LeftGrillIngredient;
    public GameObject RightGrillIngredient;
    public GameObject SteaknEggs;

    public float timeCookingMax = 10;
    public float timeDisposeMax = 3;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InLeftGrillSlot = false;
        InRightGrillSlot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (InLeftGrillSlot == true)
        {
            GameObject LeftSlot = GameObject.Find("LeftGrillSlot");
            LeftGrillIngredient = LeftSlot.transform.GetChild(0).gameObject;
        }

        if (InRightGrillSlot == true)
        {
            GameObject RightSlot = GameObject.Find("RightGrillSlot");
            RightGrillIngredient = RightSlot.transform.GetChild(0).gameObject;
        }

        //if both slots are filled...
        if ((InLeftGrillSlot == true) && (InRightGrillSlot == true))
        {

            IngredientType1 = LeftGrillIngredient.tag;
            IngredientType2 = RightGrillIngredient.tag;

            if ((IngredientType1 == "Egg") || (IngredientType2 == "Egg"))
            {
                if ((IngredientType1 == "Steak") || (IngredientType2 == "Steak"))
                {
                    Invoke("SteaknEggsRecipe", timeCookingMax);
                }
                else
                {
                    Invoke("IngredientsWrong", timeDisposeMax);
                }
            }
            
        }


    }
    public void LeftGrillSlotFill()
    {
        InLeftGrillSlot = true;
        //Debug.Log("told that left grill slot is filled");
    }
    public void RightGrillSlotFill()
    {
        InRightGrillSlot = true;
        //Debug.Log("told that right grill slot is filled");
    }
    public void LeftGrillSlotEmpty()
    {
        InLeftGrillSlot = false;
        //Debug.Log("told that left grill slot is filled");
    }
    public void RightGrillSlotEmpty()
    {
        InRightGrillSlot = false;
        //Debug.Log("told that right grill slot is filled");
    }

    private void SteaknEggsRecipe()
    {
        Debug.Log("food is ready!");

        //destroy ingredients
        LeftGrillIngredient = LeftSlot.transform.GetChild(0).gameObject;
        RightGrillIngredient = RightSlot.transform.GetChild(0).gameObject;

        Destroy(LeftGrillIngredient);
        InLeftGrillSlot = false;

        //DO NOT TELL PLAYER to avoid being able to put more stuff
        //ThirdPersonMovement.instance.LeftGrillSlotEmpty();

        Destroy(RightGrillIngredient);
        InRightGrillSlot = false;

        //DO NOT TELL PLAYER to avoid being able to put more stuff
        //ThirdPersonMovement.instance.RightGrillSlotEmpty();

        //make cake spawn on top of oven
        SteaknEggs = GameObject.Find("OGSteaknEggs");
        Instantiate(SteaknEggs, GrillProductSlot);

        //activate the oven product collider
        SteakProductPickup.instance.SteakDone();

        CancelInvoke("SteaknEggsRecipe");

    }
    private void IngredientsWrong()
    {
        Debug.Log("Ingredients Wrong!");

        //destroy ingredients
        LeftGrillIngredient = LeftSlot.transform.GetChild(0).gameObject;
        RightGrillIngredient = RightSlot.transform.GetChild(0).gameObject;

        Destroy(LeftGrillIngredient);
        InLeftGrillSlot = false;
        ThirdPersonMovement.instance.LeftGrillSlotEmpty();

        Destroy(RightGrillIngredient);
        InRightGrillSlot = false;
        ThirdPersonMovement.instance.RightGrillSlotEmpty();

        CancelInvoke("IngredientsWrong");
    }
}
