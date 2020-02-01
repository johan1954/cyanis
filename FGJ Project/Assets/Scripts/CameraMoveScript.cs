using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveScript : MonoBehaviour
{
    private Camera mainCamera;
    private Camera secondCamera;
    private Vector3 cameraUp;
    public Vector3 temp;
    public int playerX;


    // Start is called before the first frame update
    void Start()
    {   
        temp = new Vector3(23.5f, 0, 0);
        cameraUp = new Vector3(0, 8, 0);
        playerX = 3;

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (this.gameObject.tag == "DoorTriggerRight")
            {
                //Debug.Log("Gameobject collided with " + other.name);
                other.transform.position += (new Vector3(playerX, 0, 0));
                Camera.main.transform.position += temp;

            }
            if (this.gameObject.tag == "DoorTriggerLeft")
            {
                //Debug.Log("Gameobject collided with " + other.name);
                other.transform.position -= (new Vector3(playerX, 0, 0));
                Camera.main.transform.position -= temp;
            }
            if (this.gameObject.tag == "DoorTriggerUp")
            {
                //Debug.Log("Gameobject collided with " + other.name);
                Camera.main.transform.position += cameraUp;
        
            }
            if (this.gameObject.tag == "DoorTriggerDown")
            {
                //Debug.Log("Gameobject collided with " + other.name);
                Camera.main.transform.position -= cameraUp;
            }

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
