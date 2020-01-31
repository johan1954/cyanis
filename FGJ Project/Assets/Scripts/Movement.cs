using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //Move the character
        transform.Translate(Input.GetAxis("Horizontal") * 15f * Time.deltaTime, 0f, 0f);

        //Flip the character
        Vector3 characterScale = transform.localScale;  
        if (Input.GetAxis("Horizontal") < 0) {
            characterScale.x = -1;
        }  
        if (Input.GetAxis("Horizontal") > 0) {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;
    }
}
