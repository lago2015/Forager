﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour 
{
	public delegate void DirectionInput(int direction);
	public static event DirectionInput OnDirectionInput;
	
	public delegate void MovementInput(int direction);
	public static event MovementInput OnMovementInput;
	
	public delegate void RotationInput(int direction);
	public static event MovementInput OnRotationInput;
	
	int currentMovementDirection = 0;
	int currentRotationDirection = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		int movementInput = GetMovementInput();
		int rotationInput = GetRotationInput();
		
		if(OnMovementInput != null)
		{
			if(currentMovementDirection != movementInput)
			{
				currentMovementDirection = movementInput;
				OnMovementInput(currentMovementDirection);
			}
		}
		if(rotationInput != null)
		{
			if(currentRotationDirection != rotationInput)
			{
				currentRotationDirection = rotationInput;
				OnRotationInput(currentRotationDirection);
			}
		}
		
	}
	int GetPlayerDirectionalInput()
	{
		if(Input.GetAxisRaw("Vertical") >= 1)
		{
			return 1;
		}
		else if(Input.GetAxisRaw("Vertical") <= -1)
		{
			return 3;
		}
		else if(Input.GetAxisRaw("Horizontal") >= 1)
		{
			return 0;
		}
		else if(Input.GetAxisRaw("Horizontal") <= -1)
		{
			return 2;
		}
		return 4;
	}
	int GetMovementInput()
	{
		if(Input.GetAxisRaw("Vertical") >= 1)
		{
			return 1;
		}
		else if(Input.GetAxisRaw("Vertical") <= -1)
		{
			return 2;
		}
		return 0;
	}
	int GetRotationInput()
	{
		if(Input.GetAxisRaw("Horizontal") >= 1)
		{
			return 1;
		}
		else if(Input.GetAxisRaw("Horizontal") <= -1)
		{
			return 2;
		}
		return 0;
	}
}