using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    private AudioSource myAudioSource;
    private Animator anim;
    private ScoreManager scoreManager;
    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();

        myAudioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider coll)
    {

        scoreManager.AddCurrentScore(5);
        anim.SetBool("destroy", true);
        myAudioSource.Play();
    }

    public void DestroyItem()
    {
        Destroy(gameObject);
    }
}
