using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class Sensor : MonoBehaviour {

    public GameObject[] objs;
    private ColorCorrectionCurves cc;
    public Stamina sta;
    public float saturationRate;
    public float minSaturation;
    public float maxSaturation;
    public float increaseDecayRate = 3f;

    private float initalRate;
    private bool isDecayActive = false;
    private GameObject lava;

    void Start()
    {
        lava = GameObject.FindGameObjectWithTag("Lava");
        cc = GetComponent<ColorCorrectionCurves>();
        initalRate = sta.energy;
    }

    void Update()
    {
        RaycastHit playerHit;
        
        foreach(GameObject obj in objs)
        {
            Vector3 screenPoint = GetComponent<Camera>().WorldToViewportPoint(obj.transform.position);
            bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
            if (Physics.Raycast(transform.position, obj.transform.position - transform.position, out playerHit) && onScreen)
            {
                cc.saturation = .2f;
                if (!isDecayActive)
                {
                    isDecayActive = true;
                    sta.decayRate = sta.decayRate + increaseDecayRate;
                }
                break;
            }
            else
            {
                cc.saturation = 1f;
                if(isDecayActive)
                {
                    isDecayActive = false;
                    sta.decayRate = sta.decayRate - increaseDecayRate;
                }
            }
        }


    }

}
