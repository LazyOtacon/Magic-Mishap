using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // "Public" Variables
    [SerializeField] private float speed;
    [SerializeField] private float timeValue;
    // [SerializeField] private Vector2 pointA;
    // [SerializeField] private Vector2 pointB;

    // Private Variables
    private Rigidbody2D rBody;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = timeValue;
        rBody = GetComponent<Rigidbody2D>();
    }

    // Physics (Update is called once per frame)
    private void Update()
    {
        time -= Time.deltaTime;

        if (time > 0)
        {
            rBody.velocity = new Vector2(speed * -1, 0.0f);
        }
        else if (time > (timeValue * -1))
        {
            rBody.velocity = new Vector2(speed, 0.0f);
        }

        // OLD Back and forth movement
        // float time = Mathf.PingPong(Time.time * speed, 1);
        // transform.position = Vector2.Lerp(pointA, pointB, time);
    }
}