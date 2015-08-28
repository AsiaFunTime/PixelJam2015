using UnityEngine;
using System.Collections;

public class CenterOfPosition : MonoBehaviour
{
    public int ruler = 1;
    public float dampening = 5f;
    // Use this for initialization
    void Start()
    {
        Camera camera = GetComponentInChildren<Camera>();
        camera.tag = "Camera" + ruler;
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 centroid = new Vector3(0, 0, 0);
        GameObject[] units = GameObject.FindGameObjectsWithTag("Unit" + ruler);
        foreach (GameObject unit in units)
        {
            centroid += unit.transform.position;
        }
        centroid /= units.Length;

        transform.position = Vector3.Lerp(transform.position, new Vector3(centroid.x, 0, centroid.z),Time.deltaTime * dampening);
    }
}
