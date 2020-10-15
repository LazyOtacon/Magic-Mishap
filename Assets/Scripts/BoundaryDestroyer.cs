using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryDestroyer : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        // Destroy the other object if it is not the player
        if (!(other.gameObject.CompareTag("Player")))
        {
            Destroy(other.gameObject);
        }
    }
}