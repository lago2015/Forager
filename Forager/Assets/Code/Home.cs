using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour {


    private AudioController audioScript;

    private void Awake()
    {
        audioScript = FindObjectOfType<AudioController>();
    }

    void OnTriggerEnter(Collider other)
	{
        if(other.GetComponent<Player>())
        {
            audioScript.SpaceStationReachedSrc(transform.position);
            other.GetComponent<Player>().ReachHome();
        }
		
	}
}
