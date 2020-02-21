using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

	public GameObject player;
	public float camVel = 0.25f;
	private bool segueHeroi;
	public Vector3 ultimaAlvoPos;
	public Vector3 velAtual;

	// Use this for initialization
	void Start()
	{

		segueHeroi = true;
		ultimaAlvoPos = player.transform.position;

	}

	// Update is called once per frame
	void FixedUpdate()
	{

		if(segueHeroi)
		{
			if(player.transform.position.x>=transform.position.x && player.transform.position.x<= 676)
			{
				Vector3 novaCamPos = Vector3.SmoothDamp(transform.position, player.transform.position, ref velAtual, camVel);
				transform.position = new Vector3(novaCamPos.x, 14.6f, transform.position.z);
				ultimaAlvoPos = player.transform.position;
			}
			
		}

		

	}
}

