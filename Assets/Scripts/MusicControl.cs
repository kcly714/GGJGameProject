using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicControl : MonoBehaviour
{
    public AudioMixerSnapshot Explore;
    public AudioMixerSnapshot DifficultySleeping;
    public float bpm = 128;

    private float m_TransitionIn;
    private float m_TransitionOut;
    private float m_QuarterNote;

    // Start is called before the first frame update
    void Start()
    {
        m_QuarterNote = 60 / bpm;
        m_TransitionIn = m_QuarterNote;
        m_TransitionOut = m_QuarterNote;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DifficultySleepingZone"))
        {
            DifficultySleeping.TransitionTo(m_TransitionIn);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("DifficultySleepingZone"))
        {
            Explore.TransitionTo(m_TransitionOut);
        }
    }
}
