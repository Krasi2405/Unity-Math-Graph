using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour {

    [SerializeField]
    private GameObject normal;
    [SerializeField]
    private GameObject glowing;


    private SpriteRenderer spriteRenderer;
    private Color currentColor;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        GetPropertiesOfSpritePrefab(normal);
    }
    
    public void SetObjectColor(Color color)
    {
        currentColor = color;
        spriteRenderer.color = color;
    }

    private void OnMouseEnter()
    {
        GetPropertiesOfSpritePrefab(glowing);
        spriteRenderer.sortingOrder += 1;
        transform.localScale *= 2;
    }

    private void OnMouseExit()
    {
        GetPropertiesOfSpritePrefab(normal);
        spriteRenderer.sortingOrder -= 1;
        transform.localScale /= 2;
    }

    private void GetPropertiesOfSpritePrefab(GameObject obj2)
    {
        spriteRenderer.sprite = obj2.GetComponent<SpriteRenderer>().sprite;
        if (currentColor == null)
        {
            spriteRenderer.color = obj2.GetComponent<SpriteRenderer>().color;
        }
        else
        {
            spriteRenderer.color = currentColor;
        }
    }
}
