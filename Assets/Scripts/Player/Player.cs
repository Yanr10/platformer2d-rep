using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    //public Animator animator;



    private Animator _currentPlayer;


    [Header("Setup")]
    public SOPlayer soPlayer;


    private float _currentSpeed;

    public HealthBase HealthBase;


    private void Awake()
    {
        if (HealthBase != null)
        {
            HealthBase.OnKill += OnPlayerKill;

           
        }

        _currentPlayer = Instantiate(soPlayer.player, transform);

    }

    private void OnPlayerKill()
    {
        HealthBase.OnKill -= OnPlayerKill;
        _currentPlayer.SetTrigger(soPlayer.triggerDeath);
    }


    private void Update()
    {
        HandleJump();
        HandleMoviment();

    }

    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentPlayer.speed = 2;
            _currentSpeed = soPlayer.speedRun;
        }

        else
        {
            _currentSpeed = soPlayer.speed;
            _currentPlayer.speed = 1;
        }



        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
            if (myRigidbody.transform.localScale.x != -1)
            {
                myRigidbody.transform.DOScaleX(-1, soPlayer.durationAnimation);
            }
            _currentPlayer.SetBool(soPlayer.triggerRun, true);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
            if (myRigidbody.transform.localScale.x != 1)
            {
                myRigidbody.transform.DOScaleX(1, soPlayer.durationAnimation);
            }
            _currentPlayer.SetBool(soPlayer.triggerRun, true);
        }
        else
        {
            _currentPlayer.SetBool(soPlayer.triggerRun, false);
        }


        if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity += soPlayer.friction;
        }
        else if(myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity -= soPlayer.friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.velocity = Vector2.up * soPlayer.forceJump;
            myRigidbody.transform.localScale = Vector2.one;

            DOTween.Kill(myRigidbody.transform);

            HandleJumpScale();

        }
    }

    private void HandleJumpScale()
    {
        myRigidbody.transform.DOScaleY(soPlayer.jumpScaleY, soPlayer.scaleDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayer.ease);
        myRigidbody.transform.DOScaleX(soPlayer.jumpScaleX, soPlayer.scaleDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayer.ease);
    }



    public void DestroyMe()
    {
        Destroy(gameObject);
    }

}
