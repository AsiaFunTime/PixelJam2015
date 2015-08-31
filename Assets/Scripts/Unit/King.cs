using UnityEngine;
using System.Collections;

public class King : UnitBehavior {
    
    public float DetectBehindRange = 12f;
    public float DetectInfrontRange = 24f;
    float angle = 180f;

    private bool yellCharge = true;
    void Update()
    {
        if (Ruler == 0)
            return;
        enemyBehind = false;
        enemyInfront = false;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, DetectInfrontRange);
        foreach (Collider collider in hitColliders)
        {
            if(isEnemy(collider)) // Enemy
            {                
                // Check if this unit is running away enemy
                if  ( Vector3.Angle(-transform.forward, collider.transform.position - transform.position) < angle && !enemyBehind) {
                    //print("RUNAWAY FROM " + collider.name);
                    enemyBehind = true;
                    
                    RunAway();
                }
                if  ( Vector3.Angle(transform.forward, collider.transform.position - transform.position) < angle && !enemyInfront) {
                    //print("RUNAWAY FROM " + collider.name);
                    enemyInfront = true;
                    if(yellCharge)
                    {                        
                        yellCharge=false;
                        audio.Play("charge");
                    }
                }
            }
        }
        if (!enemyBehind)
        {
            Normal();
        }
        if (!enemyInfront)
        {
            yellCharge = true;
        }

        if (Input.GetButton("SB" + Ruler))
        {
            print("Slowing DOWN");
            ShouldButtonSpeedModifier = 0.5f;
        }
        else 
        {
            print("SPEEDING UP");
            ShouldButtonSpeedModifier = 1f;
        }
        if (Input.GetButtonDown("SB" + Ruler))
        {
            audio.Play("bugle");
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
