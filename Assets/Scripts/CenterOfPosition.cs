using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CenterOfPosition : MonoBehaviour
{
    public int ruler = 1;
    public float dampening = 5f;
    private Camera cam;
    private SmoothFollow smoothFollow;
    public float zoomOutSpeed = 17f;

    public float zoomInSpeed = 10f;
    public float minHeight = 8f;
    // Use this for initialization
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        cam.tag = "Camera" + ruler;
        smoothFollow = cam.GetComponent<SmoothFollow>();
        smoothFollow.height = minHeight;
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 centroid = new Vector3(0, 0, 0);
        GameObject[] units = GameObject.FindGameObjectsWithTag("Unit" + ruler);
        bool zoomedOut = false;
        foreach (GameObject unit in units)
        {
            if(!canBeSeen(unit)){
                // Zoom out
                zoomedOut = true;
                zoomOut();
            }

            if(!zoomedOut){
                // zoom in
                zoomIn();
            }
            centroid += unit.transform.position;
        }
        centroid /= units.Length;

        transform.position = Vector3.Lerp(transform.position, new Vector3(centroid.x, 0, centroid.z),Time.deltaTime * dampening);

        
    }

    bool canBeSeen(GameObject unit){        
        Vector3 screenPoint = cam.WorldToViewportPoint(unit.transform.position);
        return (screenPoint.z > 0 && screenPoint.x > 0.2 && screenPoint.x < 0.8 && screenPoint.y > 0 && screenPoint.y < 1);
    }

    void zoomOut(){
        smoothFollow.height += zoomOutSpeed * Time.deltaTime;
    }

    void zoomIn(){
        smoothFollow.height -= zoomInSpeed * Time.deltaTime;
        smoothFollow.height = Mathf.Clamp(smoothFollow.height, minHeight, smoothFollow.height);
    }
}
