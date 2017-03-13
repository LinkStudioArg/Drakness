using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTrigger : MonoBehaviour {

    
    TileSpawn tileSpawnscript;
    GameManager gm;

    bool touched = false;
    Color touchedColor;
    [SerializeField]
    MeshRenderer rend;
    void Start()
    {
        touched = false;
        gm = FindObjectOfType<GameManager>();
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
                gm.AddScore(1);
                
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
