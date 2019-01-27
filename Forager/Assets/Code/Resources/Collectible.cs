using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {

    public enum MaterialSources { orb,smallAsteroid,medAsteroid,larAsteroid}
    public MaterialSources currentMaterial;
    private bool bIsDead;
    private Player playerScript;
	private void OnTriggerEnter(Collider other)
	{
        playerScript = other.GetComponent<Player>();
        if(playerScript)
        {
            //add item to users inventory
            playerScript.addToInventory(1);
            playerScript.addMaterial(currentMaterial);
            if(!bIsDead)
            {
                GetComponent<PlayAudio>().PlayThisAudio("materialCollected");
                bIsDead = true;
            }
            GetComponent<Collider>().enabled = false;
            Destroy(gameObject,1.5f);
        }
		
	}
}
