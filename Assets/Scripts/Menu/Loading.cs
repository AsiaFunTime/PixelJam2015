using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour {
    UnityEngine.UI.Text text;
	// Use this for initialization
	void Start () {
        Application.LoadLevel("scene1");
        text = GameObject.Find("Text").GetComponent<UnityEngine.UI.Text>(); 

	}
	
	// Update is called once per frame
	void Update () {
        int progress = Application.loadedLevel;
        text.text = "Loading";
        for(int i = 0; i < + ((progress/100) * 40); i++){
            text.text += ".";
        }
        text.text += ")";
	}
}
