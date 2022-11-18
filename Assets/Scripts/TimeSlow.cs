using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlow : MonoBehaviour
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
            StartCoroutine(SlowTime());
            Destroy(this.gameObject);
        }
    }

    IEnumerator SlowTime()
    {
        PublicVars.canAccel = false;
        PublicVars.speed = PublicVars.speed/2;
        yield return new WaitForSeconds(5f);
        PublicVars.canAccel = false;

    }


}
