﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAndChase : Character {

    private GameObject playerRef;
    [HideInInspector]
    public bool isPlayerNear;
    private float detectionRadius;
    public float loseInterestRadius;
    private Vector3 returnPoint;
    private SphereCollider DetectionCollider;
    private FindRandomPoint positionSelectorScript;
	public int chaseSpeed;
    public Animator animComp;
    private void Awake()
    {
        //Getter component for sphere collider
        DetectionCollider = GetComponent<SphereCollider>();
        isPlayerNear = false;
        positionSelectorScript = GetComponent<FindRandomPoint>();
        //saving the current radius of the enemy
        detectionRadius = DetectionCollider.radius;
        returnPoint = positionSelectorScript.FindNewPosition();
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        //if player is near then pursue the basterd!
		if(isPlayerNear&&playerRef)
        {
            if(Vector3.Distance(playerRef.transform.position,transform.position)<=loseInterestRadius)
            {
                ChasePlayer();
            }
            else
            {
                isPlayerNear = false;
            }
        }
        else if(returnPoint!=Vector3.zero)
        {
            ReturnPoint();
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    void ReturnPoint()
    {
        if(animComp)
        {
            animComp.SetBool("isChasing", false);
        }
        //apply rotation
        if (rotationSpeed > 0)
        {
            Quaternion rotation = Quaternion.LookRotation(returnPoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }
        //apply movement
        if (speed > 0)
        {
            transform.position += transform.forward * speed * Time.deltaTime;

        }
        if (Vector3.Distance(returnPoint,transform.position)<=1)
        {
            returnPoint = positionSelectorScript.FindNewPosition();
            DetectionCollider.radius=detectionRadius;
        }
    }

    void ChasePlayer()
    {
        if (animComp)
        {
            animComp.SetBool("isChasing", true);
        }
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
        if (chaseSpeed > 0)
        {
            transform.position += transform.forward * chaseSpeed * Time.deltaTime;

        }
        if(Vector3.Distance(playerRef.transform.position,transform.position)<=5.6f)
        {
            playerRef.GetComponent<Player>().PlayerDeath();
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
            DetectionCollider.radius=1;
        }
        else if(col.GetComponent<Home>())
        {
            isPlayerNear = false;
            StartCoroutine(WaitToGetAway());
        }
    }

    //private void OnTriggerExit(Collider col)
    //{
    //    if(col.GetComponent<Player>())
    //    {
    //        DetectionCollider.radius=detectionRadius;
    //        isPlayerNear = false;
    //    }
    //}
    
    IEnumerator WaitToGetAway()
    {
        yield return new WaitForSeconds(5f);
        DetectionCollider.radius = detectionRadius;
    }
}
