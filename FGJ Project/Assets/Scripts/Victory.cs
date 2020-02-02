using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class Victory : MonoBehaviour
{
    private GameObject tablet, breakTablet, infotextbox;
    private GameObject[] piecesAll;
    public AudioClip repairSound;
    public TMP_Text infotext;
    public AudioClip breakSound;
    public bool hasBroken =false;

    void Start ()
    {
        tablet = GameObject.FindWithTag("FullTablet");
        breakTablet = GameObject.FindWithTag("BreakTablet");
        piecesAll = GameObject.FindGameObjectsWithTag("TabletPiece");
        infotextbox = GameObject.FindWithTag("InfoText");
        infotext = infotextbox.GetComponent<TMP_Text>();
    }

    void OnTriggerEnter2D (Collider2D collider) {
        AudioSource audio = this.GetComponent<AudioSource>();
        if (collider.gameObject.tag == "Player") {
            if (GlobalAmount.pieces == 4) {
                tablet.GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("Clara").GetComponent<Movement>().enabled = false;
                StartCoroutine(Winning());
                audio.clip = repairSound;
                audio.Play();
            }
            if (GlobalAmount.pieces == 0 && !hasBroken)
            {
                audio.clip = breakSound;
                audio.Play();
                StartCoroutine(Breaking());
                

            }
        }
    }

    IEnumerator Winning() {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Victory", LoadSceneMode.Single);
    }

    IEnumerator Breaking() {
        yield return new WaitForSeconds(1);
        int y = 3;
        foreach (GameObject tabletPiece in piecesAll)
        {
            Vector2 vector = new Vector2(10, y);
            tabletPiece.GetComponent<SpriteRenderer>().enabled = true;
            tabletPiece.GetComponent<Rigidbody2D>().velocity += vector;
            y--;
        }

        breakTablet.GetComponent<SpriteRenderer>().enabled = false;
        hasBroken = true;
        infotext.enabled = true;
        yield return new WaitForSeconds(3);
        infotext.enabled = false;
        /*        TextAppear();*/

    }
/*
    IEnumerator TextAppear()
    {
        yield return new WaitForSeconds(3);
        infotext.enabled = false;
    }*/
}
