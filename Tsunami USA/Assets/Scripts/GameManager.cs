using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[RequireComponent (typeof (Image))]
public class GameManager : MonoBehaviour
{
    public GameObject start,end,player,wave;
    float levelDistance,playerProgress, waveProgress;
    bool isLevelOne;
    //UI
    public Image playerBar, waveBar;

	// Use this for initialization
	void Start ()
    {
        //load scores, if none exist create a new save in playerprefs
        if (SceneManager.GetActiveScene().name == "LevelOne")
        {
            isLevelOne = true;
            if (start == null)
            {
                start = GameObject.Find("Start");
            }
            if (end == null)
            {
                end = GameObject.Find("Goal");
            }
            if (player == null)
            {
                player = GameObject.Find("Player");
            }
            if (wave == null)
            {
                wave = GameObject.Find("Wave");
            }
            levelDistance = Vector3.Distance(start.transform.position, end.transform.position);
            
        }

        
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (isLevelOne)
        {
            //spawn player
            //Spawn Wave
            //update score
            //Update UI
            UpdateUI();

        }


    }

    void TrackScore(int score)
    {

    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void OnWin()
    {
        //Hide
    }

    public void OnLose()
    {

    }

    public void ResetLevel()
    {

    } 

    public void UpdateUI()
    {
        playerProgress = Vector3.Distance(start.transform.position, player.transform.position)/levelDistance;
        waveProgress = Vector3.Distance(start.transform.position, wave.transform.position)/levelDistance;
        if (playerProgress <= 0)
        {
            playerBar.fillAmount = 0;
        }
        else
        {
            playerBar.fillAmount = playerProgress;
        }

        if (waveProgress <= 0)
        {
            waveBar.fillAmount = 0;
        }
        else
        {
            waveBar.fillAmount = waveProgress;
        }


        //calculate wave progress
        //calculate player progress
        //set wave progress
        //set player progress


    }






}
