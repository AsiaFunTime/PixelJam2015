using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
	public UnitBehavior unit;

    public float CurrentSpeed = 0f;
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

        CurrentSpeed = CurrentSpeed + (Time.deltaTime * )

        transform.Translate(Vector3.back * v * unit.Acceleration * Time.deltaTime, Space.World);
        transform.Translate(Vector3.right * h * unit.Acceleration * Time.deltaTime, Space.World);
	}
}
