using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour 
{
	//Create a reference to the CoinPoofPrefab

	Quaternion y_rotation;
	public AudioClip clip_click					= null;
	private AudioSource _audio_source			= null;
	public GameObject effectSystem;
	public GameObject MazeController;

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

	public void OnCoinClicked() {
		// Instantiate the CoinPoof Prefab where this coin is located
		// Make sure the poof animates vertically
		// Destroy this coin. Check the Unity documentation on how to use Destroy
		_audio_source.Play();
		GetComponent<MeshRenderer>().enabled = false;
		// Even invisible, the coin still physical
		transform.Translate (0f,10f,0);
		//GetComponent<Rigidbody> ().gameObject.SetActive (false);
		effectSystem.gameObject.SetActive (false);
		MazeController.GetComponent<MazeController> ().update_score (5);
		//Debug.Log ("Coin clicked: " + y_rotation);
		Invoke( "onDestroy", 1f );
	}



	public void onDestroy()
	{
			//Debug.Log ("Destroyed");
			Destroy (gameObject);
	}

}
