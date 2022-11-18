using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D _rigidbody;

    Vector2 firstTouch;
    Vector2 lastTouch;
    Vector2 swipe;
    private float swipe_length = 70f;
    float score;
    float jumpForce = 400f;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        score = 0;
    }

    void Update()
    {
        if(Input.touchCount == 1){
            Touch touch = Input.GetTouch(0);

            //Single touch
            if(touch.phase == TouchPhase.Began)
            {
                firstTouch = new Vector2(touch.position.x, touch.position.y);
            }
            if(touch.phase == TouchPhase.Ended)
            {
                lastTouch = new Vector2(touch.position.x, touch.position.y);
                swipe = new Vector2(lastTouch.x - firstTouch.x, lastTouch.y - firstTouch.y);
                if(swipe.magnitude < swipe_length){
                    //Touch
                    Jump();
                }
                else if(swipe.y <0)
                {
                    //Swipe down
                    Down();
                }
            }
        }
        if(PublicVars.speed != 0){
            score += PublicVars.scoreAdder;
        }
        //print(score);
    }

    void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        _rigidbody.AddForce(new Vector2(0, jumpForce));
    }
    void Down()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        _rigidbody.AddForce(new Vector2(0,-800f));
    }
}
