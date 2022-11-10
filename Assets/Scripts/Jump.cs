using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    float jumpForce = 300f;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            if(touch.phase == TouchPhase.Began)
            {
                print("Run");
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
                _rigidbody.AddForce(new Vector2(0, jumpForce));
            }
        }
    }
}
