using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour {
    private float xMax = 100f;
    private float zMax = 100f;
    private int maxUnits = 600;
	
    private int maxTrees = 60;
    private int maxTreesClumped = 20;
    private int maxHills = 20;

    private float knightSpawnChance = 0.15f;
    private float footmanSpawnChance = 0.35f;
    private float archerSpawnChance = 0.25f;
    private float peasantSpawnChance = 0.25f;

    public GameObject knight;
    public GameObject footman;
    public GameObject archer;
    public GameObject peasant;
    
    public GameObject treesSingle;
    public GameObject treesClumped;

    public GameObject[] hills = new GameObject[3];


    private bool kingDead1 = false;
    private bool kingDead2 = false;
    private bool kingDead3 = false;
    private bool kingDead4 = false;
    private bool gameOver = false;
    // Use this for initialization
	void Start () {
        // spawn units
        SpawnUnits(knight, (int)(knightSpawnChance * maxUnits));
        SpawnUnits(footman, (int)(footmanSpawnChance * maxUnits));
        SpawnUnits(archer, (int)(archerSpawnChance * maxUnits));
        SpawnUnits(peasant,(int) (peasantSpawnChance * maxUnits));
        
        SpawnUnits(treesSingle, maxTrees);
        SpawnUnits(treesClumped, maxTreesClumped);
        SpawnHills();
	}

    void SpawnHills()
    {
        for (int i = 0; i < maxHills; i++)
        {
            int hill = Random.Range(0,2);
            GameObject.Instantiate(hills[hill], GetRandomPoint(), hills[hill].transform.rotation);
        }
    }
           
    void SpawnUnits(GameObject unit, int count)
    {        
        for (int i = 0; i < count; i++)
        {
            GameObject.Instantiate(unit, GetRandomPoint(), GetRandomRotation());
        }
    }
	
	// Update is called once per frame
	void Update () {
	 if (gameOver)
        {   
            if(Input.GetKeyDown(KeyCode.JoystickButton2)){
                Application.LoadLevel("loading");
            }
            else if(Input.GetKeyDown(KeyCode.JoystickButton1)){
                Application.LoadLevel("mainMenu");
            }
        }
	}

    public void KillKing(int playerNumber){
        print("A KING HAS DIED!!");
        if (playerNumber == 1)
        {
            kingDead1 = true;
        } else if (playerNumber == 2)
        {
            kingDead2 = true;
            
        }else if (playerNumber == 3)
        {
            
            kingDead3 = true;
        }else if (playerNumber == 4)
        {
            kingDead4 = true;            
        }
        if ((kingDead1 ? 0 : 1) + (kingDead2 ? 0 : 1) + (kingDead3 ? 0 : 1) + (kingDead4 ? 0 : 1) == 1)
        {
            print("A KING HAS WON!");
            Canvas winUI = GameObject.Find("GameOver").GetComponent<Canvas>();
            winUI.planeDistance = 1f;
            if(!kingDead1){
                winUI.worldCamera = GameObject.FindGameObjectWithTag("Camera1").GetComponent<Camera>();
            }
            if(!kingDead2){
                winUI.worldCamera = GameObject.FindGameObjectWithTag("Camera2").GetComponent<Camera>();
            }
            if(!kingDead3){
                winUI.worldCamera = GameObject.FindGameObjectWithTag("Camera3").GetComponent<Camera>();
            }
            if(!kingDead4){
                winUI.worldCamera = GameObject.FindGameObjectWithTag("Camera4").GetComponent<Camera>();
            }
            gameOver = true;
        }
    }

    public Quaternion GetRandomRotation(){
        Quaternion random = Random.rotation;
        random.z = 0f;
        random.x = 0f;
        return random;
    }

    public Vector3 GetRandomPoint(){
        return new Vector3(Random.Range(-xMax, xMax), 0, Random.Range(-zMax, zMax));
    }
}
