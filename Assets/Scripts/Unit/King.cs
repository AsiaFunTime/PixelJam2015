using UnityEngine;
using System.Collections;

public class King : UnitBehavior {
    
    public float RunAwayRange = 12f;
    float angle = 30f;
    void Update()
    {
        if (Ruler == 0)
            return;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, RunAwayRange);
        foreach (Collider collider in hitColliders)
        {
            if(collider.tag != "Unit"+Ruler && collider.tag != "Ground" && collider.tag != "UnitNeutral") // Enemy
            {                
                // Check if this knight is facing the enemy
                if  ( Vector3.Angle(-transform.forward, collider.transform.position - transform.position) < angle) {
                    print("RUNAWAY FROM " + collider.name);
                    RunAway();
                    break;
                }
            }
            Normal();
        }
        
    }
    
    public void RunAway()
    {
        MaxSpeed = InitialMaxSpeed * 1.3f;
    }
    
    public void Normal()
    {
        MaxSpeed = InitialMaxSpeed;
    }
}
