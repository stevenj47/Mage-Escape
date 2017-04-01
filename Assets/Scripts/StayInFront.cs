using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInFront : MonoBehaviour {
    [SerializeField] GameObject target;
    [SerializeField] GameObject always_face;
    [SerializeField]
    float xoffset;
    //[SerializeField] GameObject stay_in_front_of;
    public int mode;
    public bool always_face_mode;

    //public GameObject stay_in_front;
    //public Camera focal_point;
    //public Plane uiplane;

    private GameObject plane;

    private Vector3 position;
    private Quaternion orientation;
	// Use this for initialization
	void Start () {
        //Vector3 planepos = Camera.main.transform.position;
        //planepos.x = planepos.x + 10;
        //plane = GameObject.Instantiate(plane_prefab, planepos, new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
        if (mode == 1)
        {
            if (always_face)
            {
                target.transform.LookAt(always_face.transform.position);
            }
        }
        
        
    }
	
	// Update is called once per frame
	void Update () {
        //Vector3 myposition = plane_prefab.transform.position;
        //Vector3 theirposition = always_face.transform.position;
        if ((mode == 1) || always_face_mode) // mode 1: always face some gameobject
        {
            target.transform.LookAt(always_face.transform.position);
            target.transform.Rotate(0f, 180f, 0f);
        }

        if (mode == 2) // mode 2: stay in front of camera
        {
            float pos = (Camera.main.nearClipPlane + 01f);

            target.transform.position = Camera.main.transform.position + Camera.main.transform.forward * pos;
            target.transform.LookAt(Camera.main.transform);
            target.transform.Rotate(90.0f, 0.0f, 0.0f);

            float h = (Mathf.Tan(Camera.main.fieldOfView * Mathf.Deg2Rad * 0.5f) * pos * 2f) / 10.0f;

            target.transform.localScale = new Vector3(h * Camera.main.aspect, 1.0f, h);


            //target.transform.LookAt(always_face.transform.position);
            //target.transform.Rotate(0f, 180f, 0f);
        }
        //get camera orientation

        /* Camera cam = Camera.main;

        float pos = (cam.nearClipPlane + 3.01f);

        plane.transform.position = cam.transform.position + cam.transform.forward * pos;
        plane.transform.LookAt(cam.transform);
        plane.transform.Rotate(90.0f, 0.0f, 0.0f);

        float h = (Mathf.Tan(cam.fieldOfView * Mathf.Deg2Rad * 0.5f) * pos * 2f) / 10.0f;

        plane.transform.localScale = new Vector3(h * cam.aspect, 1.0f, h);
        */

        //get camera position

        //set plane position 
        //set plane orientation
        //plane.transform.LookAt(focal_point.transform.position);
        //plane.transform.Rotate(0f,90f,90f);




    }
}
