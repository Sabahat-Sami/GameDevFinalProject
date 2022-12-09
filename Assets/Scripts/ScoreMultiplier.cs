using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplier : MonoBehaviour
{
     AudioSource _audioSource;

    public AudioClip pickUp;

    void Start(){
        _audioSource = GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        Vector2 newPos = transform.position;
        newPos.x -= PublicVars.objectSpeed;
        transform.position = newPos;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            _audioSource.PlayOneShot(pickUp);
            StartCoroutine(multiplyScore());
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
    IEnumerator multiplyScore(){
        PublicVars.scoreAdder = 300;
        yield return new WaitForSeconds(5f);
        PublicVars.scoreAdder = 100;
        Destroy(this.gameObject);
    }
}
