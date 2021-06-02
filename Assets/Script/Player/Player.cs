using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Player : MonoBehaviourPunCallbacks
{
    public float mobileSpeen;
    public float jumpSpeen;
    [Space]
    public Transform groundTransform;
    public LayerMask groundLayerMask;
    public Text NameText;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    
    private float _mobileX;

    private int jumpCount;
    private bool isJump,isGround;
    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (photonView.IsMine)
        {
            NameText.text = PhotonNetwork.NickName;
        }
        else
        {
            NameText.text = photonView.Owner.NickName;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        //************
        _mobileX = Input.GetAxisRaw("Horizontal");
        //************
        if (Input.GetButtonDown("Jump") && jumpCount>0)
        {
            isJump = true;
        }
        //************
        isGround = Physics2D.OverlapCircle(groundTransform.position, 0.1f, groundLayerMask);
    }

    private void FixedUpdate()
    {
        // if(!photonView.IsMine && PhotonNetwork.IsConnected) 
        //     return;
        Mobile();
        Jump();
        SwitchAnimation();
    }
    
    private void Mobile()
    {
        _rigidbody2D.velocity = new Vector2(_mobileX * mobileSpeen, _rigidbody2D.velocity.y);
        if(_mobileX>0)
        {
            _spriteRenderer.flipX = false;
        }
        if(_mobileX<0)
        {
            _spriteRenderer.flipX = true;
        }
    }

    private void Jump()
    {
        if (isGround)
        {
            jumpCount = 2;
        }
        if (isGround && isJump)
        {
            jumpCount--;
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpSpeen);
            isJump = false;
        }
        else if (isJump)
        {
            jumpCount--;
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpSpeen);
            isJump = false;
        }
    }

    private void SwitchAnimation()
    {
        _animator.SetBool("isrun", Mathf.Abs(_mobileX) > 0.1f);
    }
}
