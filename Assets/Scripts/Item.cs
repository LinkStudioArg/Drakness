using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    private AudioSource myAudioSource;
    private Animator anim;
    private GameManager gm;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        gm = FindObjectOfType<GameManager>();
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider coll)
    {
        
        gm.AddScore(5);
        anim.SetBool("destroy", true);
        myAudioSource.Play();
    }

    public void DestroyItem()
    {
        Destroy(gameObject);
    }
}
