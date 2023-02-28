using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggItem : MonoBehaviour
{

    public static EggItem instance;

    public GameObject LeftHandEmpty;
    //Vector3 LeftHandPosition = LeftHandEmpty.transform.position;
    public GameObject RightHandEmpty;

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

    public void GrabEggLeft()
    {

    }
    public void GrabEggRight()
    {

    }
}
