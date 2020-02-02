using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnBabyBurn : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        GameObject.Find("Clara").GetComponent<Movement>().burnBabyBurn();
    }
}
