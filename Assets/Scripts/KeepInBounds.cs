using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Created with help from
// http://answers.unity3d.com/questions/501893/calculating-2d-camera-bounds.html
public class KeepInBounds : MonoBehaviour {

    [SerializeField]
    private float x;
    [SerializeField]
    private float y;



    private void LateUpdate() {
        Vector3 position = transform.position;
        float cameraSize = GetComponent<Camera>().orthographicSize;
        position.x = Mathf.Clamp(
            position.x,
            -x + cameraSize * Screen.width / Screen.height,
            x - cameraSize * Screen.width / Screen.height);
        position.y = Mathf.Clamp(
            position.y,
            -y + cameraSize,
            y - cameraSize);

        transform.position = position;
    }
}
