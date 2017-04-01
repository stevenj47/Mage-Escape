using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallWeightToggle : MonoBehaviour {

    public GameObject wall_toggle;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Enter");
        if (wall_toggle.activeSelf)
        {
            wall_toggle.SetActive(false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!wall_toggle.activeSelf)
        {
            wall_toggle.SetActive(true);
        }
    }
}
