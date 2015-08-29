using UnityEngine;
using System.Collections;

public class Knight : UnitBehavior
{
    float angle = 20f;
    void Update()
    {
        if (Ruler == 0)
            return;

        if (MyKing.GetComponent<UnitBehavior>().enemiesInfront())
        {
            Charge();
        } else
        {
            StopCharge();
        }
    }

    public void Charge()
    {
        MaxSpeed = InitialMaxSpeed * 1.75f;
        Acceleration = InitialAcceleration * 2.2f;
    }

    public void StopCharge()
    {
        Acceleration = InitialAcceleration;
        MaxSpeed = InitialMaxSpeed;
    }
}
