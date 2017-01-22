using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(FinishIntro());
    }
	


    IEnumerator FinishIntro()
    {
        //play audio
        yield return new WaitForSeconds(22);
        SceneManager.LoadScene("LevelOne");
    }
}
