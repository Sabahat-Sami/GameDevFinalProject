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
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }

    IEnumerator SlowTime()
    {
        PublicVars.canAccel = false;
        if(PublicVars.speed/2 < .1f)
        {
            PublicVars.speed = .1f;
        }
        else
        {
            PublicVars.speed = PublicVars.speed/2;
        }
        yield return new WaitForSeconds(5f);
        PublicVars.canAccel = true;
        Destroy(this.gameObject);

    }


}
