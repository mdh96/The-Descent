using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMove : MonoBehaviour {
    public GameObject Player;

    public float speed = 2f;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        Vector3 playerLocation = Player.transform.position;
        

        if (Vector3.Distance(playerLocation, transform.position) < 6)
        {
            playerLocation.z = transform.position.z;
            transform.position = Vector3.MoveTowards(transform.position, playerLocation, step);
        }
        
	}
}
