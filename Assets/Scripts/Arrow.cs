using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

    public int Ruler;
    public float LifeTimeSeconds = 3f;
    public float Damage = 1f;
    public float ArrowSpeed = 9f;
    public Vector3 Target;
    private AudioManagerScript audio;
	// Use this for initialization
    void Start () {
        audio = GameObject.FindGameObjectWithTag("GameManager").GetComponent<AudioManagerScript>();
        StartCoroutine(InitiateArrow());
        audio.Play("arrowShoot");

	}
	
	// Update is called once per frame
	void Update () {
        if (Ruler == 0)
            return;
        transform.position += transform.forward * Time.deltaTime * ArrowSpeed;
        //transform.position = (transform.position, Target, ArrowSpeed * Time.deltaTime);

	}

    private bool canDamage = true;
    void OnTriggerEnter(Collider other){
        if (isEnemy(other))
        {            
            if (canDamage)
            {
                canDamage=false;
                print(gameObject.name + Ruler + " hits " + other.name + " for " + Damage + " damage");
                // damage
                other.GetComponent<UnitBehavior>().TakeDamage(Damage, Ruler);
                Hit();
            }
        }
    }

    void Disappear(){        
        GameObject.Destroy(gameObject);
    }
    void Hit(){
        audio.Play("arrowCollide");
        GameObject.Destroy(gameObject);
    }

    IEnumerator InitiateArrow(){
        yield return new WaitForSeconds(LifeTimeSeconds);
        Disappear();
    }
    public bool isEnemy(Collider other){
        return other.tag.Contains("Unit") && !other.tag.Contains("Unit" + Ruler) && !other.tag.Contains("UnitNeutral");
    }
}
