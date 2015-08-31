using UnityEngine;
using System.Collections;

public class AudioManagerScript : MonoBehaviour {


	// Generic
	AudioClip[] grunts = new AudioClip[6];
	AudioClip[] attacks = new AudioClip[6];
	AudioClip[] dies = new AudioClip[6];
	AudioClip[] cheers = new AudioClip[3];

	AudioClip[] charges = new AudioClip[6];
	AudioClip[] recruitKnights = new AudioClip[6];
	AudioClip[] recruitFootmans = new AudioClip[6];
	AudioClip[] recruitArchers = new AudioClip[6];
	AudioClip[] recruitPeasants = new AudioClip[6];


	// Arrow
	AudioClip[] arrowShoot = new AudioClip[6];
	AudioClip[] arrowCollide = new AudioClip[6];
    
    AudioClip horseGallop = new AudioClip();
    AudioSource horseGallopSource =new  AudioSource();
    AudioClip bugleClip = new AudioClip();
    AudioSource bugleSource =new  AudioSource();

	public GameObject gameManager;


    AudioSource[] sources = new AudioSource[32];
	// Use this for initialization
	void Start () { 
        // Initialize audio sources
        for (int i = 0; i < 32; i++)
        {
            sources[i] = gameObject.AddComponent<AudioSource>();
        }

		// Attack - Grunt - Die - cheer
		grunts = new AudioClip[6];
		attacks = new AudioClip[6];
		dies = new AudioClip[12];
		cheers = new AudioClip[3];

		arrowShoot = new AudioClip[6];
		arrowCollide = new AudioClip[6];

		charges = new AudioClip[7];

		recruitKnights = new AudioClip[6];
		recruitFootmans = new AudioClip[6];
		recruitArchers = new AudioClip[6];
		recruitPeasants = new AudioClip[3];

		gameManager = GameObject.FindGameObjectWithTag("GameManager");

		// Horse
		horseGallop = Resources.Load ("Audio/SoundEffects/Horse/cavalry_charge") as AudioClip;
		horseGallopSource = gameObject.AddComponent<AudioSource>();
		horseGallopSource.clip = horseGallop;
		horseGallopSource.volume = 0.1f;
        horseGallopSource.loop = true;
		horseGallopSource.Play ();

		grunts[0] = Resources.Load ("Audio/SoundEffects/Metal/man_grunt_pain_01") as AudioClip;
		grunts[1] = Resources.Load ("Audio/SoundEffects/Metal/man_grunt_pain_02") as AudioClip;
		grunts[2] = Resources.Load ("Audio/SoundEffects/Metal/man_grunt_pain_03") as AudioClip;
		grunts[3] = Resources.Load ("Audio/SoundEffects/Metal/man_grunt_pain_04") as AudioClip;
		grunts[4] = Resources.Load ("Audio/SoundEffects/Metal/man_grunt_pain_05") as AudioClip;
		grunts[5] = Resources.Load ("Audio/SoundEffects/Metal/man_grunt_pain_06") as AudioClip;

		attacks[0] = Resources.Load ("Audio/SoundEffects/Metal/metal_on_wood_01") as AudioClip;
		attacks[1] = Resources.Load ("Audio/SoundEffects/Metal/metal_on_wood_02") as AudioClip;
		attacks[2] = Resources.Load ("Audio/SoundEffects/Metal/metal_on_wood_03") as AudioClip;
		attacks[3] = Resources.Load ("Audio/SoundEffects/Metal/metal_on_wood_04") as AudioClip;
		attacks[4] = Resources.Load ("Audio/SoundEffects/Metal/metal_on_wood_05") as AudioClip;
		attacks[5] = Resources.Load ("Audio/SoundEffects/Metal/metal_on_wood_06") as AudioClip;

		dies[0] = Resources.Load ("Audio/SoundEffects/Metal/man_die_01") as AudioClip;
		dies[1] = Resources.Load ("Audio/SoundEffects/Metal/man_die_02") as AudioClip;
		dies[2] = Resources.Load ("Audio/SoundEffects/Metal/man_die_03") as AudioClip;
		dies[3] = Resources.Load ("Audio/SoundEffects/Metal/man_die_04") as AudioClip;
		dies[4] = Resources.Load ("Audio/SoundEffects/Metal/man_die_05") as AudioClip;
		dies[5] = Resources.Load ("Audio/SoundEffects/Metal/man_die_06") as AudioClip;
		dies[6] = Resources.Load ("Audio/SoundEffects/Metal/metal_low_high_01") as AudioClip;
		dies[7] = Resources.Load ("Audio/SoundEffects/Metal/metal_low_high_02") as AudioClip;
		dies[8] = Resources.Load ("Audio/SoundEffects/Metal/metal_low_high_03") as AudioClip;
		dies[9] = Resources.Load ("Audio/SoundEffects/Metal/metal_low_high_04") as AudioClip;
		dies[10] = Resources.Load ("Audio/SoundEffects/Metal/metal_low_high_05") as AudioClip;
		dies[11] = Resources.Load ("Audio/SoundEffects/Metal/metal_low_high_06") as AudioClip;

		cheers[0] = Resources.Load ("Audio/SoundEffects/Metal/man_victory_01") as AudioClip;
		cheers[1] = Resources.Load ("Audio/SoundEffects/Metal/man_victory_02") as AudioClip;
		cheers[2] = Resources.Load ("Audio/SoundEffects/Metal/man_victory_03") as AudioClip;

		// Arrow
		arrowShoot[0] = Resources.Load ("Audio/SoundEffects/Metal/bow_shoot_01") as AudioClip;
		arrowShoot[1] = Resources.Load ("Audio/SoundEffects/Metal/bow_shoot_09") as AudioClip;
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



		//charge 
		charges[0] = Resources.Load ("Audio/SoundEffects/WC2/Knight/Pkatak1") as AudioClip;
		charges[1] = Resources.Load ("Audio/SoundEffects/Metal/man_yell_01") as AudioClip;
		charges[2] = Resources.Load ("Audio/SoundEffects/Metal/man_yell_02") as AudioClip;
		charges[3] = Resources.Load ("Audio/SoundEffects/Metal/man_yell_03") as AudioClip;
		charges[4] = Resources.Load ("Audio/SoundEffects/Metal/man_yell_04") as AudioClip;
		charges[5] = Resources.Load ("Audio/SoundEffects/Metal/man_yell_05") as AudioClip;
		charges[6] = Resources.Load ("Audio/SoundEffects/Metal/man_yell_06") as AudioClip;

		//Recruit
		// Peasant

		recruitPeasants[0] = Resources.Load ("Audio/SoundEffects/WC2/Peasant/Pspissd6") as AudioClip;
		recruitPeasants[1] = Resources.Load ("Audio/SoundEffects/WC2/Peasant/Psready") as AudioClip;
		recruitPeasants[2] = Resources.Load ("Audio/SoundEffects/WC2/Peasant/Psyessr4") as AudioClip;

        //Archer
        recruitArchers[0] = Resources.Load ("Audio/SoundEffects/WC2/archer/Dnpisd1") as AudioClip;
        recruitArchers[1] = Resources.Load ("Audio/SoundEffects/WC2/archer/Dnpisd3") as AudioClip;
        recruitArchers[2] = Resources.Load ("Audio/SoundEffects/WC2/archer/Dnwhat1") as AudioClip;
        recruitArchers[3] = Resources.Load ("Audio/SoundEffects/WC2/archer/Dnwhat2") as AudioClip;
        recruitArchers[4] = Resources.Load ("Audio/SoundEffects/WC2/archer/Dnwhat3") as AudioClip;
        recruitArchers[5] = Resources.Load ("Audio/SoundEffects/WC2/archer/Dnyessr1") as AudioClip;

		//Footman
		recruitFootmans[0] = Resources.Load ("Audio/SoundEffects/WC2/footman/Hready") as AudioClip;
		recruitFootmans[1] = Resources.Load ("Audio/SoundEffects/WC2/footman/Hwhat1") as AudioClip;
		recruitFootmans[2] = Resources.Load ("Audio/SoundEffects/WC2/footman/Hwhat3") as AudioClip;
		recruitFootmans[3] = Resources.Load ("Audio/SoundEffects/WC2/footman/Hwhat5") as AudioClip;
		recruitFootmans[4] = Resources.Load ("Audio/SoundEffects/WC2/footman/Hwhat6") as AudioClip;
		recruitFootmans[5] = Resources.Load ("Audio/SoundEffects/WC2/footman/Hyessir2") as AudioClip;

		//Knight
		recruitKnights[0] = Resources.Load ("Audio/SoundEffects/WC2/Knight/Pkready") as AudioClip;
		recruitKnights[1] = Resources.Load ("Audio/SoundEffects/WC2/Knight/Pkyessr3") as AudioClip;
		recruitKnights[2] = Resources.Load ("Audio/SoundEffects/WC2/Knight/Tuwhat1") as AudioClip;
		recruitKnights[3] = Resources.Load ("Audio/SoundEffects/WC2/Knight/Tuwhat2") as AudioClip;
		recruitKnights[4] = Resources.Load ("Audio/SoundEffects/WC2/Knight/Tuwhat3") as AudioClip;
		recruitKnights[5] = Resources.Load ("Audio/SoundEffects/WC2/Knight/Tuyessr1") as AudioClip;
        
        bugleClip = Resources.Load ("Audio/SoundEffects/Menu/bugle") as AudioClip;
        bugleSource = gameObject.AddComponent<AudioSource>();
        bugleSource.clip = bugleClip;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Play ( string clipName )
	{
		// Types of audio
		// Attack - Grunt - Die
        AudioSource audioSource = null;
        foreach (AudioSource source in sources)
        {
            if(!source.isPlaying){
                audioSource = source;
                audioSource.clip = null;
                break;
            }
        }
        if (audioSource == null)
        {
            print("Exceeded audio limit!");
            return;
        }
        audioSource.volume=1f;
        if (clipName == "attack")
        {
            int i = Random.Range(0, 5);
            audioSource.clip = attacks [i];
        } else if (clipName == "die")
        {
            int i = Random.Range(0, 5);
            audioSource.clip = dies [i];
        } else if (clipName == "grunt")
        {
            int i = Random.Range(0, 5);
            audioSource.clip = grunts [i];
        } else if (clipName == "cheer")
        {
            int i = Random.Range(0, 2);
            audioSource.clip = cheers [i];
        } else if (clipName == "arrowShoot")
        {
            int i = Random.Range(0, 5);
            audioSource.clip = arrowShoot [i];
        } else if (clipName == "arrowCollide")
        {
            int i = Random.Range(0, 5);
            audioSource.clip = arrowCollide [i];
        } else if (clipName == "horseGallop")
        {
            audioSource.volume = 0.2f;
            audioSource.clip = horseGallop;
        } else if (clipName == "charge")
        {
            int i = Random.Range(0, 5);
            audioSource.clip = charges [i];
        } else if (clipName == "recruitKnight")
        {
            int i = Random.Range(0, 5);
            audioSource.clip = recruitKnights [i];
            audioSource.volume = 0.5f;
        } else if (clipName == "recruitFootman")
        {
            int i = Random.Range(0, 5);
            audioSource.clip = recruitFootmans [i];
            audioSource.volume = 0.5f;
        } else if (clipName == "recruitArcher")
        {
            int i = Random.Range(0, 5);
            audioSource.clip = recruitArchers [i];
            audioSource.volume = 0.5f;
        } else if (clipName == "recruitPeasant")
        {
            int i = Random.Range(0, 2);
            audioSource.clip = recruitPeasants [i];
            audioSource.volume = 0.5f;
        } else if (clipName == "bugle")
        {
            bugleSource.volume = 0.1f;
            bugleSource.PlayOneShot(bugleClip);
        }
        if (audioSource.clip != null)
        {
            audioSource.Play();
        }
		//StartCoroutine(WaitThenDestroy(audioSource.clip.length, audioSource));
	
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
