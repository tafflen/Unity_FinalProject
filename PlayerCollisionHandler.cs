using UnityEngine;
using System.Collections; 

public class PlayerCollisionHandler : MonoBehaviour
{   
    bool gameStarted = false;

    IEnumerator Start()
{
    yield return new WaitForSeconds(1f); // delay to let player settle
    gameStarted = true;
}

    void OnCollisionEnter(Collision collision)
    {
         if (!gameStarted) return;
        Debug.Log("Collided with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Enemy"))
        {
            //GameManager.Instance.LoseHeart();     // Lose a heart
            GameManager.Instance.AddScore(-10);   // Lose score
        }
//         else if (collision.gameObject.CompareTag("Chest"))
//         {
//             GameManager.Instance.AddScore(20);    // Gain score
//             GameManager.Instance.CollectChest();
//             Destroy(collision.gameObject);
//         }
    }
}
