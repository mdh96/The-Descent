using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float sensitivity = 5f;
    public float smoothing = 2f;
    public float minYLook = -90f;
    public float maxYLook = 90f;
    public float minXLook = -90f;
    public float maxXLook = 90f;

    private Vector2 mouseLook;
    private Vector2 smoothV;

    void Update()
    {

        Vector2 mouseDir = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseDir = Vector2.Scale(mouseDir, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, mouseDir.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, mouseDir.y, 1f / smoothing);
        mouseLook += smoothV;

        mouseLook.y = Mathf.Clamp(mouseLook.y, minYLook, maxYLook);

        if (Movement.climbing)
        {
            mouseLook.x = Mathf.Clamp(mouseLook.x, minXLook, maxXLook);
            transform.localEulerAngles = new Vector3(-mouseLook.y, mouseLook.x, 0f);
        }
        else
        {
            transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
            transform.parent.gameObject.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, Vector3.up);
        }

    }
}
