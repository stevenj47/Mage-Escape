using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

    
    public GameObject fireball; //model for fireball to spawn if conditions are met
    public GameObject player;
        

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (
        
            Input.GetKey("w")) {
            Vector3 forward_move = transform.forward * 0.5f;
            forward_move.y = 0.0f;
            player.transform.position += forward_move;

        }
        if (Input.GetKeyDown("f")) makeFireball();

	}
   

    void makeFireball()
    {
        GameObject fireball_clone =
            Instantiate(fireball, transform.position + 5 * transform.forward + new Vector3(0, -3, 0), transform.rotation) as GameObject;
        Rigidbody ball_body = fireball_clone.GetComponent<Rigidbody>();
        ball_body.velocity = transform.forward * 80;
    }
}
