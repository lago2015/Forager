using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAndExplosion : MonoBehaviour {

    public GameObject explosion;

    private void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Player>())
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            col.GetComponent<Player>().PlayerDeath();
            Destroy(gameObject);
        }
    }
}
