using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float wallDistance = 0f;
    public float walkingSpeed = 2f;
    public float climbingSpeed = 4f;

    public static bool climbing = true;

    private Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float vInput = Input.GetAxis("Vertical");
        float hInput = Input.GetAxis("Horizontal");

        RaycastHit playerHit = new RaycastHit();
        DetectHit(ref playerHit);

        // detect new wall for climbling
        if (!climbing && playerHit.collider != null && Input.GetButton("Climb"))
        {
            climbing = true;
            rb.useGravity = false;
        }
        // no wall or stop climbing
        else if (climbing && playerHit.collider == null)
        {
            climbing = false;
            rb.useGravity = true;
        }

        // climbling action.
        if (climbing)
        {
            rb.velocity = transform.up * vInput * climbingSpeed + transform.right * hInput * climbingSpeed;
            rb.angularVelocity = Vector3.zero;
            transform.rotation = Quaternion.LookRotation(playerHit.normal * -1f);
        }

        if (Input.GetKeyDown("escape"))
            Application.Quit();
            //Cursor.lockState = CursorLockMode.None;

    }

    void DetectHit(ref RaycastHit checkHit)
    {
        RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, wallDistance);
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider == GetComponent<Collider>()) continue;
            if (hit.collider.isTrigger) continue;
            if (checkHit.collider == null || hit.distance < checkHit.distance)
                checkHit = hit;
        }
    }
}
