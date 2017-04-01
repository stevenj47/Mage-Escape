using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyManager : MonoBehaviour {

    public GameObject answerPrompt;
    public GameObject promptWall;

    private string text;
	// Use this for initialization
	void Start () {
        text = this.gameObject.transform.GetChild(0).GetComponent<TextMesh>().text;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void enterKey()
    {
        string user_text = answerPrompt.GetComponent<TextMesh>().text;
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            if (text == "BACK")
            {
                if (user_text.Length >= 1)
                {
                    answerPrompt.GetComponent<TextMesh>().text = user_text.Substring(0, user_text.Length - 1);
                }
            }
            else if (text == "SPACE")
            {
                answerPrompt.GetComponent<TextMesh>().text = user_text + " ";
            }
            else if (text == "ENTER")
            {
                promptWall.GetComponent<PromptManager>().CheckAnswer();
            }
            else
            {
                answerPrompt.GetComponent<TextMesh>().text = user_text + text;
            }
            Debug.Log("Key: " + text + " User Answer: " + user_text);

        }
    }
}
