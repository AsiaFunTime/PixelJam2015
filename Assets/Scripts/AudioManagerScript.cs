using UnityEngine;
using System.Collections;

public class AudioManagerScript : MonoBehaviour {


	// Generic
	AudioClip[] grunts = new AudioClip[6];
	AudioClip[] attacks = new AudioClip[6];
	AudioClip[] dies = new AudioClip[6];
	AudioClip[] cheers = new AudioClip[3];


	// Arrow
	AudioClip[] arrowShoot = new AudioClip[6];
	AudioClip[] arrowCollide = new AudioClip[6];

	AudioClip horseGallop = new AudioClip();

	public GameObject gameManager;

	// Use this for initialization
	void Start () { 

		// Attack - Grunt - Die - cheer
		grunts = new AudioClip[6];
		attacks = new AudioClip[6];
		dies = new AudioClip[6];
		cheers = new AudioClip[3];

		arrowShoot = new AudioClip[6];
		arrowCollide = new AudioClip[6];

		gameManager = GameObject.FindGameObjectWithTag("GameManager");

		grunts[0] = Resources.Load ("Audio/SoundEffects/Metal/man_grunt_pain_01") as AudioClip;
		grunts[1] = Resources.Load ("Audio/SoundEffects/Metal/man_grunt_pain_01") as AudioClip;
		grunts[2] = Resources.Load ("Audio/SoundEffects/Metal/man_grunt_pain_01") as AudioClip;
		grunts[3] = Resources.Load ("Audio/SoundEffects/Metal/man_grunt_pain_01") as AudioClip;
		grunts[4] = Resources.Load ("Audio/SoundEffects/Metal/man_grunt_pain_01") as AudioClip;
		grunts[5] = Resources.Load ("Audio/SoundEffects/Metal/man_grunt_pain_01") as AudioClip;

		attacks[0] = Resources.Load ("Audio/SoundEffects/Metal/blunt_high_high_03") as AudioClip;
		attacks[1] = Resources.Load ("Audio/SoundEffects/Metal/Sword_clash_01") as AudioClip;
		attacks[2] = Resources.Load ("Audio/SoundEffects/Metal/Sword_clash_02") as AudioClip;
		attacks[3] = Resources.Load ("Audio/SoundEffects/Metal/Sword_clash_03") as AudioClip;
		attacks[4] = Resources.Load ("Audio/SoundEffects/Metal/Sword_clash_04") as AudioClip;
		attacks[5] = Resources.Load ("Audio/SoundEffects/Metal/Sword_clash_05") as AudioClip;

		dies[0] = Resources.Load ("Audio/SoundEffects/Metal/man_die_01") as AudioClip;
		dies[1] = Resources.Load ("Audio/SoundEffects/Metal/man_die_02") as AudioClip;
		dies[2] = Resources.Load ("Audio/SoundEffects/Metal/man_die_03") as AudioClip;
		dies[3] = Resources.Load ("Audio/SoundEffects/Metal/man_die_04") as AudioClip;
		dies[4] = Resources.Load ("Audio/SoundEffects/Metal/man_die_05") as AudioClip;
		dies[5] = Resources.Load ("Audio/SoundEffects/Metal/man_die_06") as AudioClip;

		cheers[0] = Resources.Load ("Audio/SoundEffects/Metal/man_victory_01") as AudioClip;
		cheers[1] = Resources.Load ("Audio/SoundEffects/Metal/man_victory_02") as AudioClip;
		cheers[2] = Resources.Load ("Audio/SoundEffects/Metal/man_victory_03") as AudioClip;

		// Arrow
		arrowShoot[0] = Resources.Load ("Audio/SoundEffects/Metal/bow_shoot_01") as AudioClip;
		arrowShoot[1] = Resources.Load ("Audio/SoundEffects/Metal/bow_shoot_02") as AudioClip;
		arrowShoot[2] = Resources.Load ("Audio/SoundEffects/Metal/bow_shoot_03") as AudioClip;
		arrowShoot[3] = Resources.Load ("Audio/SoundEffects/Metal/bow_shoot_04") as AudioClip;
		arrowShoot[4] = Resources.Load ("Audio/SoundEffects/Metal/bow_shoot_05") as AudioClip;
		arrowShoot[5] = Resources.Load ("Audio/SoundEffects/Metal/bow_shoot_06") as AudioClip;

		arrowCollide[0] = Resources.Load ("Audio/SoundEffects/Metal/arrow_ground_01") as AudioClip;
		arrowCollide[1] = Resources.Load ("Audio/SoundEffects/Metal/arrow_ground_02") as AudioClip;
		arrowCollide[2] = Resources.Load ("Audio/SoundEffects/Metal/arrow_ground_03") as AudioClip;
		arrowCollide[3] = Resources.Load ("Audio/SoundEffects/Metal/arrow_ground_04") as AudioClip;
		arrowCollide[4] = Resources.Load ("Audio/SoundEffects/Metal/arrow_ground_05") as AudioClip;
		arrowCollide[5] = Resources.Load ("Audio/SoundEffects/Metal/arrow_ground_06") as AudioClip;

		// Horse
		horseGallop = Resources.Load ("Audio/SoundEffects/Horse/cavalry_charge") as AudioClip;


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Play ( string clipName )
	{
		// Types of audio
		// Attack - Grunt - Die
		AudioSource audioSource = gameManager.AddComponent<AudioSource>();

		if ( clipName == "attack" )
		{
			int i = Random.Range( 0, 5 );
			audioSource.clip = attacks[i] ;
		}
		else if ( clipName == "die" )
		{
			int i = Random.Range( 0, 5 );
			audioSource.clip = dies[i] ;
		}
		else if ( clipName == "grunt" )
		{
			int i = Random.Range( 0, 5 );
			audioSource.clip = grunts[i] ;
		} else if ( clipName == "cheer" )
		{
			int i = Random.Range( 0, 2 );
			audioSource.clip = cheers[i] ;
		}
		else if ( clipName == "arrowShoot" )
		{
			int i = Random.Range( 0, 5 );
			audioSource.clip = arrowShoot[i] ;
		}
		else if ( clipName == "arrowCollide" )
		{
			int i = Random.Range( 0, 5 );
			audioSource.clip = arrowCollide[i] ;
		}

		else if ( clipName == "horseGallop" )
		{
			audioSource.volume = 0.5f;
			audioSource.clip = horseGallop ;
		}
		audioSource.Play();
		StartCoroutine(WaitThenDestroy(audioSource.clip.length, audioSource));
	
	}

	public void StopAllAudio ()
	{
		AudioSource[] audioSources = GetComponents<AudioSource>();
		foreach(AudioSource audio in audioSources){
			audio.Stop();
		}
	}

	public IEnumerator WaitThenDestroy(float waitTime, AudioSource audioSource){
		yield return new WaitForSeconds(waitTime);
		GameObject.Destroy(audioSource);
	}
}
