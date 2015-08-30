using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	    if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            print("loading...");
            Application.LoadLevel("loading");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            print("Credits...");
            Application.LoadLevel("credits");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            print("instructions...");
            Application.LoadLevel("instructions");
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            print("Quit...");
            Application.Quit();
        }
	}
}
