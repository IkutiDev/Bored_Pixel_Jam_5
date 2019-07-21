using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlHuman : MonoBehaviour
{
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float jumpLength;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float jumpHeight;
    private Vector2 startPos;
    private Vector2 targetPos;
    private Animator animator;
    private Rigidbody2D _rigidbody2D;
    public enum HumanState
    {
        Stop,
        Walk,
        Run,
        Jump,
        Jumping
    }

    public HumanState currentState=HumanState.Stop;
    private static readonly int State = Animator.StringToHash("State");

    private void Awake()
    {
        animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        switch (currentState)
        {
            case HumanState.Stop:
                Stop();
                break;
            case HumanState.Walk:
                Walk();
                break;
            case HumanState.Run:
                Run();
                break;
            case HumanState.Jump:
                startPos = transform.position;
                targetPos = new Vector2(startPos.x+jumpLength,startPos.y);
                animator.SetInteger(State, (int)HumanState.Jump);
                currentState = HumanState.Jumping;
                break;
            case HumanState.Jumping:
                Jump();
                break;
            default:
                Debug.LogError("Error in the ControlHuman Script");
                break;
        }
    }

    private void Run()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position+runSpeed * Time.fixedDeltaTime  * Vector2.right);
        animator.SetInteger(State, (int)HumanState.Run);
    }

    private void Walk()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + runSpeed* Time.fixedDeltaTime * Vector2.right);
        animator.SetInteger(State, (int)HumanState.Walk);
    }

    private void Jump()
    {
        float x0 = startPos.x;
        float x1 = targetPos.x;
        float dist = x1 - x0;
        float nextX = Mathf.MoveTowards(transform.position.x, x1, jumpSpeed * Time.deltaTime);
        float baseY = Mathf.Lerp(startPos.y,targetPos.y,(nextX-x0)/dist);
        float arc = jumpHeight*(nextX-x0)*(nextX-x1)/(-0.25f*dist*dist);
        Vector2 nextPos = new Vector2(nextX,baseY+arc);
        transform.position = nextPos;
        if (nextPos == targetPos)
        {
            currentState = HumanState.Stop;
        }
    }

    private void Stop()
    {
        animator.SetInteger(State,(int) HumanState.Stop);
    }
}
