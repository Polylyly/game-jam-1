using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public float pastAllocatedTime;
    public float futureAllocatedTime;
    public string destination;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "PastWorld")
        {
            destination = "Future";
            Invoke(nameof(LoadNextScene), pastAllocatedTime);
        }
        if (SceneManager.GetActiveScene().name == "FutureWorld")
        {
            destination = "Past";
            Invoke(nameof(LoadNextScene), futureAllocatedTime);
        }
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

    private void LoadNextScene()
    {
        if (destination.Equals("Past"))
        {
            SceneManager.LoadScene("PastWorld");
        }
        else if (destination.Equals("Future"))
        {
            SceneManager.LoadScene("FutureWorld");
        }
    }
}
