using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowUI : MonoBehaviour 
{
	
	public Transform player;
	public Transform home;

	// Update is called once per frame
	void FixedUpdate () 
	{
        if(player)
        {
            Vector3 dir = home.transform.position - player.transform.position;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            transform.eulerAngles = new Vector3(0, 0, angle);
        }
		
	}
}
