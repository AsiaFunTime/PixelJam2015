using UnityEngine;
using System.Collections;

public class StartMusic : MonoBehaviour {
    AudioClip musicBackground = new AudioClip();
    AudioSource musicBackgroundSource = new AudioSource();

    
    AudioClip buttonSound = new AudioClip();
    AudioSource buttonSoundSource = new AudioSource();
	// Use this for initialization
    void Start () {
        //Music
        musicBackground = Resources.Load ("Audio/SoundEffects/Music/wc2_human_01") as AudioClip;
        musicBackgroundSource = gameObject.AddComponent<AudioSource>();
        musicBackgroundSource.clip = musicBackground;
        musicBackgroundSource.volume = 0.5f;
        musicBackgroundSource.Play ();
        musicBackgroundSource.loop = true;
        DontDestroyOnLoad(gameObject);

        
        buttonSound = Resources.Load ("Audio/SoundEffects/Metal/sword_clash_03") as AudioClip;
        buttonSoundSource = gameObject.AddComponent<AudioSource>();
        buttonSoundSource.clip = buttonSound;
        buttonSoundSource.loop = false;

        Application.LoadLevel("mainMenu");
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.JoystickButton3)){
            buttonSoundSource.Play ();
        }
	}
}
