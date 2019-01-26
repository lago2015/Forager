using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowUI : MonoBehaviour 
{
	public int rotationSpeed;
	public Transform player;
	public Transform home;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 dir = home.transform.position - player.transform.position;
		
		float angle = Mathf.Atan2(dir.x, dir.z)*Mathf.Rad2Deg;
		
		transform.eulerAngles = new Vector3(0, 0, angle * -1);
	}
}
