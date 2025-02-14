using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Hands : MonoBehaviour
{

    public float speed = 0.5f;
    public float yEnd;
    public float yStart;

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);


        if (transform.position.y < yEnd)
        {
            Vector2 pos = new Vector2(transform.position.x, yStart);
            transform.position = pos;
        }
    }



}