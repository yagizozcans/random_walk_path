using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    Camera cam;

    public float scrollSpeed;
    public float cameraSpeed;

    float orthSize;

    Vector3 startMousePos;
    Vector3 endMousePos;
    Vector3 finalPos;

    public bool lockCamera;

    public Transform lrCircle;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        camerascrollvoid();

        if (Input.GetKeyDown(KeyCode.L))
        {
            if(lockCamera)
            {
                finalPos = new Vector3(lrCircle.position.x, lrCircle.position.y, transform.position.z);
            }
            lockCamera = !lockCamera;
        }
        if(!lockCamera)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }


            if (Input.GetMouseButtonUp(0))
            {
                endMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                finalPos = endMousePos - startMousePos + transform.position;
            }

            transform.position = Vector3.Lerp(transform.position, new Vector3(finalPos.x, finalPos.y, transform.position.z), cameraSpeed);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(lrCircle.position.x, lrCircle.position.y, transform.position.z), cameraSpeed);
        }
    }

    public void camerascrollvoid()
    {
        orthSize = Mathf.Clamp(-Input.mouseScrollDelta.y + orthSize, 2, 100);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, orthSize, scrollSpeed);
    }
}
