using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
	public UnitBehavior unit;
    
    public float vCurrentSpeed = 0f;
    public float hCurrentSpeed = 0f;
	// Use this for initialization
	void Start () {
		unit = GetComponent<UnitBehavior> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (unit.Ruler == 0)
			return;

		float h = Input.GetAxis ("Horizontal" + unit.Ruler);
		float v = Input.GetAxis ("Vertical" + unit.Ruler);
        if (h > 0.1f || h < -0.1)
        {
            hCurrentSpeed = hCurrentSpeed + (Time.deltaTime * unit.Acceleration * h);
            hCurrentSpeed = Mathf.Clamp(hCurrentSpeed, -unit.MaxSpeed, unit.MaxSpeed);
        } else
        {
            float decellerationRate = Time.deltaTime * unit.Deceleration;
            hCurrentSpeed = Mathf.Lerp(hCurrentSpeed,0, decellerationRate);
        }
        
        if (v > 0.1f || v < -0.1)
        {
            vCurrentSpeed = vCurrentSpeed + (Time.deltaTime * unit.Acceleration * v);
            vCurrentSpeed = Mathf.Clamp(vCurrentSpeed, -unit.MaxSpeed, unit.MaxSpeed);
        } else
        {
            float decellerationRate = Time.deltaTime * unit.Deceleration;
            vCurrentSpeed = Mathf.Lerp(vCurrentSpeed,0, decellerationRate);
        }

        transform.Translate(Vector3.back * vCurrentSpeed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.right * hCurrentSpeed * Time.deltaTime, Space.World);

        // Rotation
        if (v > 0.1f || v < -0.1 || h > 0.1f || h < -0.1)
        {
            Quaternion rotate = Quaternion.Euler(new Vector3(transform.eulerAngles.x, Mathf.Atan2(h, -v) * Mathf.Rad2Deg, transform.eulerAngles.z));
            transform.rotation = Quaternion.Lerp(transform.rotation, rotate, Time.deltaTime * unit.RotateSpeed);  
        }
           // transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(transform.rotation.x, Mathf.Atan2(h, -v) * Mathf.Rad2Deg, transform.rotation.z, transform.rotation.w) , Time.deltaTime * unit.RotateSpeed);
            
	}
}
