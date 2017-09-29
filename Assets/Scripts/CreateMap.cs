using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour {

    public GameObject verticalLine;
    public GameObject horizontalLine;
    public GameObject dot;
    public Transform mapContainer;
    public Transform dotContainer;


    public void GenerateMap(int width, int height)
    {
        // Create grid cells
        for (int i = -width; i <= width; i++)
        {
            for (int j = -height; j <= height; j++)
            {
                GameObject vLine = Instantiate(verticalLine, new Vector3(i, j, 0), Quaternion.identity);
                vLine.transform.SetParent(mapContainer);
                GameObject hLine = Instantiate(horizontalLine, new Vector3(i, j, 0), Quaternion.identity);
                hLine.transform.SetParent(mapContainer);
                GameObject d = Instantiate(dot, new Vector3(i, j, 0), Quaternion.identity);
                d.transform.SetParent(dotContainer);
            }
        }

        // Create x axis
        for (int i = -width; i <= width; i++)
        {
            GameObject line = Instantiate(horizontalLine, new Vector3(i, 0, 0), Quaternion.identity);
            line.transform.localScale *= 8;
            line.transform.SetParent(dotContainer);
        }


        // Create y axis
        for (int i = -height; i <= height; i++)
        {
            GameObject line = Instantiate(verticalLine, new Vector3(0, i, 0), Quaternion.identity);
            line.transform.localScale *= 8;
            line.transform.SetParent(dotContainer);
        }
    }

    public void RemoveMap()
    {
        foreach(Transform transform in mapContainer)
        {
            Destroy(transform.gameObject);
        }

        foreach (Transform transform in mapContainer)
        {
            Destroy(transform.gameObject);
        }
    }
}
