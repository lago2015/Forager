using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {

    public enum MaterialSources { orb,smallAsteroid,medAsteroid,larAsteroid}
    public MaterialSources currentMaterial;

    private Player playerScript;
	private void OnTriggerEnter(Collider other)
	{
        playerScript = other.GetComponent<Player>();
        if(playerScript)
        {
            //add item to users inventory
            playerScript.addToInventory(1);
            playerScript.addMaterial(currentMaterial);
            Destroy(gameObject);
        }
		
	}
}
