using UnityEngine;
using System.Collections;

public class Peasant : UnitBehavior {

    void Update()
    {
        if (Ruler == 0)
            return;
        if (MyKing.GetComponent<UnitBehavior>().enemiesBehind())
        {
            RunAway();
        } else
        {            
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
