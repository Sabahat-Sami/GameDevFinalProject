using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatyBox : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    // Start is called before  the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                _rigidbody.AddForce(touch.deltaPosition);
            }
        }
    }
}
