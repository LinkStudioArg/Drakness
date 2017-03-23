using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTrigger : MonoBehaviour {

    
    TileSpawn tileSpawnscript;
    private ScoreManager scoreManager;
    bool touched = false;
    Color touchedColor;
    [SerializeField]
    MeshRenderer rend;
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        touched = false;
        tileSpawnscript = FindObjectOfType<TileSpawn>();
        touchedColor = tileSpawnscript.GetDarkColor();

    }

    private void Update()
    {
        if (touched)
        {
            rend.material.color = Color.Lerp(rend.material.color, touchedColor, 0.07f);
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (tileSpawnscript)
        {
            if (coll.tag == "Player")
            {
                Rigidbody rigid = transform.parent.GetComponent<Rigidbody>();
                tileSpawnscript.DecreaseTileNumber();
                rigid.useGravity = true;
                rigid.isKinematic = false;
                scoreManager.AddCurrentScore(1);                
                Destroy(transform.parent.gameObject, 7);
            }
        }
    }
    void OnTriggerEnter(Collider coll)
    {
        if (tileSpawnscript)
        {
            if (coll.tag == "Player")
            {
                touched = true;
            }
        }
    }
}
