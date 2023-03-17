using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Health")) PlayerPrefs.SetInt("Health", 5);
        currentHealth = PlayerPrefs.GetInt("Health");
        healthBar.SetHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Death");
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        PlayerPrefs.SetInt("Health", currentHealth);

        healthBar.SetHealth(currentHealth);
    }
}
