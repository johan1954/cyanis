using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBloodAnim : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        animator.SetInteger("ded", 1);
    }
}
