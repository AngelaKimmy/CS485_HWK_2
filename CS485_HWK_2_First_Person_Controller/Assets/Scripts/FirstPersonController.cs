﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    public LayerMask ground;
    public Transform feet;

    private Vector3 direction;
    private Rigidbody rbody;

    private float rotationSpeed = 1f;
    private float minY = -60f;
    private float maxY = 60f;
    private float rotationY = 10f;
    private float rotationX = 0f;

    public GameObject arrow;
    public Transform arrowSpawn;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5.0f;
        jumpHeight = 3.0f;
        rbody = GetComponent<Rigidbody>();
           
    }

    // Update is called once per frame
    void Update()
    {
        direction = Vector3.zero;
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        direction = direction.normalized;
        if(direction.x != 0)
        {
            rbody.MovePosition(rbody.position + transform.right * direction.x * speed * Time.deltaTime);
        }
        if (direction.z != 0)
        {
            rbody.MovePosition(rbody.position + transform.forward * direction.z * speed * Time.deltaTime);
        }

        rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * rotationSpeed;
        rotationY += Input.GetAxis("Mouse Y") * rotationSpeed;
        rotationY = Mathf.Clamp(rotationY, minY, maxY);
        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);


        bool isGrounded = Physics.CheckSphere(feet.position, 0.1f, ground, QueryTriggerInteraction.Ignore);
        Debug.Log("Before jump isGrounded = " + isGrounded);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rbody.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
            Debug.Log("isGrounded = " + isGrounded);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
            Debug.Log("Fire1");
        }

    }

    void Fire()
    {
        var bullet = (GameObject)Instantiate(
            arrow,
            arrowSpawn.position,
            arrowSpawn.rotation);
        arrow.GetComponent<Rigidbody>().velocity = arrow.transform.forward * 6;
        Destroy(arrow, 2.0f);
    }
}