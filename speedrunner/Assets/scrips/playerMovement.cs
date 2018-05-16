using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {
    public Rigidbody rb;
    public GameObject Player;
    public float forceUp = 2000f;
    public float forceLeft = 2000f;
    public bool onGrond;
    public Transform greed;
    public GameObject completeLevelUI;

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }


    // Use this for initialization
    void Start () {
        onGrond = true;
        rb.velocity = Vector3.zero;
        Player.transform.position = greed.position;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        rb.AddForce(0, 0, forceUp * Time.deltaTime);
        if (onGrond)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity += new Vector3(0f, 6f, 0f);
                onGrond = false;
            }
        }

            if (Input.GetMouseButton(0))
        {
            rb.AddForce(forceLeft * Time.deltaTime, 0, 0);
        }
        if (Input.GetMouseButton(1))
        {
            rb.AddForce(-forceLeft * Time.deltaTime,0 , 0);
        }
        
    }
    void OnCollisionEnter(Collision any)
    {
        if( any.gameObject.CompareTag("ground")){

            onGrond = true;
        }
        else if(any.gameObject.CompareTag("osticle")){
            
            Start();
        }

    }

}
