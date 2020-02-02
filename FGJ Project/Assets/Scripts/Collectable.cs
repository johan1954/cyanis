using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Experimental.Rendering.Universal;


[RequireComponent(typeof(AudioSource))]
public class Collectable : MonoBehaviour
{
    private GameObject text;
    private TMP_Text textMeshPro;
    public AudioClip pickupSound;
    private Light2D highlight;
    public bool debug;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.FindWithTag("UIText");
        textMeshPro = text.GetComponent<TMP_Text>();
        highlight = this.GetComponentInChildren<Light2D>();
        if (debug)
        {
            GlobalAmount.pieces = 4;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GlobalAmount.pieces++;
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = false;
            textMeshPro.text = (GlobalAmount.pieces + "/4");
            AudioSource audio = this.GetComponent<AudioSource>();
            audio.clip = pickupSound;
            audio.Play();
            highlight.enabled = false;
        } 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
