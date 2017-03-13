using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTrigger : MonoBehaviour {

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {

            col.GetComponent<Rigidbody>().AddForce(Vector3.down *50, ForceMode.Force);
        }
    }
}
