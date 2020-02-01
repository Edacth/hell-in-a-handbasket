﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    public float JumpVelocity = 5f;
    public float GroundedSkin = 0.05f;
    public LayerMask mask;
    public float FallMultiplier = 2.5f;
    public float LowJumpMultiplier = 2f;
    public Transform CameraHolderX;
    public Transform CameraHolderY;

    Rigidbody rbody;
    bool jumpframe = false;
    bool grounded;
    bool jumphold = false;

    Vector3 playerSize;
    Vector3 boxSize;

    private void Awake()
    {
        playerSize = new Vector3(GetComponent<CapsuleCollider>().radius * 2, GetComponent<CapsuleCollider>().height, GetComponent<CapsuleCollider>().radius * 2);
        boxSize = new Vector3(playerSize.x, GroundedSkin, playerSize.z);
    }

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(CameraHolderX.localRotation * (new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed * Time.deltaTime), Space.Self);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            //Debug.Log("jd");
            jumpframe = true;
            jumphold = true;
        }
        if (Input.GetButtonUp("Jump"))
        {
            //Debug.Log("ju");
            jumphold = false;
        }
    }

    private void FixedUpdate()
    {
        if (jumpframe)
        {
            //Debug.Log("je");
            //rbody.AddForce(Vector3.up * JumpVelocity, ForceMode.Force);
            rbody.velocity += Vector3.up * JumpVelocity;
            jumpframe = false;
        }
        else
        {
            Vector3 boxCenter = transform.position + Vector3.down * (playerSize.y + boxSize.y) * 0.5f;
            grounded = (Physics.OverlapBox(boxCenter, boxSize * 0.5f) != null);
        }

        if (rbody.velocity.y < 0)
        {
            //rbody.AddForce(Vector3.up * Physics.gravity.y * (FallMultiplier - 1) * Time.deltaTime);
            rbody.velocity += Vector3.up * Physics.gravity.y * (FallMultiplier - 1) * Time.deltaTime;
        }
        else if (rbody.velocity.y > 0 && !jumphold)
        {
            //rbody.AddForce(Vector3.up * Physics.gravity.y * (LowJumpMultiplier - 1) * Time.deltaTime);
            rbody.velocity += Vector3.up * Physics.gravity.y * (LowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
