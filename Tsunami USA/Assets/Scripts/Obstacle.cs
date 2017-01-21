using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int density;//Percentage in which it slows player down
    public int slowPlayerByTime;//In seconds

	void Start ()
    {
        if (density == null || density <= 0)
        {
            density = 1;
        }
        if (slowPlayerByTime == null || slowPlayerByTime <= 0)
        {
            slowPlayerByTime = 1;
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }

    public int getDensity()
    {
       
        return density;
    }

    public int getPlayerSlowTime()
    {

        return slowPlayerByTime;
    }
}
