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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (connectedGameObject != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = pressedButtonSprite;
            connectedGameObject.BroadcastMessage("TurnOff",offTime);
            StartCoroutine(switchPressedButton());
        }
    }

    private IEnumerator switchPressedButton()
    {
        yield return new WaitForSeconds(offTime);
        gameObject.GetComponent<SpriteRenderer>().sprite = notPressedButtonSprite;
    }
}
