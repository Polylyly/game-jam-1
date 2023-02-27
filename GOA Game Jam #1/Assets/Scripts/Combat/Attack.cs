using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool InLeftHand;
    private bool InRightHand;

    public static Attack instance;

    public enum objectType
    {
        Weapon,
        Food
    };

    [Header("Attack Info")]
    public Transform attackPoint;
    public float damage, range;
    public LayerMask attackMask;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //player has nothing in their hand at beginning of game
        InLeftHand = false;
        InRightHand = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AttackMethod();
        }
    }

    void AttackMethod()
    {
        Collider[] hitColliders = Physics.OverlapSphere(attackPoint.position, range, attackMask);
        foreach (Collider collider in hitColliders)
        {
            Debug.Log("Damage");
        }
    }
}
