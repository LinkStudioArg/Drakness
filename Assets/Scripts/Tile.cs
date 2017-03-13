using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    TileSpawn tileSpawnscript;
    // Use this for initialization
    void Start () {
        tileSpawnscript = FindObjectOfType<TileSpawn>();
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(25);
        tileSpawnscript.DecreaseTileNumber();
        Destroy(this.gameObject);
    }
}
