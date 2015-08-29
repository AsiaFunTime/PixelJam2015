using UnityEngine;
using System.Collections;

public class Knight : UnitBehavior
{
    public float ChargeRange = 25f;
    float angle = 10f;
    void Update()
    {
        if (Ruler == 0)
            return;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, ChargeRange);
        foreach (Collider collider in hitColliders)
        {
            if(isEnemy(collider)) // Enemy
            {                
                // Check if this knight is facing the enemy
                if  ( Vector3.Angle(transform.forward, collider.transform.position - transform.position) < angle) {
                    Charge();
                    break;
                }
            }
            StopCharge();
        }

    }

    public void Charge()
    {
        MaxSpeed = InitialMaxSpeed * 1.4f;
    }

    public void StopCharge()
    {
        MaxSpeed = InitialMaxSpeed;
    }
}
