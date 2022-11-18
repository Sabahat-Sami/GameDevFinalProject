using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplier : MonoBehaviour
{
    void Update()
    {
        Vector2 newPos = transform.position;
        newPos.x -= PublicVars.objectSpeed;
        transform.position = newPos;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            StartCoroutine(multiplyScore());
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
    IEnumerator multiplyScore(){
        PublicVars.scoreAdder = 500;
        yield return new WaitForSeconds(5f);
        PublicVars.scoreAdder = 100;
        Destroy(this.gameObject);
    }
}
