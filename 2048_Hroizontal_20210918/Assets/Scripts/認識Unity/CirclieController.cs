using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclieController : MonoBehaviour
{
    public Transform transform;

    public Vector2 direction;
    public float speed = 0.9f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontal;
        float vertical;

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        direction.x = horizontal;
        direction.y = vertical;

        transform.Translate(direction.x * speed, direction.y * speed, 0);

    }
}
