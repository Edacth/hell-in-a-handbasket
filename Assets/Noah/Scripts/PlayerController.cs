using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] bool grounded;
    Rigidbody rbody;

    public float speed = 1;
    public float speedGrounded = 1;
    public float speedAir = 0.5f;
    public float jumpHeight = 1;

    // Start is called before the first frame update
    void Start()
    {
        grounded = true;
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(grounded && speed != speedGrounded)
        {
            speed = speedGrounded;
        }
        else if(!grounded && speed != speedAir)
        {
            speed = speedAir;
        }

        if(Input.GetAxis("Jump") > 0 && grounded)
        {
            rbody.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.transform.parent = collision.transform;
        grounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        gameObject.transform.parent = null;
        grounded = false;
    }
}
