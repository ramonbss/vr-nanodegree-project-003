using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeController : MonoBehaviour {

	public bool has_key = false;			// Keep key status
	private int score = 0;					// The score is increased as player catch coins
	public Text txt_ui;						// Reference to Text element from the canvas responsable to show the msgs in game
	public Text txt_score;					// Same as above but to show score counter
	public float msg_seconds = 3f;			// How many seconds the msgs will show up to user

	void start()
	{
		txt_ui.text = "";					// Be sure no msg will show up
	}

	// Method to show msgs in screen
	public void show_msg( string msg )
	{
		txt_ui.text = msg;						// Show msg
		Invoke ( "dismiss_msg", msg_seconds );	// Dismiss msg after n seconds
	}

	// Clear msg in screen
	public void dismiss_msg()
	{
		txt_ui.text = "";
	}

	// Update score Text in screen ( Called by coins )
	public void update_score( int ammount )
	{
		score+= ammount;
		txt_score.text = "Score: " + score;

	}

}