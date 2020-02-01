using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Lighting : MonoBehaviour
{
    public float lightStep = 0.2f;
    int x = 0;
    private Light2D fireLight;

    void Start() {
        fireLight = this.GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fireLight.intensity < 0.9 && x == 0) {
            fireLight.intensity += lightStep * Time.deltaTime;
        } else if (fireLight.intensity > 0.6 && x == 1) {
            fireLight.intensity -= lightStep * Time.deltaTime;
        } else if (fireLight.intensity > 0.9 && x == 0) {
            x = 1;
        } else if (fireLight.intensity < 0.6 && x == 1) {
            x = 0;
        }
    }
}
