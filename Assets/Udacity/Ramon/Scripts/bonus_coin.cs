using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bonus_coin : MonoBehaviour 
{
	//Create a reference to the CoinPoofPrefab

	Quaternion y_rotation;
	public AudioClip clip_click					= null;
	private AudioSource _audio_source			= null;
	public GameObject effectSystem;
	public GameObject MazeController;
	public GameObject Player;

	public GameObject[] wayPoints;

	private bool bl_jump = false;
	private bool bl_grounded = true;
	public float jumpPower = 1f;

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

		if( !bl_grounded && Player.GetComponent<Rigidbody>().velocity.y == 0 )
		{
			Player.GetComponent<Rigidbody> ().useGravity = false;
			bl_grounded = true;

			/*
			Vector2 pos = Player.transform.position;
			pos.y = 1.09f;
			Player.transform.position = pos;
			*/

			onDestroy ();
		}

		if( bl_jump && Player.transform.position.y < 4f )
		{
			Player.GetComponent<Rigidbody> ().useGravity = false	;
			Player.GetComponent<Rigidbody>().AddForce(Player.transform.up * jumpPower);
			Vector3 vel = Player.GetComponent<Rigidbody> ().velocity;
			vel.x = 0f;
			vel.z = 0f;
			Player.GetComponent<Rigidbody> ().velocity = vel;
			Invoke ("enable_gravity", 2f);
			bl_grounded = false;
		}

	}

	private void enable_gravity()
	{
		bl_jump = false;
		Debug.Log ("Inside enable gravity");
		//bl_jump = false;
		Player.GetComponent<Rigidbody> ().useGravity = true	;
	}

	public void OnCoinClicked() {
		// Instantiate the CoinPoof Prefab where this coin is located
		// Make sure the poof animates vertically
		// Destroy this coin. Check the Unity documentation on how to use Destroy
		_audio_source.Play();
		GetComponent<MeshRenderer>().enabled = false;
		effectSystem.gameObject.SetActive (false);
		generate_action ();
		//Debug.Log ("Coin clicked: " + y_rotation);
		Invoke( "onDestroy", 1f );
	}

	private void generate_action()
	{
		int func = Random.Range (0, 10);

		if( func <= 5 )
		{
			MazeController.GetComponent<MazeController>().update_score( Random.Range(0,51) );
		}
		else if( func >= 6)
		{
			teleport_player ();
		}
		else
		{
			//Player.GetComponent<Animation> ().Play("player_bounce");
			bl_jump = true;
		}

	}

	public void teleport_player()
	{
		int count = wayPoints.Length;
		Debug.Log ("Waypoints: " + count);
		int index = Random.Range (0, count);
		Debug.Log ("Index: " + index);

		wayPoints [index].GetComponent<Waypoint>().Click();

		/*
		Vector3 new_pos = wayPoints [index].transform.position;
		Vector3 curr_pos = Player.transform.position;

		curr_pos.x = new_pos.x;
		curr_pos.z = new_pos.z;

		Player.transform.position = curr_pos;
		*/
	}

	public void onDestroy()
	{
		if (bl_grounded == true) {
			//Debug.Log ("Destroyed");
			Destroy (gameObject);
		}
	}

}
