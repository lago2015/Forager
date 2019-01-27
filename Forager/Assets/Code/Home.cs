using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour {




    void OnTriggerEnter(Collider other)
	{
        if(other.GetComponent<Player>())
        {
            GetComponent<PlayAudio>().PlayThisAudio("reachedHome");
            other.GetComponent<Player>().ReachHome();
        }
		
	}
}
