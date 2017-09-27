using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour {

    public GameObject verticalLine;
    public GameObject horizontalLine;
    public GameObject dot;

	void Start () {
        for (int i = -20; i <= 20; i++)
        {
            for (int j = -20; j <= 20; j++)
            {
                Instantiate(verticalLine, new Vector3(i, j, 0), Quaternion.identity);
                Instantiate(horizontalLine, new Vector3(i, j, 0), Quaternion.identity);
                Instantiate(dot, new Vector3(i, j, 0), Quaternion.identity);
            }
        }
    }
}
