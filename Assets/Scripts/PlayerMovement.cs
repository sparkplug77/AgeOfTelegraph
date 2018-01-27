using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float jumpSpeed;
    Vector3 movement;
    float timer;
    bool isGrounded;
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = false;
        movement = new Vector3(1, 0, 1);
	}
	
    void OnCollisionStay(Collision Other)
    {
        isGrounded = true; 
    }

	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyUp(KeyCode.W))
            rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
        if (Input.GetKeyUp(KeyCode.S))
            rb.MovePosition(transform.position - transform.forward * speed * Time.deltaTime);


        if (Input.GetKeyUp(KeyCode.D))
            rb.MovePosition(transform.position + transform.right * speed * Time.deltaTime);
        if (Input.GetKeyUp(KeyCode.A))
            rb.MovePosition(transform.position - transform.right * speed * Time.deltaTime);

        if (isGrounded)
        {
            rb.AddForce(new Vector3(0.0f, 2.0f, 0.0f) * jumpSpeed, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
