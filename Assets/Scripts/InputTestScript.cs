using UnityEngine;
using System.Collections;

public class InputTestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if ( Input.GetKeyDown( KeyCode.Q ) )
		{
			SendMessage("Play", "grunt" );
		}
		if ( Input.GetKeyDown( KeyCode.W ) )
		{
			SendMessage("Play", "attack" );
		}
		if ( Input.GetKeyDown( KeyCode.E ) )
		{
			SendMessage("Play", "cheer" );
		}
		if ( Input.GetKeyDown ( KeyCode.R ))
		{
			SendMessage("Play", "die" );
		}
		if ( Input.GetKeyDown( KeyCode.A ) )
		{
			SendMessage("Play", "arrowShoot" );
		}
		if ( Input.GetKeyDown ( KeyCode.S ) )
		{
			SendMessage("Play", "arrowCollide" );
		}
		if ( Input.GetKeyDown ( KeyCode.D ) )
		{
			SendMessage("Play", "horseGallop" );
		}
		if ( Input.GetKeyDown ( KeyCode.F ) )
		{
			SendMessage("Play", "cheer" );
		}
		if ( Input.GetKeyDown( KeyCode.Z ) )
		{
			SendMessage("StopAllAudio");
		}
	
	}
}
