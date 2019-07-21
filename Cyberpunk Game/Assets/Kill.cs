using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Human"))
        {
            GameObject.Find("GameStateManager").GetComponent<GameStateManager>().LooseGame();
        }
    }
}
