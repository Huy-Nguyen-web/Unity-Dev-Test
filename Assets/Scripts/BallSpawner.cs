using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ball;
    private List<Color> colors;
    // Start is called before the first frame update
    void Start()
    {
        colors = new List<Color>() { Color.green, Color.blue, Color.red };

        // Add 3 balls in different colors to the game
        for (int i = 0; i < colors.Count; i++)
        {
            addNewBall(colors[i]);
        }
        // Add 25 other balls with random color to the world
        for (int i = 0; i < 25; i++)
        {
            addNewBall(colors[Random.Range(0, 3)]);
        }
    }

    public void addNewBall(Color color)
    {
        Vector3 randomPosition = new Vector3(Random.Range(-30f, 30f), 2f, Random.Range(-30f, 30f));
        var new_ball = Instantiate(ball, this.transform);
        new_ball.transform.position = randomPosition;
        new_ball.GetComponent<Renderer>().material.color = color;
    }
}
