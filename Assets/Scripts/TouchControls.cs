using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TouchControls : MonoBehaviour {

    [SerializeField]
    GameObject player;
    [SerializeField]
    public GameObject player_lhand;
    [SerializeField]
    GameObject player_rhand;
    [SerializeField]
    GameObject player_eye;
    [SerializeField]
    GameObject menu_in;

    private TextMesh menutext;

    [SerializeField]
    public GameObject fireball;
    [SerializeField]
    public GameObject iceblast;


    private AudioSource sound_fire;

    public bool pull;
    public bool push;
    public bool select;

    [SerializeField]
    public List<AudioSource> sources;
    
    //private GameObject avatar;
    private GameObject selectedObj;

    OVRPlayerController player_script;

    Quaternion last_touch_rotation;
    Vector3 last_hit_point;
    Vector3 last_touch_position;

    public GameObject selected_object;

    int current_interaction = 0;

    List<string> interactionList = new List<string>()
    {
        "Fireball", "Pull", "Push" //"Select" //"Ice Blast"
    };


	// Use this for initialization
	void Start () {
        player_script = player.GetComponent<OVRPlayerController>();
        menutext = menu_in.GetComponent<TextMesh>();
        current_interaction = 0;
    }
	
	// Update is called once per frame
	void Update () {
        Rigidbody player_body = player.GetComponent<Rigidbody>();


        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger,
            OVRInput.Controller.RTouch) <= 0.8f)
        {
            player_body.velocity = new Vector3(0, 0, 0);
            //Debug.Log("stopped moving");
        }

        //we care about lefttouch line
        if (sources[0].time > 3.0f) { sources[0].Stop();  sources[0].time = 0; } //stop footsteps if still going.


        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger,
            OVRInput.Controller.RTouch) >= 0.8f)
            Debug.Log("Trigger");

        if ((OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger,
            OVRInput.Controller.RTouch) >= 0.8f) //hand trigger must be held
            &&
            (OVRInput.Get(OVRInput.Touch.PrimaryIndexTrigger,
            OVRInput.Controller.RTouch) == false)
            &&
            (OVRInput.Get(OVRInput.Touch.One,
            OVRInput.Controller.RTouch) == true)
            &&
            (OVRInput.Get(OVRInput.Touch.Two,
            OVRInput.Controller.RTouch) == true))
        {
            //Debug.Log("Right touch point. Move.");

            
            //player_body.velocity = player_rhand.transform.forward * 40;
            Vector3 forward_move = player_rhand.transform.forward ;
            forward_move.y = 0.0f;
            player_body.velocity += forward_move * 50;
            //player.transform.position += forward_move;
            if (!sources[0].isPlaying)
            {
                sources[0].Play();
            }

        }

        

        // If 
        if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.LTouch) == true)
        {
            Debug.Log("LTouch X pressed. ");
            if (interactionList[current_interaction] == "Fireball")
                if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch))
                makeFireball();
            if (interactionList[current_interaction] == "Ice Blast (In Progress)")
                if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch))
                    makeIceBlast();
            if (interactionList[current_interaction] == "Select")
                select = true;
            else
                select = false;
            if (interactionList[current_interaction] == "Pull")
            {
                pull = true;
                Debug.Log("pull is true");
            }
            if (interactionList[current_interaction] == "Push")
            {
                push = true;
                Debug.Log("push is true");
            }
           
        }
        else {
            if (pull || push || select)
             Debug.Log("reset bools to false");
            pull = false;  push = false; }

        if ((OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger,
           OVRInput.Controller.LTouch) >= 0.8f) //hand trigger must be held
           &&
           (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger,
           OVRInput.Controller.LTouch) >= 0.8f)
           &&
           (OVRInput.Get(OVRInput.Touch.One,
           OVRInput.Controller.LTouch) == true)
           &&
           (OVRInput.Get(OVRInput.Touch.One,
           OVRInput.Controller.LTouch) == true))
        {
            Debug.Log("Left hand fist");
            //menutext.GetComponent<Renderer>().enabled = !menutext.GetComponent<Renderer>().enabled;
            //menutext.
            

        }

        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.LTouch) == true)
        {
            Debug.Log("LTouch Y pressed. OPTION CHANGE");
            current_interaction += 1;
            if (current_interaction == interactionList.Count) current_interaction = 0;
            Debug.Log(current_interaction + " of " + (interactionList.Count-1) + " " + interactionList[current_interaction]);
            menutext.text = interactionList[current_interaction];
            //menutext.GetComponent<Renderer>().enabled = true;
        }

        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch) == true)
        {
            Debug.Log("RTouch A pressed.");
        }


        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch) == true)
        {
            Debug.Log("RTouch B pressed.");
        }
    }
    void makeFireball()
    {
        GameObject fireball_clone = 
            Instantiate(fireball, player_lhand.transform.position + 5*player_lhand.transform.forward + new Vector3(0,-5,0), player_lhand.transform.rotation) as GameObject;
        Rigidbody ball_body = fireball_clone.GetComponent<Rigidbody>();
        ball_body.velocity = player_lhand.transform.forward * 40;
        sound_fire = fireball_clone.GetComponent<AudioSource>();
        sound_fire.Play();

    }
    void makeIceBlast()
    {
        GameObject ice_clone =
            Instantiate(iceblast, player_lhand.transform.position + 5 * player_lhand.transform.forward + new Vector3(0, -5, 0), player_lhand.transform.rotation) as GameObject;
        Rigidbody ball_body = ice_clone.GetComponent<Rigidbody>();
        ball_body.velocity = player_lhand.transform.forward * 90;
        sound_fire = ice_clone.GetComponent<AudioSource>();
        sound_fire.Play();

    }
    //touch controls to support:
    //Point(RTouch) to select an object

    //Point(LTouch) point to go forward in direction of Oculus headset

    //Rtouch 'B': to change selection mode

}



