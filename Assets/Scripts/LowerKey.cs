using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerKey : MonoBehaviour {

    public GameObject key;

    private Vector3 init_position;
	// Use this for initialization
	void Start () {
        init_position = key.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Collision stay");
        Vector3 box_transform = key.transform.position;
        if(box_transform.y > 3.0f)
        {
            key.transform.position = box_transform + new Vector3(0.0f, -1.0f, 0.0f);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        key.transform.position = init_position;
    }
}
