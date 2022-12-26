using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Renderer renderer;
    public Color color;

    private List<Color> colors;
    void Start()
    {
        colors = new List<Color>() { Color.green, Color.blue, Color.red };
        if (gameObject.tag == "Ball")
        {
            renderer.material.color = color;
        }
        else
        {
            ChangeObjectColor();
        }
    }

    public void ChangeObjectColor()
    {
        renderer.material.color = colors[Random.Range(0, 3)];
    }
}
