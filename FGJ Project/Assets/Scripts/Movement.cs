using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Movement : MonoBehaviour
{
    public Quaternion originalRotation;
    float rotationSpeed = 1.0f;
    public float runSpeed = 5f;
    public float jumpSpeed = 5f;
    private Animator animator;
    private Rigidbody2D rb;
    public AudioClip clipRun;
    public AudioClip clipJump;
    public AudioClip clipNone;
    private float isWalking = 0f;

    void Start() {
        //Save original rotation
        originalRotation = transform.rotation;
        animator = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        var yVelocity = rb.velocity.y;


        //Move the character 
        if (Quaternion.Angle(transform.rotation, originalRotation) < 45) {
        transform.Translate(horizontal * runSpeed * Time.deltaTime, 0f, 0f);
        }
        transform.Translate(0f, vertical * 1f * Time.deltaTime, 0f);

        //Flip the character
        Vector3 characterScale = transform.localScale; 
        if (yVelocity < -0.9) {
            animator.SetInteger("walking", 2);
            isWalking = 2f;
            StartCoroutine(PlaySound());
        } else if (horizontal < 0 && Quaternion.Angle(transform.rotation, originalRotation) < 45) {
            characterScale.x = -1;
            animator.SetInteger("walking", 1);
            isWalking = 1f;
            StartCoroutine(PlaySound());
        } else if (horizontal > 0 && Quaternion.Angle(transform.rotation, originalRotation) < 45) {
            characterScale.x = 1;
            animator.SetInteger("walking", 1);
            isWalking = 1f;
            StartCoroutine(PlaySound());
        }  else {
            animator.SetInteger("walking", 0);
            isWalking = 0f;
            StartCoroutine(PlaySound());
        }
        transform.localScale = characterScale;

        //Reset rotation
        if (Input.GetKey("space")) {
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.time * rotationSpeed);
            transform.Translate(0f, jumpSpeed * Time.deltaTime, 0f);
        }

    }

    IEnumerator PlaySound() {
        AudioSource audio = this.GetComponent<AudioSource>();
        
        if (isWalking == 1f) {
            if (audio.clip != clipRun) {
                audio.loop = true;
                audio.clip = clipRun;
                audio.Play();
                yield return new WaitForSeconds(1);
            }
        } else if (isWalking == 2f) {
            if (audio.clip != clipJump) {
                audio.loop = false;
                audio.clip = clipJump;
                audio.Play();
            }
        } 
        else {
            audio.clip = clipNone;
            audio.Play();
        }
    }

    public void burnBabyBurn() {
        animator.SetInteger("walking", 3);
    }
}
