using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCalc;
using UnityEngine.UI;

public class DisplayGraph : MonoBehaviour {

    public Transform dotContainer;
    public GameObject dot;

    public float valueStart;
    public float valueEnd;
    public float valueStep;
    public string mathFunction;

    [SerializeField]
    private InputField inputField;

    private List<Dot> dotsOnScreen;

    private Color[] colors = { Color.black, Color.blue, Color.red, Color.yellow, Color.green};
    private int currentColorIndex = 0;

	void Start () {
        GenerateGraph("Pow(x, 2)");
        GenerateGraph("Pow(x, 2) + 1");
        GenerateGraph("Pow(x, 2) - 1");
    }

    public void GenerateGraph(string expression)
    {
        Color graphColor = GetRandomColor();
        for (float i = valueStart; i <= valueEnd; i += valueStep)
        {
            Expression e = new Expression(expression);
            e.Parameters["x"] = i;
            float value = float.Parse(e.Evaluate().ToString());
            GameObject d = Instantiate(dot, new Vector3(i, value, 0), Quaternion.identity);
            d.transform.SetParent(dotContainer);
            // d.GetComponent<Dot>().SetObjectColor(graphColor);
            d.tag = "Value";
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
}
