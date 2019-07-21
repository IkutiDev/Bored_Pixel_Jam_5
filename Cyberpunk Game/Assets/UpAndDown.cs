using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDown : MonoBehaviour
{
    public bool goDown;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= 0f)
        {
            goDown = false;
            
        }

        if (transform.position.y >= 2f)
        {
            goDown = true;
        }

        if (goDown==false)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.01f);
        }

        if (goDown)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.01f);
        }
    }
}
