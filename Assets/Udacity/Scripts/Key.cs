using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour 
{
    //Create a reference to the KeyPoofPrefab and Door

	Vector3 y_position;
	public GameObject MazeController;
	private bool clicked = false;
	private AudioSource _audio_source			= null;


	void Awake()
	{
		y_position = transform.position;
		_audio_source				= gameObject.GetComponent<AudioSource>();
	}

	void Update()
	{
		//Not required, but for fun why not try adding a Key Floating Animation here :)
		y_position.y = Mathf.Sin( Time.time )/4 +1;
		//Debug.Log ("Position: " + y_position);
		transform.position = y_position;
	}

	public void OnKeyClicked()
	{
        // Instatiate the KeyPoof Prefab where this key is located
        // Make sure the poof animates vertically
        // Call the Unlock() method on the Door
        // Set the Key Collected Variable to true
        // Destroy the key. Check the Unity documentation on how to use Destroy
		if (clicked == false) {
			MazeController.GetComponent<MazeController> ().has_key = true;

			_audio_source.Play();
			GetComponent<MeshRenderer>().enabled = false;
			Invoke( "onDestroy", 1f );

		}
    }

	public void onDestroy()
	{
		//Debug.Log ("Destroyed");
		Destroy (gameObject);
	}

}
