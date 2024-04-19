using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    [Header("Speed Setup")]
    public Vector2 friction = new Vector2(.1f, 0);
    public float speedRun;
    public float speed;
    public float forceJump = 2f;

    [Header("Animation Setup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = 0.7f;
    public float scaleDuration = .3f;
    public Ease ease = Ease.OutBack;

    [Header("Animation Player")]
    public string triggerRun = "Run";
    public Animator animator;
    public float durationAnimation = 0.3f;

    private float _currentSpeed;

    private void Update()
    {
        HandleJump();
        HandleMoviment();

    }

    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.speed = 2;
            _currentSpeed = speedRun;
        }

        else
        {
            _currentSpeed = speed;
            animator.speed = 1;
        }



        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
            if (myRigidbody.transform.localScale.x != -1)
            {
                myRigidbody.transform.DOScaleX(-1, durationAnimation);
            }
            animator.SetBool(triggerRun, true);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
            if (myRigidbody.transform.localScale.x != 1)
            {
                myRigidbody.transform.DOScaleX(1, durationAnimation);
            }
            animator.SetBool(triggerRun, true);
        }
        else
        {
            animator.SetBool(triggerRun, false);
        }


        if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity += friction;
        }
        else if(myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity -= friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.velocity = Vector2.up * forceJump;
            myRigidbody.transform.localScale = Vector2.one;

            DOTween.Kill(myRigidbody.transform);

            HandleJumpScale();

        }
    }

    private void HandleJumpScale()
    {
        myRigidbody.transform.DOScaleY(jumpScaleY, scaleDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myRigidbody.transform.DOScaleX(jumpScaleX, scaleDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
}
