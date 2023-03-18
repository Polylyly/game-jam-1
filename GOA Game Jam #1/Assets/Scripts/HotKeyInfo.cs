using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HotKeyInfo : MonoBehaviour
{
    public TextMeshProUGUI hotKeyMsg;
    // Start is called before the first frame update
    void Start()
    {
        hotKeyMsg.text = "Left/Right Click to Interact";
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetMouseButton(1) || Input.GetMouseButton(0) )
        {
            hotKeyMsg.text = "";
        }

        /*if (Input.GetKeyDown(KeyCode.E))
        {
            hotKeyMsg.text = "";
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            hotKeyMsg.text = "";
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Fridge")
        {
            hotKeyMsg.text = "Steaks";
        }

        if (other.gameObject.tag == "Second Fridge")
        {
            hotKeyMsg.text = "Eggs";
        }

        if (other.gameObject.tag == "ThirdFridge")
        {
            hotKeyMsg.text = "Milk";
        }
    }
}
