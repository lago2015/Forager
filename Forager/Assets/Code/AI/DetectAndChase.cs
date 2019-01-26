using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAndChase : Character {

    private GameObject playerRef;
    private bool isPlayerNear;
    private float detectionRadius;
    public float loseInterestRadius;
    private SphereCollider collider;
    private void Awake()
    {
        //Getter component for sphere collider
        collider = GetComponent<SphereCollider>();
        isPlayerNear = false;
        enabled = false;
        //saving the current radius of the enemy
        detectionRadius = collider.radius;
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        //if player is near then pursue the basterd!
		if(isPlayerNear)
        {
            ChasePlayer();
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
	}

    void ChasePlayer()
    {
        //apply rotation
        if (rotationSpeed > 0)
        {
            Quaternion rotation = Quaternion.LookRotation(playerRef.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }
        //apply movement
        if (speed > 0)
        {
            if (transform.parent)
            {
                transform.parent.position += transform.forward * speed * Time.deltaTime;
            }
            else
            {
                transform.position += transform.forward * speed * Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.GetComponent<Player>())
        {
            //turn on FixedUpdate() so the gameobject can pursue
            enabled = true;
            isPlayerNear = true;
            //get player reference
            playerRef = col.gameObject;

            collider.radius = loseInterestRadius;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if(col.GetComponent<Player>())
        {
            collider.radius = detectionRadius;
            enabled = false;
            isPlayerNear = true;
        }
    }
}
