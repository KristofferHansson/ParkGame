using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Zoom
        if (Input.mouseScrollDelta.y > 0)
        {
            //print("Scrolling up");
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y - 1, cam.transform.position.z);
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            //print("Scrolling down");
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y + 1, cam.transform.position.z);
        }

        // Movement
        float horiz = 0, vert = 0;
        if (Input.GetKey(KeyCode.W))
            vert += 1;
        if (Input.GetKey(KeyCode.S))
            vert -= 1;
        if (Input.GetKey(KeyCode.D))
            horiz += 1;
        if (Input.GetKey(KeyCode.A))
            horiz -= 1;

        vert *= 0.05f;
        horiz *= 0.05f;
        cam.transform.position = new Vector3(cam.transform.position.x + horiz, cam.transform.position.y, cam.transform.position.z + vert);
    }
}
