using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private float MoveLR;
    //left and right, Up down moves
    private float MoveUD;
    private Rigidbody rb;

    Vector3 mouse_pos;
    Transform target = null;
    Vector3 object_pos;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        mouse_pos = Input.mousePosition;
        mouse_pos.y = 8.25f; //distance from camera n player
        transform.LookAt(mouse_pos);
        Debug.Log(transform.position);

        MoveLR = Input.GetAxis("Horizontal");
        MoveUD = Input.GetAxis("Vertical");
        //x left n right, y FIXED, z up n down
        rb.velocity = new Vector3(speed * MoveLR, 0.55f, rb.velocity.x);
        rb.velocity = new Vector3(rb.velocity.z, 0.55f, speed * MoveUD);


    }
}
