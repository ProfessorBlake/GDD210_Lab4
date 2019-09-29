using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxyController : MonoBehaviour
{
	[Header("Movement")]	//The Header attribute lets you add labels to your script in the editor.
	public Rigidbody2D Rb;
	public float Speed;
	public float JumpSpeed;

	[Header("Audio")]
	public AudioSource AudioSource;
	public AudioClip GetCoin;
	public AudioClip HitSpike;
	public AudioClip Jump;

	private bool onGround;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (onGround)
			{
				Rb.AddForce(new Vector2(0f, JumpSpeed));
				Rb.AddTorque(Random.Range(-50f, 50f));
				onGround = false;
				AudioSource.PlayOneShot(Jump);
			}
		}
	}

	private void FixedUpdate()
	{
		float hsp = 0;

		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			hsp = -Speed;
		else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			hsp = Speed;

		Rb.AddForce(new Vector2(hsp, 0f) * Time.fixedDeltaTime);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Coin")
		{
			AudioSource.PlayOneShot(GetCoin);
			Destroy(collision.gameObject);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Spike")
		{
			AudioSource.PlayOneShot(HitSpike);
			Rb.angularVelocity = 0f;
			Rb.velocity = Vector3.zero;
			Rb.MovePosition(Vector3.zero);
		}
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			if (collision.transform.position.y < transform.position.y)
			{
				onGround = true;
			}
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			onGround = false;
		}
	}
}
