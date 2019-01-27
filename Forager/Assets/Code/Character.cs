using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour 
{
	public enum State {Idle, Moving, Rotating, Dashing, Dead}
	public State currentState;
	public int speed;
	public float rotationSpeed;
	int currentSpeed = 0;
    [HideInInspector]
    public bool bIsDead;
    [HideInInspector]
    public bool bIsCurrentlyMining;
	protected bool dashing = false;
	
	protected int boostAmount = 100;
	private int amountUsedToBoost = 1;
	//protected void Thrust(int direction)
	void Start()
	{
		currentState = State.Idle;
	}
	protected void Move(int direction)
	{
		//Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + (direction*speed));
		//Debug.Log(newPosition);
		//transform.position = newPosition;
		//transform.position.x += speed;
        if(!bIsDead)
        {
			currentState = State.Moving;
            transform.Translate(0, 0, (direction * speed));
            Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -150);
        }
	}
	protected void Rotate(int direction)
	{
        if(!bIsDead)
        {
			currentState = State.Moving;
            transform.Rotate(0, (direction * rotationSpeed), 0);
        }
	}
	public virtual void Dash()
	{
		if(!bIsDead)
        {
			if(boostAmount > 0)
			{
				currentState = State.Moving;
				transform.Translate(0, 0, (1 * (speed*2)));
                Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -150);
                boostAmount = boostAmount - amountUsedToBoost;
			}
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
