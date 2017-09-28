using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Created using
// http://answers.unity3d.com/questions/547513/how-do-i-detect-when-mouse-passes-over-an-object.html
// https://docs.unity3d.com/ScriptReference/Physics2D.Raycast.html
public class CoordinateDisplay : MonoBehaviour {

    [SerializeField]
    private Text tooltip;
    [SerializeField]
    private Text x;
    [SerializeField]
    private Text y;
    

	void FixedUpdate () {
        
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.up);
        Debug.Log("Throwing ray!");
        if (hit)
        {
            Dot dot = hit.transform.GetComponent<Dot>();
            Debug.Log("Hit : " + hit.transform.name);
            if(dot)
            {
                x.text = "X: " + Math.Round(dot.transform.position.x, 2);
                y.text = "Y: " + Math.Round(dot.transform.position.y, 2);
                tooltip.text = "Current  dot  coordinates";
            }
            
        }
        else
        {
            Vector3 coords = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("Mouse coords x: " + coords.x);
            Debug.Log("Mouse coords y: " + coords.y);
            x.text = "X: " + Math.Round(coords.x, 2);
            y.text = "Y: " + Math.Round(coords.y, 2);
            tooltip.text = "Current mouse coordinates";
        }

    }
}
