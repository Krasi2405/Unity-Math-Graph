using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeManager : MonoBehaviour {

    [SerializeField]
    private InputField widthInput;
    [SerializeField]
    private InputField heightInput;
    

    private CreateMap createMap;

	void Start () {
        createMap = createMap = GameObject.FindObjectOfType<CreateMap>();
        GenerateMap(20, 20);
    }
	

    public void GenerateMap()
    {
        GenerateMap(int.Parse(widthInput.text), int.Parse(heightInput.text));
    }


	public void GenerateMap(int width, int height)
    {
        KeepInBounds script = Camera.main.GetComponent<KeepInBounds>();
        script.x = width;
        script.y = height;

        createMap.RemoveMap();
        createMap.GenerateMap(width, height);
    }
}
