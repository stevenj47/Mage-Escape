using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenKeys : MonoBehaviour {

    [SerializeField]
    public AudioSource keyfound;

    [SerializeField]
    public AudioSource victory;

    [SerializeField]
    public TextMesh keysdisplay;

    public int keys_found;
    int prevkeys;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (keys_found != prevkeys)
        {
            prevkeys = keys_found;
            foundAKey();
        }
        
	}

    public void foundAKey()
    {
        //keys_found++;
        if (keys_found == 4) { victory.Play();
            keysdisplay.text = "You win!";
        }
        else
        {
            keyfound.Play();
            keysdisplay.text = keys_found + "/4";
        }

        
    }

}
