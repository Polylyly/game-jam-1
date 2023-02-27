using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;

    public static CombatMovement instance;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(horizontal, 0, vertical).normalized;
        move = this.transform.TransformDirection(move);
        controller.Move(move * speed * Time.deltaTime);
    }
}
