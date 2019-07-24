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
    [SerializeField] private bool canPressPressedButton;
    private bool pressed = false;

    public struct ButtonStruct
    {
        public float OffTime;
        public bool CanPressPressedButton;

        public ButtonStruct(float offTime, bool canPressPressedButton)
        {
            OffTime = offTime;
            CanPressPressedButton = canPressPressedButton;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (connectedGameObject != null && pressed==false)
        {
            if (!canPressPressedButton)
            {
                pressed = true;
            }

            gameObject.GetComponent<SpriteRenderer>().sprite = pressedButtonSprite;
            connectedGameObject.BroadcastMessage("TurnOff",new ButtonStruct(offTime,canPressPressedButton));
            if (canPressPressedButton)
            {
                StopAllCoroutines();
            }
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
