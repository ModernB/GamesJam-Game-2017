using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioClip[] track;
	// Use this for initialization
	void Start ()
    {
        playIntro();

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    IEnumerator playIntro()
    {
        AudioSource audio = this.GetComponent<AudioSource>();
        audio.PlayOneShot((AudioClip)Resources.Load("main music PART ONE"));
        /*
        audio.clip = track[0];
        audio.Play();
       
        audio.Stop();
        audio.clip = track[1];
        audio.Play();
        */

        yield return new WaitForSeconds(22);
    }
}
