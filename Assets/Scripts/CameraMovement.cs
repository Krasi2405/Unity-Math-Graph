using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    

    [SerializeField]
    public float cameraBaseMoveSpeed = 0.1f;
    
    [SerializeField]
    public float cameraScaleSpeed = 0.05f;

    [SerializeField]
    public float cameraMaxSize = 25f;
    [SerializeField]
    public float cameraMinSize = 1f;

    private Camera camera;

    void Start()
    {
        camera = GetComponent<Camera>();
    }


    void Update() {

        if (IsShiftClicked())
        {
            

            if (Input.GetKey(KeyCode.W) && camera.orthographicSize < cameraMaxSize)
            {
                camera.orthographicSize += cameraScaleSpeed;
            }

            if (Input.GetKey(KeyCode.S) && camera.orthographicSize > cameraMinSize)
            {
                camera.orthographicSize -= cameraScaleSpeed;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(new Vector3(0, GetCameraMoveSpeed(), 0));
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(new Vector3(0, -GetCameraMoveSpeed(), 0));
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(new Vector3(-GetCameraMoveSpeed(), 0, 0));
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(new Vector3(GetCameraMoveSpeed(), 0, 0));
            }
        }
    }



    public bool IsShiftClicked()
    {
        return Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
    }

    public float GetCameraMoveSpeed()
    {
        return cameraBaseMoveSpeed * camera.orthographicSize / 5;
    }
}
