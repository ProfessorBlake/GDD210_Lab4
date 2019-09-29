using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wormhole : MonoBehaviour
{
	public ParticleSystem WormholePS;

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.W))
		{
			WormholePS.Emit(50);
		}
	}
}
