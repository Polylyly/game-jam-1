using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (SceneManager.GetActiveScene().name == "PastWorld")
                SceneManager.LoadScene("FutureWorld");
            if (SceneManager.GetActiveScene().name == "FutureWorld")
                SceneManager.LoadScene("PastWorld");
        }
    }
}
