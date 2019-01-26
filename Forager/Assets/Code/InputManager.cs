using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour 
{
	public delegate void DirectionInput(int direction);
	public static event DirectionInput OnDirectionInput;
	
	public delegate void MovementInput(int direction);
	public static event MovementInput OnMovementInput;
	
	public delegate void RotationInput(int direction);
	public static event RotationInput OnRotationInput;
	
	public delegate void DashInput();
	public static event DashInput OnDashInput;

    //public delegate void FireInput(bool isFiring);
    //public static event FireInput onFireInput;

    
    bool bIsMining;
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
		
		/*if(movementInput != 0 && currentMovementDirection != movementInput)
		{
			currentMovementDirection = movementInput;
		}
		if(rotationInput != 0 && currentRotationDirection != rotationInput)
		{
			currentRotationDirection = rotationInput;
		}*/
		//Debug.Log(currentMovementDirection);
		if(OnMovementInput != null)
		{
			//if(currentMovementDirection != movementInput)
			//{
				currentMovementDirection = movementInput;
				OnMovementInput(currentMovementDirection);
			//}
		}
		if(OnRotationInput != null)
		{
			//if(currentRotationDirection != rotationInput)
			//{
				currentRotationDirection = rotationInput;
				OnRotationInput(currentRotationDirection);
			//}
		}
		if(Input.GetButton("Fire2"))
		{
			OnDashInput();
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
			return -1;
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
			return -1;
		}
		return 0;
	}
}
