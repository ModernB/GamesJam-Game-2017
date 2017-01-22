using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundTransition : MonoBehaviour
{

    public GameObject[] images = new GameObject[13];
    int index;
    public float smoothing;
	// Use this for initialization
	void Start ()
    {
        ResetToStart();
        index = 0;
        Player.CheckpointHit += NextImage;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    public void ResetToStart()
    {
        foreach (GameObject g in images)
        {
            g.SetActive(false);
            //g.GetComponent<Animation>
        }
        images[0].SetActive(true);
        index = 0;
    }

    public void NextImage()
    {
        Debug.Log("Loading!");
        images[index].SetActive(false);
        index++;
        images[index].SetActive(true);
    }

}
