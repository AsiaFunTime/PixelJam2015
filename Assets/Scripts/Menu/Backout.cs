using UnityEngine;
using System.Collections;

public class Backout : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.JoystickButton1)){
            Application.LoadLevel("mainMenu");
        }
	}
}
