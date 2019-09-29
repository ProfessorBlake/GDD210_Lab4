using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio1_MusicManager : MonoBehaviour
{
	public AudioSource AudioSource; //This is the component that handles playing the sounds, and emitting them into the scene.
	public AudioClip MusicClip1;	//Our music clips.
	public AudioClip MusicClip2;

	public Text MusicText;
	private bool isPaused;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			AudioSource.Play();		//Play will start the current clip of the AudioSource from the beginning.

			if(isPaused == true)
			{
				isPaused = false;
			}
		}
		else if (Input.GetKeyDown(KeyCode.S))
		{
			AudioSource.Stop();

			if (isPaused == true)
			{
				isPaused = false;
			}
		}
		else if (Input.GetKeyDown(KeyCode.Space))
		{
			if (isPaused == false)
			{
				AudioSource.Pause();		//Pauses the clip, and we store our pause state as the bool 'isPaused'.
				isPaused = true;
			}
			else
			{
				AudioSource.UnPause();
				isPaused = false;
			}
		}
		else if (Input.GetKeyDown(KeyCode.N))
		{
			if (AudioSource.clip == MusicClip1)		//Check which clip is loaded, and change to the other clip.
			{
				AudioSource.clip = MusicClip2;
			}
			else
			{
				AudioSource.clip = MusicClip1;
			}
		}

		//===========================================================
		//Below is text to display the state of the music.

		string s = AudioSource.clip.name + " is ";

		if (AudioSource.isPlaying)
			s += "PLAYING";
		else if (AudioSource.isPlaying == false && isPaused == false)
			s += "STOPPED";
		else if (isPaused)
			s += "PAUSED";

		s += " at " + Mathf.Round(AudioSource.time) + "/" + Mathf.Round(AudioSource.clip.length);

		MusicText.text = "P: Play\nS: Stop\nSpace: Pause\nN: Next\n\n" + s; // using '\n' in a string will move the text to the next line.
	}
}
