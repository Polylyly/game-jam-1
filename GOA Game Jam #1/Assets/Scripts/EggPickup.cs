using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggPickup : MonoBehaviour
{
    public GameObject EggOnPlayer;
    // Start is called before the first frame update
    void Start()
    {
        EggOnPlayer.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                EggOnPlayer.SetActive(true);
            }
        }
    }

}
