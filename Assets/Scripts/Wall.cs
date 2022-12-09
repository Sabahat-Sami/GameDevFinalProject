using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Wall : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    AudioSource _audioSource;

    public AudioClip hitWall;

    private SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //_rigidbody.velocity = new Vector2(-PublicVars.speed * PublicVars.image_offset, 0);
        Vector2 newPos = transform.position;
        newPos.x -= PublicVars.objectSpeed;
        transform.position = newPos;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            _audioSource.PlayOneShot(hitWall);
            spriteRenderer.sprite = newSprite; 

            PublicVars.speed = 0f;
            PublicVars.objectSpeed = 0f;
            StartCoroutine(other.gameObject.GetComponent<PlayerCombat>().Death());
        }

        else if(other.tag == "Enemy")
        {
            _audioSource.PlayOneShot(hitWall);
            spriteRenderer.sprite = newSprite; 
        }
    }
}
