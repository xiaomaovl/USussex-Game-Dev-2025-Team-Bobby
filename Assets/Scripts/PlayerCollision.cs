using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Transform headPos;
    public Transform floorPos;
    public Rigidbody rb;
    public float springStrength;
    CapsuleCollider playerColider;
    void Start()
    {
        playerColider = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float height = headPos.position.y - floorPos.position.y;
        playerColider.height = height;
        rb.AddForce(((headPos.position - Vector3.up * height / 2) - transform.position).normalized * springStrength);// * (Vector3.Distance(headPos.position, transform.position)+0));
        //transform.position = headPos.position - Vector3.up * height / 2;
    }
}
