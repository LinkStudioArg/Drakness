using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	TileSpawn tileSpawnscript;

	void Start()
	{
        tileSpawnscript = FindObjectOfType<TileSpawn>();
    }
	void OnTriggerEnter(Collider coll)
	{
        if (tileSpawnscript)
        {
            if (coll.tag == "Tile")
            {
                Rigidbody rigid = coll.gameObject.GetComponent<Rigidbody>();
                tileSpawnscript.DecreaseTileNumber();
                coll.transform.position -= Vector3.forward * 0.02f;
                rigid.useGravity = true;
                rigid.isKinematic = false;
                Destroy(coll.gameObject, 2);
            }
        }
	}
}
