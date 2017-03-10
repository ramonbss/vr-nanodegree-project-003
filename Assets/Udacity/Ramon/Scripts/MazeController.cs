using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeController : MonoBehaviour {

	public bool has_key = false;

	private int score = 0;
	public Text txt_ui;
	public Text txt_score;
	public float msg_seconds = 3f;

	void start()
	{
		txt_ui.text = "";
	}

	public void show_msg( string msg )
	{
		txt_ui.text = msg;
		Invoke ( "dismiss_msg", msg_seconds );
	}

	public void dismiss_msg()
	{
		txt_ui.text = "";
	}

	public void update_score( int ammount )
	{
		score+= ammount;
		txt_score.text = "Score: " + score;

	}

}