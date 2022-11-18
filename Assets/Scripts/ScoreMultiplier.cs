using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            StartCoroutine(multiplyScore());
        }
    }
    IEnumerator multiplyScore(){
        PublicVars.scoreAdder = 500;
        yield return new WaitForSeconds(5f);
        PublicVars.scoreAdder = 100;
    }
}
