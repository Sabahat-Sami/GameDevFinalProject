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
        Debug.DrawRay(transform.position, hit.point, Color.red);

        //Hit ground
        if(hit != false)
        {
            print(hit.collider.name);
            //_rigidbody.AddForce(new Vector2(0, -100f));

            jumping = false;
        }

        //In air
        else if(hit == true && jumping == false)
        {
            print("Nothing");

            _rigidbody.AddForce(new Vector2(0, -800f));
            jumping = true;
        }
    }
}
