using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[RequireComponent (typeof (Image))]
public class GameManager : MonoBehaviour
{
    public GameObject start,end,player;
    public Wave w;
    float levelDistance,playerProgress, waveProgress;
    bool isLevelOne, introComplete;



    //UI
    public Image playerBar, waveBar;
    public GameObject UIPanel, tutorialPanel, winPanel, losePanel,introGif;
    public Button replayWin, replayLose;
    public static GameManager gm;
    BackgroundTransition bgt;

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
        introComplete = false;
        //load scores, if none exist create a new save in playerprefs
        if (SceneManager.GetActiveScene().name == "LevelOne")
        {
            isLevelOne = true;
            //UI
            UIPanel = GameObject.Find("PlayerUI");
            tutorialPanel = GameObject.Find("Tutorial");
            winPanel = GameObject.Find("Win");
            losePanel = GameObject.Find("Lose");

            introGif = GameObject.FindGameObjectWithTag("Intro");
            StartCoroutine(FinishIntro());

            start = GameObject.Find("Start");
            end = GameObject.Find("Goal");
            player = GameObject.Find("Player");
            w = GameObject.Find("Wave").GetComponent<Wave>();
            
            levelDistance = Vector3.Distance(start.transform.position, end.transform.position);




            bgt = GameObject.Find("BackgroundManager").GetComponent<BackgroundTransition>();




            UIPanel.SetActive(true);
            //tutorialPanel.SetActive(false);
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

        if (isLevelOne && introComplete)
        {
            //spawn player
            //Spawn Wave
            //update score
            //Update UI
            UpdateUI();
            

        }


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
        Debug.Log("Loose");
        UIPanel.SetActive(false);
        losePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResetLevel()
    {
        //put player back at spawn
        Player p = player.GetComponent<Player>();
        p.ResetPostion();
        bgt.ResetToStart();
        //Wave w = wave.GetComponent<Wave>();
        w.ResetPostion();
        w.canGoNow();
        //put wave back at spawn

        UIPanel.SetActive(true);
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        Time.timeScale = 1;
    }

    void HitCheckpoint()
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
        if (w == null)
        {
            w = GameObject.Find("Wave").GetComponent<Wave>();
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
        waveProgress = Vector3.Distance(start.transform.position, w.transform.position)/levelDistance;
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


    IEnumerator FinishIntro()
    {
        //play Intro audio
        //disenable intro object
        //disable UI
        UIPanel.SetActive(false);
        yield return new WaitForSeconds(22);
        introGif.SetActive(false);
        introComplete = true;
        Debug.Log("Go Wave!");
        w.canGoNow();
        

    }



}
