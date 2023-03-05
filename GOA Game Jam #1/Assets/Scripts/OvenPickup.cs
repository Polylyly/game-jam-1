using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenPickup : MonoBehaviour
{

    public static OvenPickup instance;

    public Transform LeftSlot;
    public Transform RightSlot;

    private bool InLeftSlot;
    private bool InRightSlot;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InLeftSlot = false;
        InRightSlot = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void LeftSlotFill(ingredient)
    

    //public void RightSlotFill(ingredient)
    
    //public class ingredient()
}
