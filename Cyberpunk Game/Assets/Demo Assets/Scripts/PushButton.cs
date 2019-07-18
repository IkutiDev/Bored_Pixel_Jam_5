using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour
{
    [SerializeField] private GameObject connectedGameObject;
    [SerializeField] private float offTime = 5f;
    [SerializeField] private Sprite pressedButtonSprite;
    [SerializeField] private Sprite notPressedButtonSprite;
    private bool pressed = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (connectedGameObject != null && pressed==false)
        {
            pressed = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = pressedButtonSprite;
            connectedGameObject.BroadcastMessage("TurnOff",offTime);
            StartCoroutine(switchPressedButton());
        }
    }

    private IEnumerator switchPressedButton()
    {
        yield return new WaitForSeconds(offTime);
        pressed = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = notPressedButtonSprite;
    }
}
