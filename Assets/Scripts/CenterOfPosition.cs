using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CenterOfPosition : MonoBehaviour
{
    public int ruler = 1;
    private float dampening = 3f;
    private Camera cam;
    private SmoothFollow smoothFollow;
    private float zoomOutSpeed = 12f;

    private float zoomInSpeed = 10f;
    private float minHeight = 24f;

    private float recalculateFrequency = 0.5f;

    private float totalTime = 0f;

    // Use this for initialization
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        cam.tag = "Camera" + ruler;
        smoothFollow = cam.GetComponent<SmoothFollow>();
        smoothFollow.height = minHeight;
    }
    Vector3 centroid ;
    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;

        if (totalTime >= recalculateFrequency)
        {

            centroid = new Vector3(0, 0, 0);
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
            totalTime = 0f;
        }
        transform.position = Vector3.Lerp(transform.position, new Vector3(centroid.x, 0, centroid.z),Time.deltaTime * dampening);

        
    }

    bool canBeSeen(GameObject unit){        
        Vector3 screenPoint = cam.WorldToViewportPoint(unit.transform.position);
        return (screenPoint.z > 0 && screenPoint.x > 0.2 && screenPoint.x < 0.8 && screenPoint.y > 0.2 && screenPoint.y < 0.8);
    }

    void zoomOut(){
        smoothFollow.height += zoomOutSpeed * Time.deltaTime;
    }

    void zoomIn(){
        smoothFollow.height -= zoomInSpeed * Time.deltaTime;
        smoothFollow.height = Mathf.Clamp(smoothFollow.height, minHeight, smoothFollow.height);
    }
}
