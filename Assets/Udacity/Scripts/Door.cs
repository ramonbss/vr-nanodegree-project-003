using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
    // Create a boolean value called "locked" that can be checked in OnDoorClicked() 
    // Create a boolean value called "opening" that can be checked in Update() 

	public GameObject MazeController;
	public GameObject doorLeft;
	public GameObject doorRight;
	public AudioClip doorLocked;
	public AudioClip doorOpenned;
	private bool bl_doorLocked = true;
	private AudioSource _audio_source			= null;

	private Quaternion doorLeft_start;
	private Quaternion doorRight_start;

	void Awake()
	{
		// Load audio source
		_audio_source				= gameObject.GetComponent<AudioSource>();

		// Get door's initial position
		doorLeft_start = doorLeft.transform.rotation;
		doorRight_start = doorRight.transform.rotation;

		Debug.Log("DoorR quaternion: " + doorRight_start);
		Debug.Log("DoorR Euler: " + doorRight_start.eulerAngles);

		Debug.Log("DoorL quaternion: " + doorLeft_start);
		Debug.Log("DoorL Euler: " + doorLeft_start.eulerAngles);
	}

    void Update() {
        // If the door is opening and it is not fully raised
            // Animate the door raising up
		if( bl_doorLocked == false )
		{

			// Animate left door
			Quaternion l_end = new Quaternion( 0.7f, 0f, 0f, 0.7f);
			doorLeft.transform.rotation = Quaternion.Slerp ( doorLeft_start, l_end, Time.time );

			// Animate left door
			Quaternion r_end = new Quaternion( -0.7f, 0f, 0f, 0.7f);
			doorRight.transform.rotation = Quaternion.Slerp ( doorRight_start, r_end, Time.time );

			//Debug.Log("Door Euler: " + doorRight.transform.rotation.eulerAngles);

		}
		/*
		Debug.Log("Door quaternion: " + doorRight.transform.rotation);
		Debug.Log("Door Euler: " + doorRight.transform.rotation.eulerAngles);
		*/
    }

    public void OnDoorClicked() {

		bool has_key = MazeController.GetComponent<MazeController>().has_key;

		if( bl_doorLocked == true )
		{
			if (has_key) {
				Unlock ();
			} else {
				_audio_source.clip = doorLocked;
				_audio_source.Play ();
			}
		}
        // If the door is clicked and unlocked
            // Set the "opening" boolean to true
        // (optionally) Else
            // Play a sound to indicate the door is locked
    }

    public void Unlock()
    {
		_audio_source.clip = doorOpenned;
		_audio_source.Play ();
        // You'll need to set "locked" to false here
		bl_doorLocked = false;
    }
}
