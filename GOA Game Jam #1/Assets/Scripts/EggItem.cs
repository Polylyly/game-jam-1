using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggItem : MonoBehaviour
{

    public static EggItem instance;

    public Transform LeftHandEmpty;
    public Transform RightHandEmpty;

    public GameObject Egg;
    private Transform spawnPoint;

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

        while (InLeftHand == true)
        {

            //cloneEgg.transform.position = spawnPoint;
        }
        while (InRightHand == true)
        {

            //cloneEgg.transform.position = spawnPoint;
        }
    }

    public void GrabEggLeft()
    {
        Debug.Log("test");
        Instantiate(Egg, LeftHandEmpty);
        InLeftHand = true;

    }
    public void GrabEggRight()
    {
        Debug.Log("test");
        Instantiate(Egg, RightHandEmpty);
        InRightHand = true;

    }
}
