using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireworks : MonoBehaviour
{
	public ParticleSystem FireworkPS;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.F))
			FireworkPS.Emit(1);
	}
}
