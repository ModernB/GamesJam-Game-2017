using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{

    bool hitPlayer = false;
    public float speed;
    // Update is called once per frame
    private void Start()
    {

        
    }

    void Update ()
    {
        if (!hitPlayer)
        {
            //Move right
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hitPlayer = true;
            Debug.Log("Hit PLayer!");
        }
    }

}
