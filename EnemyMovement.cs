using UnityEngine;

public class EnemyCircularMovement : MonoBehaviour
{
    public Transform centerPoint;   // The center around which the enemy moves
    public float radiusX = 5f;      // X-axis radius (ellipse if different from Z)
    public float radiusZ = 3f;      // Z-axis radius
    public float speed = 1f;        // Speed of rotation
    public int scorePenalty = 5;    // Score reduction on collision with player

   // private float angle = 0f;
    public float startAngle = 0f;
    private float angle;

void Start()
{
    angle = startAngle;
}

    void Update()
    {
        if (centerPoint == null)
            return;

        // Increase angle over time
        angle += speed * Time.deltaTime;

        // Calculate new position using elliptical equation
        float x = Mathf.Cos(angle) * radiusX;
        float z = Mathf.Sin(angle) * radiusZ;

        // Set the position relative to the center point
        transform.position = new Vector3(centerPoint.position.x + x, transform.position.y, centerPoint.position.z + z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hi ! I'm here!");
            GameManager.Instance.ReduceScore(10);
        }
    }
}
