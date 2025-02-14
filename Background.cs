using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    public float speed = 0.5f;
    public float xEnd;
    public float xStart;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);


        if (transform.position.x < xEnd)
        {
            Vector2 pos = new Vector2(xStart, transform.position.y);
            transform.position = pos;
        }
    }



}