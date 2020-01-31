using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveScript : MonoBehaviour
{
    private Camera mainCamera;
    private Camera secondCamera;
    public Vector3 temp;


    // Start is called before the first frame update
    void Start()
    {   
        temp = new Vector3(23.5f, 0, 0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (this.name == "DoorTriggerRight") {
            Debug.Log("Gameobject collided with " + other.name);
            other.transform.position += (new Vector3(10, 0, 0));
            Camera.main.transform.position += temp;
            
        }
        if (this.name == "DoorTriggerLeft") {
            Debug.Log("Gameobject collided with " + other.name);
            other.transform.position -= (new Vector3(10, 0, 0));
            Camera.main.transform.position -= temp;
            this.transform.position -= temp;
        }



    }

    void OnTriggerExit2D(Collider2D other)
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
