using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Quaternion originalRotation;
    float rotationSpeed = 1.0f;
    public float runSpeed = 5f;
    public float jumpSpeed = 5f;
    private Animator animator;
    private Rigidbody2D rb;

    //Save original rotation
    void Start() {
        originalRotation = transform.rotation;
        animator = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        var xVelocity = rb.velocity.x;
        //Move the character 
        transform.Translate(horizontal * runSpeed * Time.deltaTime, 0f, 0f);
        transform.Translate(0f, vertical * 1f * Time.deltaTime, 0f);

        //Flip the character
        Vector3 characterScale = transform.localScale;  
        if (horizontal < 0) {
            characterScale.x = -1;
            animator.SetInteger("walking", 1);
        } else if (horizontal > 0) {
            characterScale.x = 1;
            animator.SetInteger("walking", 1);
        } else if (xVelocity != 0) {
            animator.SetInteger("walking", 2);
        } else {
            animator.SetInteger("walking", 0);
        }
        transform.localScale = characterScale;

        //Reset rotation
        if (Input.GetKey("space")) {
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.time * rotationSpeed);
            transform.Translate(0f, jumpSpeed * Time.deltaTime, 0f);
            animator.SetInteger("walking", 2);
        }

    }
}
