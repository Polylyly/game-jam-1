using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Start is called before the first frame update
    public void Retry()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("PastWorld");
    }
}
