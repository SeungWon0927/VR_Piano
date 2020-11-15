using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]

public class PianoKeyScript : MonoBehaviour {
	
	public float semitone_offset = 0;
    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown() {
		PlayNote();
	}
	
	void OnTouch()
	{

	}

	void OnCollisionEnter() {
		PlayNote();
	}
	
	void PlayNote() {
        audioSource.pitch = Mathf.Pow (2f, semitone_offset/12.0f);
        audioSource.Play ();
	}
}
