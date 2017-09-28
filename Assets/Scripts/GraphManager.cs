using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphManager : MonoBehaviour {



    [SerializeField]
    private InputField expressionInput;
    [SerializeField]
    private InputField startInput;
    [SerializeField]
    private InputField endInput;
    [SerializeField]
    private InputField stepInput;


    private DisplayGraph displayGraph;
    

    
    void Start () {
        displayGraph = GameObject.FindObjectOfType<DisplayGraph>();
	}

    void Update()
    {

    }

    public void DeleteGraphs()
    {
        displayGraph.DeleteGraphs();
    }

    public void CreateGraph()
    {
        float start = float.Parse(startInput.text);
        float end = float.Parse(endInput.text);
        float step = float.Parse(stepInput.text);
        string expression = expressionInput.text;
        displayGraph.GenerateGraph(start, end, step, expression);

    }




}
