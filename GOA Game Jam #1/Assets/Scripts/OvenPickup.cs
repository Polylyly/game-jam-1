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
    private string IngredientType1;
    private string IngredientType2;

    public GameObject LeftOvenIngredient;
    public GameObject RightOvenIngredient;

    public float timeRemaining = 10;
    private bool timerIsRunning;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InLeftOvenSlot = false;
        InRightOvenSlot = false;
        timerIsRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(InLeftOvenSlot == true)
        {
            GameObject LeftSlot = GameObject.Find("LeftOvenSlot");
            LeftOvenIngredient = LeftSlot.transform.GetChild(0).gameObject;
        }

        if(InRightOvenSlot == true)
        {
            GameObject RightSlot = GameObject.Find("RightOvenSlot");
            RightOvenIngredient = RightSlot.transform.GetChild(0).gameObject;
        }

        //if both slots are filled...
        if((InLeftOvenSlot == true) && (InRightOvenSlot == true))
        {
            IngredientType1 = LeftOvenIngredient.tag;
            IngredientType2 = RightOvenIngredient.tag;

            if( (IngredientType1 == "Egg") || (IngredientType2 == "Egg"))
            {
                if( (IngredientType1 == "Steak") || (IngredientType2 == "Steak") )
                {
                    SteaknEggsRecipe();
                }
            }
            else
            {
                IngredientsWrong();
            }
        }


    }
    public void LeftOvenSlotFill()
    {
        InLeftOvenSlot = true;
    }
    public void RightOvenSlotFill()
    {
        InRightOvenSlot = true;
    }

    public void SteaknEggsRecipe()
    {
        LeftOvenIngredient = LeftSlot.transform.GetChild(0).gameObject;
        RightOvenIngredient = RightSlot.transform.GetChild(0).gameObject;

        timerIsRunning = true;

        if(timerIsRunning == true)
        {
            Debug.Log(timeRemaining);
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("food is ready!");
                timeRemaining = 10f;
            }
        }
        //start timer --> yield results 
    }
    public void IngredientsWrong()
    {

        Debug.Log("Ingredients Wrong!");

    }
}
