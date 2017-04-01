using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCast : MonoBehaviour {

    // Object that this ray is attached to
    [SerializeField] public GameObject attachedObj;
    [SerializeField] public GameObject player;

    // Length of the ray that is cast
    [SerializeField] public float rayLength;

    // Alpha value for ray gradient, 1.0 = green, 0.0 = red
    [SerializeField] public float alpha;

    [SerializeField] public GameObject answer_prompt;
    [SerializeField]
    public bool debug;
    [SerializeField]
    public bool is_this_lhand;

    [SerializeField]
    public int player_power; //push constant


    // The Line + Gradient that are to be drawn
    LineRenderer rayLine;
    Gradient rayGradient;
    public RaycastHit hit;

    Vector3 lhand_position;
    Vector3 old_lhand_position;

    private GameObject lastobject = null;

    private GameObject selectedobject;
     
	// Use this for initialization
	void Start () {
        answer_prompt = null;

        // Add a line to the selected gameobject
        rayLine = attachedObj.AddComponent<LineRenderer>();
        //Set the number of points
        rayLine.numPositions = 2;
        //Use world space
        rayLine.useWorldSpace = true;
        // Set width
        rayLine.widthMultiplier = 0.01f;

        // A simple 2 color gradient with an alpha value 
        rayGradient = new Gradient();
        rayGradient.SetKeys(
           new GradientColorKey[] { new GradientColorKey(Color.green, 0.0f), new GradientColorKey(new Color(1.0f, 1.0f, 0.0f, 1.0f), 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
            );
        rayLine.colorGradient = rayGradient;

        //rayLine.material.color = Color.white;

        // Initially a ray with no length
        Vector3[] initRayPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        rayLine.SetPositions(initRayPositions);
    }
	
	// Update is called once per frame
	void Update () {

        // Update ray positions
        rayLine.SetPosition(0, attachedObj.transform.position);
        rayLine.SetPosition(1, attachedObj.transform.position + (rayLength * attachedObj.transform.forward));

        // Casts ray and see if collider is hit
        if(Physics.Raycast(attachedObj.transform.position, attachedObj.transform.forward, out hit, rayLength))
        {

            if (lastobject != hit.collider.gameObject)
            {
                //lastobject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                //lastobject = hit.collider.gameObject;
            }


            if (debug)
              Debug.Log("Hit an object with tag: " + hit.collider.tag);

            if (is_this_lhand)
            {

                if (player.GetComponent<TouchControls>().select)
                {
                    selectedobject = hit.collider.gameObject;
                }
                else selectedobject = null;

                if (player.GetComponent<TouchControls>().pull)
                {
                    if (debug)
                    Debug.Log("Pull mode and target!");
                    Rigidbody object_body = hit.collider.gameObject.GetComponent<Rigidbody>();
                    object_body.velocity = -player.GetComponent<TouchControls>().player_lhand.transform.forward * player_power;
                }
                if (player.GetComponent<TouchControls>().push)
                {
                    if (debug)
                    Debug.Log("Push mode and target!");
                    if (hit.collider.tag == "WeightBox")
                    {
                        Rigidbody object_body = hit.collider.gameObject.GetComponent<Rigidbody>();
                        object_body.velocity = player.GetComponent<TouchControls>().player_lhand.transform.forward * player_power;
                        
                    }
                }
                /* update selected object if not null based on player_lhand */
                //gameObject player
                if (lhand_position != new Vector3(0, 0, 0)) 
                {
                    //update selected_obj position
                    old_lhand_position = lhand_position;
                    lhand_position = player.GetComponent<TouchControls>().player_lhand.transform.position;

                    if (selectedobject != null)
                    {
                        selectedobject.GetComponent<Rigidbody>().velocity += (lhand_position - old_lhand_position) * 4;
                    }

                }
                lhand_position = player.GetComponent<TouchControls>().player_lhand.transform.position;
            }

            if(hit.collider.tag == "Key")
            {
                string text = hit.collider.gameObject.transform.GetChild(0).GetComponent<TextMesh>().text;
                hit.collider.gameObject.GetComponent<KeyManager>().enterKey();
                if (debug)
                  Debug.Log("RayCast Hit key: " + text);
            }


           
        }

        

    }

}
