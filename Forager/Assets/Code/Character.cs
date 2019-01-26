﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour 
{
	public int speed;
	public float rotationSpeed;
	int currentSpeed = 0;
    [HideInInspector]
    public bool bIsDead;
    [HideInInspector]
    public bool bIsCurrentlyMining;
	//protected void Thrust(int direction) 
	protected void Move(int direction)
	{
		//Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + (direction*speed));
		//Debug.Log(newPosition);
		//transform.position = newPosition;
		//transform.position.x += speed;
        if(!bIsDead)
        {
            transform.Translate(0, 0, (direction * speed));
            Camera.main.transform.position = new Vector3(transform.position.x, 50, transform.position.z);
        }
	}
	protected void Rotate(int direction)
	{
        if(!bIsDead)
        {
            transform.Rotate(0, (direction * rotationSpeed), 0);
        }
	}

    //protected void OnFireInput(bool bIsMining)
    //{
    //    if(!bIsDead)
    //    {
    //        bIsCurrentlyMining = bIsMining;
    //        Debug.Log("Mining");
    //    }
    //}
}
