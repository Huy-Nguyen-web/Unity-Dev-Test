using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public TextMeshProUGUI pointText;
    public GameObject gameOverMenu;

    private GameObject ballSpawner;
    private int point;
    // Start is called before the first frame update
    void Start()
    {
        gameOverMenu.SetActive(false);
        ballSpawner = GameObject.FindGameObjectWithTag("BallSpawner");
        point = 0;
        pointText.text = point.ToString();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var hitObject = hit.gameObject;
        if (hitObject.tag == "Ball") 
        {
            Debug.Log("Hit the ball");
            if (GetComponent<Renderer>().material.color == hitObject.GetComponent<Renderer>().material.color)
            {
                // Add point and update GUI
                point++;
                UpdatePointGUI();

                // Tell the ball spawner to spawn other ball with the same color
                var currentColor = hitObject.GetComponent<Renderer>().material.color;

                // Wait for 1 second before spawn a new one
                StartCoroutine(CreateNewBall(currentColor));

                // Delete the ball
                Destroy(hitObject);

                // Change the color of player
                GetComponent<ChangeColor>().ChangeObjectColor();

                if (point >= 10)
                {
                    GameEnd("You Win");
                }
            }
            else
            {
                GameEnd("Game Over");
            }
        }
    }
    IEnumerator CreateNewBall(Color color)
    {
        yield return new WaitForSeconds(1);
        var ballSpawnerScript = ballSpawner.GetComponent<BallSpawner>();
        ballSpawnerScript.addNewBall(color);
        Debug.Log("Create new ball");
    }
    void UpdatePointGUI()
    {
        pointText.text = point.ToString();
    }
    void GameEnd(string title)
    {
        GetComponent<PlayerMovement>().enabled = false;
        gameOverMenu.SetActive(true);
        var popupScript = gameOverMenu.GetComponent<PopUpMenu>();
        popupScript.ShowPopUp(title);
    }
}
