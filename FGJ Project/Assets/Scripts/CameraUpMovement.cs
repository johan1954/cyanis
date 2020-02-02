using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUpMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (this.gameObject.tag == "DoorTriggerUp")
        {
            if (other.gameObject.tag == "Player")
            {
                Camera.main.transform.position += (new Vector3(0, 8, 0));
            }
        }




    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (this.gameObject.tag == "DoorTriggerUp")
        {
            if (other.gameObject.tag == "Player")
            {
                Camera.main.transform.position -= (new Vector3(0, 8, 0));
            }
        }

    }

}
