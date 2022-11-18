using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = transform.position;
        newPos.x -= PublicVars.objectSpeed;
        transform.position = newPos;
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            PublicVars.maxAirJumps +=1;
            other.GetComponent<PlayerMovement>().increaseJump();
            Destroy(this.gameObject);
        }
    }



}
