using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Movement speed
    public float jumpForce = 5f; // Jump force
    private Rigidbody rb; // Reference to Rigidbody

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get Rigidbody component
    }

    void Update()
    {
        // Get movement input
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down Arrow

        // Calculate movement amount
        float moveAmountX = moveX * speed * Time.deltaTime;
        float moveAmountZ = moveZ * speed * Time.deltaTime;

        // Move the player
        transform.position = new Vector3(transform.position.x + moveAmountX, transform.position.y, transform.position.z + moveAmountZ);

        // Jump when spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Apply jump force
        }
    }
}
