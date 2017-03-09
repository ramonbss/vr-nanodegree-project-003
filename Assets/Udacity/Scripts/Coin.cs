using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour 
{
    //Create a reference to the CoinPoofPrefab

	Quaternion y_rotation;
	public AudioClip clip_click					= null;
	private AudioSource _audio_source			= null;
	public GameObject effectSystem;

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
		effectSystem.gameObject.SetActive (false);
		//Debug.Log ("Coin clicked: " + y_rotation);
		Invoke( "onDestroy", 1f );
    }

	public void onDestroy()
	{
		Debug.Log ("Destroyed");
		Destroy (gameObject);
		//gameObject.transform.d
	}

}
