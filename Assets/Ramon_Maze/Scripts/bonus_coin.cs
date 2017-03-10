using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bonus_coin : MonoBehaviour 
{
	//Create a reference to the CoinPoofPrefab

	Quaternion y_rotation;					// Original coin rotation
	public AudioClip clip_click;			// Sound to be played
	private AudioSource _audio_source;		// Audio Source to play the audio clip
	public GameObject effectSystem;			// Reference to Particle System
	public GameObject MazeController;		// Reference to MazeController
	public GameObject Player;				// Reference to MainCamera

	// This array must be previously populated in the editor
	public GameObject[] wayPoints;			// Some waypoints used in the maze

	void Awake()
	{
		y_rotation = transform.rotation;

		_audio_source				= gameObject.GetComponent<AudioSource>();	
		if( clip_click != null )
		{
			_audio_source.clip		 	= clip_click;
		}

		_audio_source.playOnAwake 	= false;

	}

	void Update()
	{
		y_rotation.y =  Mathf.Sin (Time.time)*2;
		//Debug.Log ("Rotation: " + y_rotation);
		transform.rotation = y_rotation;
	}

	// Method called when a coin is clicked
	public void OnCoinClicked() {

		// Play the coin's picked sound
		_audio_source.Play();
		// Make coin "disapear"
		GetComponent<MeshRenderer>().enabled = false;
		// Disable Particle effects
		effectSystem.gameObject.SetActive (false);
		// Run the random coin effect
		generate_action ();
		// Destroy coin after 1 second or it will stop the sound being played
		Invoke( "onDestroy", 1f );
	}

	// Get the random coin action
	private void generate_action()
	{
		// Generate a number
		int func = Random.Range (0, 10);

		// The user will get 60% chances of get more coins
		if( func <= 5 )
		{
			MazeController.GetComponent<MazeController>().update_score( Random.Range(0,51) );
		}
		// The user have 40% chances of be teleported anywhere in the maze
		else if( func >= 6)
		{
			teleport_player ();
		}

	}

	// Teleport player to an random waypoint in the maze
	public void teleport_player()
	{
		int count = wayPoints.Length;
		//Debug.Log ("Waypoints: " + count);
		int index = Random.Range (0, count);
		//Debug.Log ("Index: " + index);

		wayPoints [index].GetComponent<Waypoint>().Click();

		/*// Another way of doing the same
		Vector3 new_pos = wayPoints [index].transform.position;
		Vector3 curr_pos = Player.transform.position;

		curr_pos.x = new_pos.x;
		curr_pos.z = new_pos.z;

		Player.transform.position = curr_pos;
		*/
	}

	public void onDestroy()
	{
		//Debug.Log ("Destroyed");
		Destroy (gameObject);
		
	}

}
