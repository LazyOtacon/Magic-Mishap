using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // "Public" Variables
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private Vector2 pointA;
    [SerializeField] private Vector2 pointB;

    // Private Variables
    // private Rigidbody2D rBody;

    // Start is called before the first frame update
    void Start()
    {
        // rBody = GetComponent<Rigidbody2D>();
    }

    // Physics (Update is called once per frame)
    private void FixedUpdate()
    {
        // Back and forth movement
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector2.Lerp(pointA, pointB, time);
    }
}