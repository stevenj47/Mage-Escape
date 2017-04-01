using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DestroyWall : MonoBehaviour {

    private AudioSource[] sounds;

	// Use this for initialization
	void Start () {
		sounds = GameObject.FindGameObjectWithTag("MusicManager").GetComponents<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Fireball")
        {
            if (!sounds[3].isPlaying)
            {
                sounds[3].Play();
            }

            Destroy(this.gameObject);
        }
    }
}
