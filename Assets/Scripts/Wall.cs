using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Wall : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    AudioSource _audioSource;

    public AudioClip hitWall;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        //_rigidbody = GetComponent<Rigidbody2D>();
        //_rigidbody.velocity = new Vector2(-PublicVars.speed * PublicVars.image_offset, 0);
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
            PublicVars.speed = 0f;
            PublicVars.objectSpeed = 0f;
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene("PlayAgain");
    }
}
