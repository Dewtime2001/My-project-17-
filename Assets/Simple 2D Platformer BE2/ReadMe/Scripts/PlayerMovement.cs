using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
     Rigidbody2D rb2d;
     
     Vector2 moveInput;
     
     float move;
    [SerializeField]  float speed;

    [SerializeField]  float jumpForce;
    [SerializeField]  bool isjumeping;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        /*move = Input.GetAxis("Horizontal");
        rb2d.linearVelocity = new Vector2(move * speed, rb2d.linearVelocity.y);*/

        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb2d.AddForce( moveInput * speed);
        
        
        if (Input.GetButtonDown("Jump")&& !isjumeping)
        {
            rb2d.AddForce(new Vector2(rb2d.linearVelocity.x, jumpForce));
            Debug.Log("Jump!");
        }
    }

    private void PolygonCollider2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isjumeping = false;
        }
        
    }
    private void OncollisionExit2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isjumeping = true;
        }
    }
}

