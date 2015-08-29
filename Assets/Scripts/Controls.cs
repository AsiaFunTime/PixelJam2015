using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour
{
    public UnitBehavior unit;
    public float vCurrentSpeed = 0f;
    public float hCurrentSpeed = 0f;
    private float h;
    private float v;
    private Vector3 hDirection;
    private Vector3 vDirection;
    private bool playerMoved = false;
    private float minDistanceToKing;
    public float autoSpeed = 0f;
    // Use this for initialization
    void Start()
    {
        unit = GetComponent<UnitBehavior>();
        if (unit is King)
        {
            transform.name = "King" + unit.Ruler;
        }
        minDistanceToKing = Random.Range(2, 5);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (unit.Ruler == 0)
            return;
        h = Input.GetAxis("Horizontal" + unit.Ruler);
        v = Input.GetAxis("Vertical" + unit.Ruler);



        if (isMovedByPlayer())
        {      
            autoSpeed=0f; 
            if (vIsMovedByPlayer())
            {                
                vDirection = Vector3.back;
                // Vertical Speed
                vCurrentSpeed = vCurrentSpeed + (Time.deltaTime * unit.Acceleration * v);
                vCurrentSpeed = Mathf.Clamp(vCurrentSpeed, -unit.MaxSpeed, unit.MaxSpeed);
            }
            if(hIsMovedByPlayer())
            {
                // Set Directions
                hDirection = Vector3.right;
                // Horizontal Speed
                hCurrentSpeed = hCurrentSpeed + (Time.deltaTime * unit.Acceleration * h);
                hCurrentSpeed = Mathf.Clamp(hCurrentSpeed, -unit.MaxSpeed, unit.MaxSpeed);
            }
            // Rotate
            Quaternion rotate = Quaternion.Euler(new Vector3(transform.eulerAngles.x, Mathf.Atan2(h, -v) * Mathf.Rad2Deg, transform.eulerAngles.z));
            transform.rotation = Quaternion.Lerp(transform.rotation, rotate, Time.deltaTime * unit.RotateSpeed);  
            
            playerMoved = true;
        } else
        {            
            DecelerateOrMoveToKing();
        }

        if (playerMoved)
        {
            // Move 
            transform.Translate(vDirection * vCurrentSpeed * Time.deltaTime, Space.World);
            transform.Translate(hDirection * hCurrentSpeed * Time.deltaTime, Space.World);
        }
    }
    
    void DecelerateOrMoveToKing()
    {
        //Decelerate
        float decelerationRate = Time.deltaTime * unit.Deceleration;
        if (!hIsMovedByPlayer())
        {
            hCurrentSpeed = Mathf.Lerp(hCurrentSpeed, 0, decelerationRate);
        }
        if (!vIsMovedByPlayer())
        {
            vCurrentSpeed = Mathf.Lerp(vCurrentSpeed, 0, decelerationRate);
        }


        if (!(unit is King))
        {
            playerMoved = false;
            if (unit.MyKing && !isCloseEnoughToKing()) // has king and not close enough to king
            {
                //Move to king
                autoSpeed = autoSpeed + (Time.deltaTime * unit.Acceleration); 
                autoSpeed = Mathf.Clamp(autoSpeed, -unit.MaxSpeed, unit.MaxSpeed);
                transform.position = Vector3.MoveTowards(transform.position, unit.MyKing.transform.position, autoSpeed * Time.deltaTime);

                // Look at king
                Quaternion targetRotation = Quaternion.LookRotation(unit.MyKing.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, unit.RotateSpeed * Time.deltaTime);
            }
            else{
                // decelerate
                autoSpeed = Mathf.Lerp(autoSpeed, 0, decelerationRate);
            }
        }
    }

    bool isCloseEnoughToKing(){
        float distance = Vector3.Distance (transform.position, unit.MyKing.transform.position);
        return distance <= minDistanceToKing;
    }

    bool isMovedByPlayer()
    {
        return v > 0.1f || v < -0.1 || h > 0.1f || h < -0.1;
    }
    
    bool vIsMovedByPlayer(){
        return v > 0.1f || v < -0.1;
    }
    bool hIsMovedByPlayer(){
        return h > 0.1f || h < -0.1;
    }

}
