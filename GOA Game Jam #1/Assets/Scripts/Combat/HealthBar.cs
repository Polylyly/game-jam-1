using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void SetHealth(int health)
    {
        text.SetText(health.ToString());
    }
}
