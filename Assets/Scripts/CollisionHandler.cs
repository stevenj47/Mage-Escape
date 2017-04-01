using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour {

    public GameObject player;
    public GameObject player_collision;
    public GameObject explosion_;
    public int mode;

    
    int gmode;
    bool key_has_been_found;

	// Use this for initialization
	void Start () {
        gmode = mode;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnCollisionEnter(Collision collision)
    {
        if (gmode == 1) //rigidbody hit wall
        {
            Rigidbody player_body = player_collision.GetComponent<Rigidbody>();
            //Debug.Log("hit something." + collision.gameObject.tag);
            if (collision.gameObject.tag == "Untagged")
            {
                player_body.angularVelocity = new Vector3(0, 0, 0);
                //Vector3 newvel = player_body.velocity;
                //newvel.y = 0;
                //player_body.velocity = -newvel;
                //player.transform.position += -player_body.velocity;
                Debug.Log("uhoh hit a wall, back dat ass up");
            }

            //Vector3 back_move = -gameObject.transform.forward * 1.0f;
            //back_move.y = 0.0f;

            //gameObject.transform.position += back_move;
        }
        if (gmode == 2)
        {
            Debug.Log("fireball hit" + collision.gameObject.tag);
            Destroy(gameObject, 1);
            //Instantiate(explosion_, gameObject.transform);
            //Destroy(explosion_, 3);

        }

        if (gmode == 3) //Key detection mode
        {
            Rigidbody player_body = player_collision.GetComponent<Rigidbody>();
           
           //Debug.Log("hit something." + collision.gameObject.tag);
            if (collision.gameObject.tag == "Player")
            {
                if (key_has_been_found) return;
                Debug.Log("Got a key!!");
                collision.gameObject.GetComponent<GoldenKeys>().keys_found++;
                //player.GetComponentInParent<GoldenKeys>().keys_found++;
                key_has_been_found = true;
                Destroy(gameObject, 0);
            }

        }
    }
   
}

