using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptManager : MonoBehaviour {

    public GameObject prompt;
    public GameObject answer;
    public GameObject vr_keyboard;
    public string answer_text;

	// Use this for initialization
	void Start () {
        prompt.SetActive(false);
        answer.SetActive(false);
        vr_keyboard.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Entered Into Collision With...");
        prompt.SetActive(true);
        answer.SetActive(true);
        vr_keyboard.SetActive(true);
    }

    public void CheckAnswer()
    {
        string user_text = answer.GetComponent<TextMesh>().text;
        user_text = user_text.ToLower().Trim();
        Debug.Log("User input is: _" + user_text + "_ Answer text: _" + answer_text + "_");
        if(string.Equals(user_text, answer_text))
            
        {
            Debug.Log("They are equal...");
            this.gameObject.SetActive(false);
        }

    }
}
