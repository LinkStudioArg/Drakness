using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerMovement : MonoBehaviour {

    public float speed;
    public float rotationSpeed;
    GameManager gm;
	// Use this for initialization
	void Start () {
        gm = FindObjectOfType<GameManager>();
        StartCoroutine(CheckDead());
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float direction = CrossPlatformInputManager.GetAxisRaw("Horizontal");

        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
        transform.Rotate(Vector3.up * rotationSpeed * direction * Time.fixedDeltaTime);
    }

    IEnumerator CheckDead()
    {
        yield return new WaitForSeconds(1);
        if (transform.position.y < -10)
        {
            Debug.Log("Dead");
            gm.GameOver();
        }
        else
        {
            StartCoroutine(CheckDead());
        }
    }
}
