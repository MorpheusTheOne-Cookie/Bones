using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float speed = 2;
    public float lifetime = 4;

    void Update()
    {
        Destroy(gameObject, lifetime);
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player2"))
        {
            // Reset level
            Destroy(gameObject);
        }

    }


}
