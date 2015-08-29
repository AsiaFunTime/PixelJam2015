using UnityEngine;
using System.Collections;

abstract public class UnitBehavior : MonoBehaviour {
    //base properties
    private float _initialMaxSpeed;
    private float _initialAcceleration;
	public float _rotateSpeed = 2f;
    public float _acceleration = 5f;
    public float _deceleration = 5f;
    public float _maxSpeed = 8f;
	public float _damage = 0f;
	public float _health;
	public int _ruler = 0;
	public GameObject _unitPrefab;
    public GameObject _king;

    public AudioManagerScript audio;
    // The player who killed this unit
    public int Killer = 0;
    private Animator _animator;

    public GameObject particleExplode;

    public bool enemyInfront = false;
    public bool enemyBehind = false;
    
    void Start(){
        audio = GameObject.FindGameObjectWithTag("GameManager").GetComponent<AudioManagerScript>();
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
        
        _animator = gameObject.GetComponentInChildren<Animator>();
        gameObject.AddComponent<Controls>();
        
        if (!(this is King))
        {
            gameObject.tag = "UnitNeutral";
        } else
        {
            
            _animator.SetBool("bobbing", true);
            
        }
        
        InitialMaxSpeed = MaxSpeed;
        InitialAcceleration = _acceleration;
        
    }

    public float Acceleration { 
        get {
            return _acceleration;
        }
        set{
            _acceleration = value;
        }
    }
    public float Deceleration { 
        get {
            return _deceleration;
        }
        set{
            _deceleration = value;
        }
    }
    public float MaxSpeed { 
        get {
            return _maxSpeed;
        }
        set{
            _maxSpeed = value;
        }
    }

	public float Damage {
		get {
			return _damage;
		}
		set {
			_damage = value;
		}
	}
	public float Health {
		get {
			return _health;
		}
		set {
			_health = value;
		}
	}

	public float RotateSpeed {
		get{
			return _rotateSpeed;
		}
		set{
			_rotateSpeed = value;
		}
	}

	
	public int Ruler {
		get {
			return _ruler;
		}
		set {
			_ruler = value;
		}
	}

	public GameObject Prefab{ 
		get {
			return _unitPrefab;
		}
	}

    public GameObject MyKing{
        get{
            return _king;
        }
        set{
            _king = value;
        }
    }
    
    public float InitialMaxSpeed
    {
        get
        {
            return _initialMaxSpeed;
        }
        set
        {
            _initialMaxSpeed = value;
        }
    }
    public float InitialAcceleration
    {
        get
        {
            return _initialAcceleration;
        }
        set
        {
            _initialAcceleration = value;
        }
    }
	public virtual void Die(){
        Vector3 spawnPos = transform.position;
        spawnPos.y = 2f;
        GameObject.Instantiate(particleExplode, spawnPos , Random.rotation);
        if (this is King)
        {            
            print(Ruler + " DIED");
            Destroy(GameObject.Find("P"+Ruler));
            audio.Play("cheer");
            // convert all controlled units to the killer
            GameObject[] myUnits = GameObject.FindGameObjectsWithTag("Unit"+Ruler);
            foreach(GameObject unit in myUnits){
                
                unit.GetComponent<UnitBehavior>().Recruit(Killer, true);
            }
        }
		Destroy (this.gameObject);
	}	
	
	public virtual void Spawn(float x, float z){
		GameObject.Instantiate (Prefab, new Vector3 (x, 0, z), new Quaternion ());
	}

    public void TakeDamage(float damage, int attacker){
        Health -= damage;
        if (Health <= 0)
        {            
            //dead
            audio.Play("die");
            Killer = attacker;
            Die();
        } else
        {            
            audio.Play("grunt");
        }
    }

	/// <summary>
	/// Player recruit this unit.
	/// </summary>
	public virtual bool Recruit(int playerNumber, bool kingKilled = false){
		if(Ruler == 0 && playerNumber != 0 || kingKilled){
			Ruler = playerNumber;
			gameObject.tag = "Unit"+playerNumber;
            _king = GameObject.Find("King"+playerNumber);
            _animator.SetBool("bobbing", true);

            gameObject.layer =GetLayer();

            Renderer rend = GetComponentInChildren<Renderer>();
            if(rend != null){
                print("changing color...");
                if(playerNumber == 1)
                    rend.material.SetColor("_OutlineColor", KingColors.ColorKingBlue);
                else if(playerNumber ==2)
                    rend.material.SetColor("_OutlineColor", KingColors.ColorKingPurple);
                else if(playerNumber ==3)
                    rend.material.SetColor("_OutlineColor", KingColors.ColorKingOrange);
                else if(playerNumber ==4)
                    rend.material.SetColor("_OutlineColor", KingColors.ColorKingCyan);
            }

            if(!kingKilled){
                // play rcruit sound
                if(this is Knight){
                    audio.Play("recruitKnight");
                }
                else if(this is Footman){                    
                    audio.Play("recruitFootman");
                }
                else if(this is Archer){                    
                    audio.Play("recruitArcher");
                }
                else if(this is Peasant){                    
                    audio.Play("recruitPeasant");
                }
            }

			return true;
		}
		return false;
	}
    public void OnTriggerEnter(Collider other) {
        if (other.tag == "UnitNeutral")
        {
            //print(other.name + " " + gameObject.name);
            other.GetComponent<UnitBehavior>().Recruit(Ruler);
        } else if (isEnemy(other) && Damage > 0 && Ruler > 0)
        {
            //print(gameObject.name + Ruler +" hits " + other.name + " for " + Damage + " damage");
            // damage
            audio.Play("attack");
            UnitBehavior ub = other.GetComponent<UnitBehavior>();
            ub.TakeDamage(Damage, Ruler);
        }
    }

    public bool enemiesBehind(){
        return enemyBehind;
    }

    public bool enemiesInfront(){
        return enemyInfront;
    }
    public bool isEnemy(Collider other){
        UnitBehavior ub = other.GetComponent<UnitBehavior>();
        if (ub != null)
        {
            return ub.Ruler != 0 && ub.Ruler != Ruler;
        }
        return false;
    }

    public int GetLayer(){
        if (Ruler == 0)
        {
            return 12;
        }
        else if (Ruler == 1)
        {
            return 8;
        }
        else if (Ruler == 2)
        {
            return 9;
        }
        else if (Ruler == 3)
        {
            return 10;
        }
        else if (Ruler == 4)
        {
            return 11;
        }
        return 12;
    }
}
