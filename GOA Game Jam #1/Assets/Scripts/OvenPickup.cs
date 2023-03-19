using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenPickup : MonoBehaviour
{

    public static OvenPickup instance;

    public Transform LeftSlot;
    public Transform RightSlot;
    public Transform OvenProductSlot;

    public bool InLeftOvenSlot;
    public bool InRightOvenSlot;
    public bool CakeDone;
    public string IngredientType1;
    public string IngredientType2;

    public GameObject LeftOvenIngredient;
    public GameObject RightOvenIngredient;
    public GameObject Cake;

    public float timeCookingMax = 10;
    public float timeDisposeMax = 3;
    //public float timeRemaining;
    //private bool timerIsRunning;

    bool leftSoundPlayed = false, rightSoundPlayed = false;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InLeftOvenSlot = false;
        InRightOvenSlot = false;
        CakeDone = false;
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
            Debug.Log("SLOTS FILLED");

            IngredientType1 = LeftOvenIngredient.tag;
            IngredientType2 = RightOvenIngredient.tag;

            if( (IngredientType1 == "Egg") || (IngredientType2 == "Egg"))
            {
                if( (IngredientType1 == "Milk") || (IngredientType2 == "Milk") )
                {
                    Invoke("CakeRecipe", timeCookingMax);
                }
                else
                {
                    Debug.Log("detected wrong ingredients");
                    Invoke("IngredientsWrong", timeDisposeMax);
                }
            }
            
        }

    }
    public void LeftOvenSlotFill()
    {
        InLeftOvenSlot = true;
        AudioManager.instance.PlayStart();
    }
    public void RightOvenSlotFill()
    {
        InRightOvenSlot = true;
        AudioManager.instance.PlayStart();
    }
    public void LeftOvenSlotEmpty()
    {
        InLeftOvenSlot = false;
    }
    public void RightOvenSlotEmpty()
    {
        InRightOvenSlot = false;
    }

    public void CakeRecipe()
    {
        AudioManager.instance.PlayVictory();
        Debug.Log("food is ready!");

        //destroy ingredients
        LeftOvenIngredient = LeftSlot.transform.GetChild(0).gameObject;
        RightOvenIngredient = RightSlot.transform.GetChild(0).gameObject;

        Destroy(LeftOvenIngredient);
        InLeftOvenSlot = false;

        //DO NOT TELL PLAYER so they cant place more stuff
        //ThirdPersonMovement.instance.LeftOvenSlotEmpty();

        Destroy(RightOvenIngredient);
        InRightOvenSlot = false;

        //DO NOT TELL PLAYER so they cant place more stuff
        //ThirdPersonMovement.instance.RightOvenSlotEmpty();

        //make cake spawn on top of oven
        Cake = GameObject.Find("OGCake");
        Instantiate(Cake, OvenProductSlot);

        //activate the oven product collider
        CakeProductPickup.instance.CakeDone();

        CancelInvoke("CakeRecipe");
    }

    private void IngredientsWrong()
    {
        AudioManager.instance.PlayWrong();
        Debug.Log("Ingredients Wrong!");

        //destroy ingredients
        LeftOvenIngredient = LeftSlot.transform.GetChild(0).gameObject;
        RightOvenIngredient = RightSlot.transform.GetChild(0).gameObject;

        Destroy(LeftOvenIngredient);
        InLeftOvenSlot = false;
        ThirdPersonMovement.instance.LeftOvenSlotEmpty();

        Destroy(RightOvenIngredient);
        InRightOvenSlot = false;
        ThirdPersonMovement.instance.RightOvenSlotEmpty();

        CancelInvoke("IngredientsWrong");

    }
}
