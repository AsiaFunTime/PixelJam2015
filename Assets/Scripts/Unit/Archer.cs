using UnityEngine;
using System.Collections;

public class Archer : UnitBehavior {
    
    private float ShootRange = 20f;
    float angle = 20f;
    private float ShootFrequency = 2f;
    private bool CanShoot = true;
    public GameObject Arrow;

    private float ArrowSpeed = 18f;

    void Update()
    {
        if (Ruler == 0 || !CanShoot)
            return;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, ShootRange * EnvironmentAttackModifier);

        foreach (Collider collider in hitColliders)
        {
            if(isEnemy(collider)) // Enemy
            {                
                // Check if this knight is facing the enemy
                if  ( Vector3.Angle(transform.forward, collider.transform.position - transform.position) < angle) {
                    Charge();
                    if(CanShoot)
                    {                        
                        CanShoot = false;
                        Shoot(collider.transform.position);
                    }
                    break;
                }
            }
            StopCharge();
        }
        
    }

    public void Shoot(Vector3 target){
        GameObject arrow = GameObject.Instantiate(Arrow, transform.position, transform.rotation) as GameObject;
        arrow.transform.LookAt(target);
        Arrow arrowComp = arrow.GetComponent<Arrow>();
        arrowComp.Ruler = Ruler;
        arrowComp.Target = target;
        arrowComp.ArrowSpeed = ArrowSpeed * EnvironmentAttackModifier;
        StartCoroutine(ReloadArrow());
    }

    public void Charge()
    {
        MaxSpeed = InitialMaxSpeed * 0.8f;
    }
    
    IEnumerator ReloadArrow(){
        yield return new WaitForSeconds(ShootFrequency);
        CanShoot = true;
    }

    public void StopCharge()
    {
        MaxSpeed = InitialMaxSpeed;
    }
}
