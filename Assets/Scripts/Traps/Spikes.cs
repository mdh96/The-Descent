using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {
    private Vector3 TargetLocation;
    private Vector3 StartingLocation;
    public int SpikeRate;
    public float SpikeSpeed;
    private bool Extended;
    private bool Retracted;
    public int Count;
	// Use this for initialization
	void Start () {
        StartingLocation = transform.position;
        TargetLocation = transform.position;
        TargetLocation.z = TargetLocation.z - 1.5f;
        SpikeRate = 5;
        SpikeSpeed = .8f;
        Retracted = true;
        Extended = false;
        Count = SpikeRate;
    }
	
	// Update is called once per frame
	void Update () {
        if (Retracted)
            extend();
        else if (Extended)
            retract();
        //Count--;
	}

    void extend()
    {
        float step = SpikeSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, TargetLocation, step);
        if (transform.position == TargetLocation)
        {
            Extended = true;
            Retracted = false;
        }
    }
    void retract()
    {
        float step = SpikeSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, StartingLocation, step);
        if (transform.position == StartingLocation)
        {
            Extended = false;
            Retracted = true;
        }
    }
}
