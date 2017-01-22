using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadScene : MonoBehaviour
{


    private void Start()
    {
    }

    public void loadScene()
    {
        SceneManager.LoadScene("LevelOne");

    }
}
