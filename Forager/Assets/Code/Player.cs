using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character 
{
	string[] inventory = new string[5]; //probaly turn into list later
	// Use this for initialization
	void Start () 
	{
		InputManager.OnMovementInput += Move;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
