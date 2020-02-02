using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CrumblingScript : MonoBehaviour
{
    private Animator animator;
    private float newlength;
    public float secondsToPlatform;
    public AudioClip crumblingSound;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetInteger("crumbling", 1);
        }
        AudioSource audio = this.GetComponent<AudioSource>();
        audio.clip = crumblingSound;
        audio.Play();
    }

    public void DestroyPlatform()
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(Timer(secondsToPlatform));
    }
    public void RestorePlatform()
    {

        this.GetComponent<BoxCollider2D>().enabled = true;
        this.GetComponent<SpriteRenderer>().enabled = true;
    }

/*    public void StartRestore()
    {
        StartCoroutine(ExampleCoroutine());
    }*/

    IEnumerator Timer(float waitTime)
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(waitTime);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        RestorePlatform();
    }

}
