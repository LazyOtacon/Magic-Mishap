using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    // "Public" Variables
    // [SerializeField] private GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Detect when another object collides with this object
    void OnCollisionEnter2D(Collision2D other)
    {
        // Create and position the explosion
        // Instantiate(explosion, transform.position, transform.rotation);

        // Delete the "other" object
        // Delete this object
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}