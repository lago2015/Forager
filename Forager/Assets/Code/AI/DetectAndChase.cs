﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAndChase : Character {

    private GameObject playerRef;
    private bool isPlayerNear;
    private float detectionRadius;
    public float loseInterestRadius;
    private Vector3 returnPoint;
    private SphereCollider collider;
    private void Awake()
    {
        //Getter component for sphere collider
        collider = GetComponent<SphereCollider>();
        isPlayerNear = false;
        
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
        }
        else if(Vector3.Distance(transform.position,returnPoint)<=10 && returnPoint!=Vector3.zero)
        {
            ReturnPoint();
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    void ReturnPoint()
    {
        //apply rotation
        if (rotationSpeed > 0)
        {
            Quaternion rotation = Quaternion.LookRotation(returnPoint - transform.position);
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

    void ChasePlayer()
    {
        //apply rotation
        if (rotationSpeed > 0)
        {
            if(playerRef)
            {
                Quaternion rotation = Quaternion.LookRotation(playerRef.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
            }
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
            isPlayerNear = true;
            //get player reference
            playerRef = col.gameObject;
            returnPoint = transform.position;
            collider.radius = loseInterestRadius;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if(col.GetComponent<Player>())
        {
            collider.radius = detectionRadius;
            isPlayerNear = true;
        }
    }
}
