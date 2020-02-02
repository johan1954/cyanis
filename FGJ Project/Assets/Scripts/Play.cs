using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public void PlayGame() {
        GlobalAmount.pieces = 0;
        SceneManager.LoadScene("FirstRoom", LoadSceneMode.Single);
    }

    public void ExitGame() {
        Debug.Log("quit");
        Application.Quit();
    }
}
