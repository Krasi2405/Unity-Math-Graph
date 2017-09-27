using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour {

    public GameObject verticalLine;
    public GameObject horizontalLine;
    public GameObject dot;

    [SerializeField]
    public int width = 20;

    [SerializeField]
    public int height = 20;

	void Start () {
        KeepInBounds script = Camera.main.GetComponent<KeepInBounds>();
        script.x = width;
        script.y = height;


        // Create grid cells
        for (int i = -width; i <= width; i++)
        {
            for (int j = -height; j <= height; j++)
            {
                Instantiate(verticalLine, new Vector3(i, j, 0), Quaternion.identity);
                Instantiate(horizontalLine, new Vector3(i, j, 0), Quaternion.identity);
                Instantiate(dot, new Vector3(i, j, 0), Quaternion.identity);
            }
        }

        // Create x axis
        for (int i = -width; i <= width; i++)
        {
            GameObject line = Instantiate(horizontalLine, new Vector3(i, 0, 0), Quaternion.identity);
            line.transform.localScale *= 8;
        }


        // Create y axis
        for (int i = -height; i <= height; i++)
        {
            GameObject line = Instantiate(verticalLine, new Vector3(0, i, 0), Quaternion.identity);
            line.transform.localScale *= 8;
        }

        
    }
}
