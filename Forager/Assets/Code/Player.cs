using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character 
{
    private int[] materialInventory =new int[4];
	int amountCarrying = 0;
	int score = 0;
    [HideInInspector]
    public bool bIsMining;
	public Text inventoryAmountDisplay;
	public Text scoreAmountDisplay;
	public Slider boostDisplay;
	// Use this for initialization
	void Start () 
	{
		InputManager.OnMovementInput += Move;
		InputManager.OnRotationInput += Rotate;
        InputManager.OnDashInput += Dash;
        //InputManager.onFireInput += OnFireInput;
        inventoryAmountDisplay.text = "Current Amount: " + amountCarrying;
        scoreAmountDisplay.text = "Score: " + score;

    }

    private void Update()
    {
        if (Input.GetButtonDown("MiningTool"))
        {
            bIsMining = true;
        }
        if (Input.GetButtonUp("MiningTool"))
        {
            bIsMining = false;
        }
    }

    //storing material count for when player goes back to hub
    public void addMaterial(Collectible.MaterialSources currentMaterial)
    {
        switch(currentMaterial)
        {
            case Collectible.MaterialSources.orb:
                materialInventory[0] += 1;
                break;
            case Collectible.MaterialSources.smallAsteroid:
                materialInventory[1] += 3;
                break;
            case Collectible.MaterialSources.medAsteroid:
                materialInventory[2] += 7;
                break;
            case Collectible.MaterialSources.larAsteroid:
                materialInventory[3] += 15;
                break;
        }
    }
    //adds amount of each material to score then resets the material count
    void MaterialCount()
    {
        for(int i=0;i<=materialInventory.Length-1;i++)
        {
            addScore(materialInventory[i]);
            materialInventory[i] = 0;
        }
    }

	public void addToInventory(int amount)
	{
		amountCarrying += amount;
        inventoryAmountDisplay.text = "Current Amount: " + amountCarrying;
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
        scoreAmountDisplay.text = "Score: " + score;
	}
	public void ReachHome()
	{
        if(amountCarrying>0)
        {
            MaterialCount();
        }
		    
		amountCarrying = 0;

        if(inventoryAmountDisplay)
		{
		    inventoryAmountDisplay.text = "Current Amount: " + amountCarrying;
		}
		boostAmount = 100;
		boostDisplay.value = boostAmount;
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
        bIsDead = true;
        //Spawn explosion particle
        Destroy(gameObject);
    }
	public override void Dash()
	{
		boostDisplay.value = boostAmount;
		base.Dash();
	}
}
