using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class Death : MonoBehaviour
{

    public AudioClip deathSound;

    void OnTriggerEnter2D(Collider2D other) {
        GameObject.Find("Clara").GetComponent<Movement>().enabled = false;
        AudioSource audio = this.GetComponent<AudioSource>();
        audio.clip = deathSound;
        audio.Play();
        StartCoroutine(DeathTimer());
    }

    IEnumerator DeathTimer() {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
