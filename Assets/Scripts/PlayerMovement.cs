using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float jumpPower;
    public Renderer renderer;
    public CharacterController characterController;

    private Vector3 direction;
    private float gravity;
    private float stepOffset;
    private List<Color> colors;

    void Start()
    {
        stepOffset = characterController.stepOffset;
        colors = new List<Color> {Color.red, Color.green, Color.blue};
    }
    void Update()
    {
        Moving();
        QuitGame();
    }
    void Moving()
    {
        // Add input movement to player
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        direction = new Vector3(horizontal, 0, vertical);
        float magnitude = Mathf.Clamp01(direction.magnitude) * speed;
        direction.Normalize();

        // Add gravity to player
        gravity += Physics.gravity.y * Time.deltaTime;
        
        if (characterController.isGrounded)
        {
            gravity = -1f;
            if (Input.GetButtonDown("Jump"))
            {
                gravity = jumpPower;
            }
        } else
        {
            stepOffset = 0;
        }


        Vector3 velocity = direction * magnitude;
        velocity.y = gravity;

        characterController.Move(velocity * Time.deltaTime);

        // Rotate player to face wherever it's going
        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed);
        }
    }

    void QuitGame()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Debug.Log("Quit Game");
            Application.Quit();
        }
    }
}
