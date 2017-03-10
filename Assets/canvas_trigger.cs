using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class canvas_trigger : MonoBehaviour {

	public void onClick()
	{
		SceneManager.LoadScene ("Ramon_Maze");
	}

}
