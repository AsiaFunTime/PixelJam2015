﻿using UnityEngine;
using System.Collections;

abstract public class UnitBehavior : MonoBehaviour {
    //base properties
    private float _initialMaxSpeed;
	public float _rotateSpeed = 2f;
    public float _acceleration = 5f;
    public float _deceleration = 5f;
    public float _maxSpeed = 8f;
	public float _damage = 0f;
	public float _health;
	public int _ruler = 0;
	public GameObject _unitPrefab;
    public GameObject _king;
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
			if(_health<=0){
				Die ();
			}
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
	public virtual void Die(){
		Destroy (this.gameObject);
	}	
	
	public virtual void Spawn(float x, float z){
		GameObject.Instantiate (Prefab, new Vector3 (x, 0, z), new Quaternion ());
	}
	
    void Start(){
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;

        gameObject.AddComponent<Controls>();

        CapsuleCollider bc = gameObject.AddComponent<CapsuleCollider>();
        bc.isTrigger = true;

        if (!(this is King))
        {
            gameObject.tag = "UnitNeutral";
        }

        InitialMaxSpeed = MaxSpeed;
    }

	/// <summary>
	/// Player recruit this unit.
	/// </summary>
	public virtual bool Recruit(int playerNumber){
		if(Ruler == 0){
			Ruler = playerNumber;
			gameObject.tag = "Unit"+playerNumber;
            _king = GameObject.Find("King"+playerNumber);
			return true;
		}
		return false;
	}
    public void OnTriggerEnter(Collider other) {
        if (other.tag == "UnitNeutral")
        {
            print(other.name + " " + gameObject.name);
            other.GetComponent<UnitBehavior>().Recruit(Ruler);
        } else if (other.tag != "Unit" + Ruler)
        {
            // damage

        }
    }
}
