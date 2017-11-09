using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCalc;

public class DisplayGraph : MonoBehaviour {

    public Transform dotContainer;
    public GameObject dot;

    private List<GameObject> dotsOnScreen;

    private Color[] colors = {Color.blue, Color.red, Color.yellow, Color.green};
    private int currentColorIndex = 0;

    private void Start()
    {
        dotsOnScreen = new List<GameObject>();
    }

    public void GenerateGraph(float valueStart, float valueEnd, float valueStep, string expression)
    {
        Color graphColor = GetRandomColor();
        expression = ExpressionHumanizer.Humanize(expression);
        

        for (float i = valueStart; i <= valueEnd; i += valueStep)
        {
            // TODO: Add recognizing any parameter name, not just x
            Expression e = new Expression(expression);
            e.Parameters["x"] = i.ToString();
            float value = float.Parse(e.Evaluate().ToString());
            GameObject d = Instantiate(dot, new Vector3(i, value, 0), Quaternion.identity);
            d.transform.SetParent(dotContainer);
            d.GetComponent<Dot>().SetObjectColor(graphColor);
            d.tag = "Value";
            dotsOnScreen.Add(d);
        }
    }

    private Color GetRandomColor()
    {
        Color color = colors[currentColorIndex];
        currentColorIndex++;
        if(currentColorIndex >= colors.Length)
        {
            currentColorIndex = 0;
        }
        return color;
    }

    public void DeleteGraphs()
    {
        foreach(GameObject dot in dotsOnScreen)
        {
            Destroy(dot);
        }
    }
}
