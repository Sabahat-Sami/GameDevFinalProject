using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{

    public LayerMask groundLayer;
    Rigidbody2D _rigidbody;
    bool jumping = false;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, groundLayer);
        Debug.DrawRay(transform.position, -Vector2.up, Color.red);

        //Hit ground
        if(hit != false && jumping == true && hit.collider.tag == "Ground")
        {
            print(hit.collider.name);
            _rigidbody.AddForce(new Vector2(0, -500f));

            jumping = false;
        }

        //In air
        else if(hit != true && jumping == false)
        {
            print("Nothing");

            _rigidbody.AddForce(new Vector2(0, 200f));
            jumping = true;
        }

        if(transform.position.y < -2.094079)
        {
            Vector2 newPos = new Vector2(transform.position.x, -2.094079f);
            transform.position = newPos;
        }
    }
}
