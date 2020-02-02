﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D collider) {
        if (collider.gameObject.tag == "Player") {
            if (GlobalAmount.pieces == 4) {
                SceneManager.LoadScene("Victory", LoadSceneMode.Single);
                Debug.Log("Victory!");
            }
        }
    }
}
