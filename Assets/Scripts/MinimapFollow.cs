using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapFollow : MonoBehaviour {

    [SerializeField] public GameObject targetToFollow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LateUpdate()
    {
        this.transform.position = new Vector3(targetToFollow.transform.position.x, this.transform.position.y, targetToFollow.transform.position.z);
    }
}
