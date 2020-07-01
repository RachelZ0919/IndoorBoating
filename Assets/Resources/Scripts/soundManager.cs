using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour {

    public AudioClip clip;
    public AudioSource source;

    // Use this for initialization
    void Start () {
        source = gameObject.GetComponent<AudioSource>();
    }

    public void buttonClick()
    {
        //Debug.Log("button is clicked. play sound");
        clip = Resources.Load<AudioClip>("Music/button_sound");
        source.clip = clip;
        source.Play();
    }
}
