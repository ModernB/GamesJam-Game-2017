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
    public GameObject UIPanel, tutorialPanel, winPanel, losePanel;
    public Button replayWin, replayLose;
    public static GameManager gm;

    private void Awake()
    {
        if (gm != null)
        {
            Destroy(gameObject);
        }
        else
        {
            gm = this;
            DontDestroyOnLoad(this.gameObject);

        }
    }
    // Use this for initialization
    void Start ()
    {
        
        //load scores, if none exist create a new save in playerprefs
        if (SceneManager.GetActiveScene().name == "LevelOne")
        {
            isLevelOne = true;

                start = GameObject.Find("Start");
            

                end = GameObject.Find("Goal");
           

                player = GameObject.Find("Player");

                wave = GameObject.Find("Wave");
            
            levelDistance = Vector3.Distance(start.transform.position, end.transform.position);

            //UI
            UIPanel = GameObject.Find("PlayerUI");
            tutorialPanel = GameObject.Find("Tutorial");
            winPanel = GameObject.Find("Win");
            losePanel = GameObject.Find("Lose");

            replayWin =  GameObject.Find("WReplay").GetComponent<Button>();
            replayLose = GameObject.Find("LReplay").GetComponent<Button>();
            if (replayWin == null)
            {
                Debug.Log("wr gone");
            }



            UIPanel.SetActive(true);
            tutorialPanel.SetActive(false);
            winPanel.SetActive(false);
            losePanel.SetActive(false);

            //Listening to Player actions
            Player.GameOver += OnLose;
            Player.GameWon += OnWin;

            

            Time.timeScale = 1;


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


    public void OnWin()
    {
        
        if (UIPanel == null)
        {
            UIPanel = GameObject.Find("UIPanel");
            Debug.Log("UI GOne");
        }
        UIPanel.SetActive(false);
        winPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnLose()
    {
        UIPanel.SetActive(false);
        losePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResetLevel()
    {
        //put player back at spawn
        Player p = player.GetComponent<Player>();
        p.ResetPostion();

        Wave w = wave.GetComponent<Wave>();
        w.ResetPostion();
        //put wave back at spawn

        UIPanel.SetActive(true);
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        Time.timeScale = 1;
    }

    void PauseGame()
    {

    }

    public void UpdateUI()
    {
        if (start == null)
        {
            Debug.Log("startlost");
            start = GameObject.Find("Start");
        }
        if (player == null)
        {
            Debug.Log("playerlost");
            player = GameObject.Find("Player");
        }
        if (wave == null)
        {
            wave = GameObject.Find("Wave");
        }

        if (playerBar == null)
        {
            playerBar = GameObject.Find("PlayerProgress").GetComponent<Image>();
        }

        if (waveBar == null)
        {
            waveBar = GameObject.Find("PlayerProgress").GetComponent<Image>();
        }

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

        if(waveProgress >= playerProgress)
        {

            OnLose();
        }


    }






}
