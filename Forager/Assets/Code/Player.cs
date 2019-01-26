using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character 
{
	//string[] inventory = new string[5]; //probaly turn into list later
	int amountCarrying = 0;
	int score = 0;
	
	public Text inventoryAmountDisplay;
	public Text scoreAmountDisplay;
	// Use this for initialization
	void Start () 
	{
		InputManager.OnMovementInput += Move;
		InputManager.OnRotationInput += Rotate;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void addToInventory(int amount)
	{
		amountCarrying += amount;
		inventoryAmountDisplay.text = amountCarrying.ToString();
	}
	public int AmountCarrying
	{
		get
		{
			return amountCarrying;
		}
	}
	public void addScore(int amount)
	{
		score += amount;
		scoreAmountDisplay.text = score.ToString();
	}
	public void ReachHome()
	{
		addScore(amountCarrying);
		amountCarrying = 0;
		inventoryAmountDisplay.text = amountCarrying.ToString();
	}

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Enemy") && !col.gameObject.GetComponent<Collider>().isTrigger)
        {
            PlayerDeath();
        }
    }

    public void PlayerDeath()
    {
        //Spawn explosion particle
        Destroy(gameObject);
    }
}
