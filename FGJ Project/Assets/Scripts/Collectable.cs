using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collectable : MonoBehaviour
{
    private GameObject text;
    private TMP_Text textMeshPro;
    // Start is called before the first frame update
    void Start()
    {

        text = GameObject.FindWithTag("UIText");
        textMeshPro = text.GetComponent<TMP_Text>();
        //textMeshPro.text = "Lol heeh";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GlobalAmount.pieces++;
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = false;
            textMeshPro.text = (GlobalAmount.pieces + "/4");
        } 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
