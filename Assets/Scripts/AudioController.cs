using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour {

    public AudioMixerSnapshot bg1;
    public AudioMixerSnapshot bg2;
    public AudioMixerSnapshot bg3;

    public static bool isWalking;

    float bpm = 128;

    private float m_TransitionIn;
    private float m_TransitionOut;
    private float m_QuarterNote;

    private string currentTag;

    // Use this for initialization
    void Start () {
        m_QuarterNote = 60 / bpm;
        m_TransitionIn = m_QuarterNote;
        m_TransitionOut = m_QuarterNote * 32;
        currentTag = "Transition 1";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(currentTag))
        {
            if (other.CompareTag("Transition 1"))
            {
                bg1.TransitionTo(m_TransitionIn);
                currentTag = other.tag;
            }
            else if (other.CompareTag("Transition 2"))
            {
                bg2.TransitionTo(m_TransitionIn);
                currentTag = other.tag;
            }
            else if (other.CompareTag("Transition 3"))
            {
                bg3.TransitionTo(m_TransitionIn);
                currentTag = other.tag;
            }
            else
            {
                
                //Debug.Log(other.tag);
            }
        }
    }
}
