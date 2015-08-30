using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour {
    private float xMax = 120f;
    private float zMax = 120f;
    private int maxUnits = 800;
	
    private int maxTrees = 80;
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

    public GameObject hills;

    // Use this for initialization
	void Start () {
        // spawn units
        SpawnUnits(knight, (int)(knightSpawnChance * maxUnits));
        SpawnUnits(footman, (int)(footmanSpawnChance * maxUnits));
        SpawnUnits(archer, (int)(archerSpawnChance * maxUnits));
        SpawnUnits(peasant,(int) (peasantSpawnChance * maxUnits));

        SpawnUnits(treesSingle, maxTrees);
	}
    
    void SpawnNoRandomRotation(GameObject unit, int count)
    {        
        for (int i = 0; i < count; i++)
        {
            GameObject.Instantiate(unit, GetRandomPoint(), hills.transform.rotation);
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
