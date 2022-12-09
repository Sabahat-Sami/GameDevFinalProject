using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slower : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    AudioSource _audioSource;

    public AudioClip gotHit;

    private SpriteRenderer spriteRenderer;
    public Sprite newSprite;


    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
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
            _audioSource.PlayOneShot(gotHit);
            PublicVars.speed = PublicVars.speed/2;
            other.GetComponent<PlayerCombat>().takeHit();

            gameObject.GetComponent<Animator>().enabled = false;
            _rigidbody.gravityScale = 1;
            spriteRenderer.sprite = newSprite; 

        }
    }
}
