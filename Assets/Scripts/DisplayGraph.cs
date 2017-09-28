using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCalc;

public class DisplayGraph : MonoBehaviour {

    public GameObject dot;
    public float valueStart;
    public float valueEnd;
    public float valueStep;
    public string mathFunction;

	void Start () {
        for (float i = valueStart; i <= valueEnd; i += valueStep)
        {
            Expression e = new Expression("Pow([value], 2)");
            e.Parameters["value"] = i;
            float value = float.Parse(e.Evaluate().ToString());
            GameObject d = Instantiate(dot, new Vector3(i, value, 0), Quaternion.identity);
            d.tag = "Value";
        }
    }
}
