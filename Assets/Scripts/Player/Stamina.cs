using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour {

    public float energy = 100f;
    public float decayRate = 2f;
    public float intensityShake = 2f;
    public float minStaminaShake = 50f;
    private Movement movement;
    private Rigidbody rb;
    //public CameraShake camShake;
    public static bool isDecay = false;


    void Start()
    {
        movement = GetComponent<Movement>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Movement.climbing)
            isDecay = true;
        else
            isDecay = false;
    }

    void FixedUpdate()
    {
        if (energy <= 0)
        {
            movement.enabled = false;
            rb.useGravity = true;

        }
        else
        {
            if (isDecay)
            {
                energy -= decayRate * Time.fixedDeltaTime;

                if (energy < minStaminaShake)
                {
                    //camShake.isShaking = true;
                }

            }
        }

    }
}
