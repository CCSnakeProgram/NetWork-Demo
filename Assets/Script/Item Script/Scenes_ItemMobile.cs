using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Scenes_ItemMobile : MonoBehaviour
{
    public float mobileSpeen;
    [Space] 
    public Transform leftPos;
    public Transform rightPos;
    
    private Rigidbody2D _rigidbody2D;

    private float leftx, rightx;
    private bool isleft;
    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Setchild();
    }
    
    private void FixedUpdate()
    {
        Mobile();
    }
    
    private void Mobile()
    {
        if (isleft)
        {
            _rigidbody2D.velocity = new Vector2(-mobileSpeen, _rigidbody2D.velocity.y);
            if (transform.position.x <= leftx) {isleft = false;}
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(mobileSpeen, _rigidbody2D.velocity.y);
            if (transform.position.x >= rightx) {isleft = true;}

        }
    }

    private void Setchild()
    {
        transform.DetachChildren();
        leftx = leftPos.position.x;
        rightx = rightPos.position.x;
        Destroy(leftPos.gameObject);
        Destroy(rightPos.gameObject);
    }
}
