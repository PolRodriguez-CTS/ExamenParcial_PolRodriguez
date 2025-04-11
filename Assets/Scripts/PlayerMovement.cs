using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private GroundSensor _groundSensor;
    public float playerSpeed = 6.5f;
    public float jumpForce = 10.5f;
    private float horizontalInput;
    
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _groundSensor = GetComponentInChildren<GroundSensor>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        if(horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if(horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if(Input.GetButtonDown("Jump") && _groundSensor.isGrounded)
        {
            _rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    } 
    
    void FixedUpdate()
    {
        _rigidBody.velocity = new Vector2(horizontalInput*playerSpeed, _rigidBody.velocity.y);
    }
}
