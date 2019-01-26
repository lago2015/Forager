using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	private void OnTriggerEnter(Collider other)
	{
		//add item to users inventory
		other.GetComponent<Player>().addToInventory(1);
		Destroy(gameObject);
	}
}
