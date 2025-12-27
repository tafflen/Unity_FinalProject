using UnityEngine;  //to access  MonoBehaviour, GameObject, Collider

public class Chest : MonoBehaviour  //MonoBehaviour:base class used for scripting game objects.
{
    public int scoreValue = 10;

    void OnTriggerEnter(Collider other)  //built-in Unity method;
    //  runs automatically when another object enters the chest's trigger collider.
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(scoreValue);  //Calls a method in the GameManager 
            Destroy(gameObject);   //Removes the chest after it's collected.
        }
    }
}
