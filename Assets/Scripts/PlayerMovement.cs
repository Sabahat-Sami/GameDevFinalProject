using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D _rigidbody;

    Vector2 firstTouch;
    Vector2 lastTouch;
    Vector2 swipe;
    private float swipe_length = 70f;
    float jumpForce = 400f;

    public Transform feetTrans;
    public LayerMask groundLayer;
    bool grounded;
    int airjumps = 0;
    public TextMeshProUGUI currScoreText;

    AudioSource _audioSource;

    public AudioClip jumpSound;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _rigidbody = GetComponent<Rigidbody2D>();
        PublicVars.speed = .1f;
        PublicVars.objectSpeed = 0f;
        PublicVars.canAccel = true;
        PublicVars.accel = .0002f;
        PublicVars.image_offset = 21.62746f;
        PublicVars.maxScore = 0;
        PublicVars.scoreAdder = 1;
        PublicVars.maxAirJumps = 0;
        PublicVars.currScore = 0;

    }

    void Update()
    {
        grounded = Physics2D.OverlapCircle(feetTrans.position, .2f, groundLayer);

        if(Input.touchCount == 1){
            Touch touch = Input.GetTouch(0);

            //Single touch
            if(touch.phase == TouchPhase.Began)
            {
                firstTouch = new Vector2(touch.position.x, touch.position.y);
            }
            if(touch.phase == TouchPhase.Ended)
            {
                lastTouch = new Vector2(touch.position.x, touch.position.y);
                swipe = new Vector2(lastTouch.x - firstTouch.x, lastTouch.y - firstTouch.y);
                if(swipe.magnitude < swipe_length){
                    //Touch
                    if(grounded)
                    {
                        airjumps = PublicVars.maxAirJumps;
                        Jump();
                    }
                    else if(airjumps > 0)
                    {
                        airjumps--;
                        Jump();
                    }
                }
                else if(swipe.y <0)
                {
                    //Swipe down
                    Down();
                }
            }
        }
        StartCoroutine(AddScore());
        currScoreText.text = "Score: " + PublicVars.currScore;
        //print(score);
    }

    IEnumerator AddScore() 
    {
        if(PublicVars.speed != 0){
            PublicVars.currScore += PublicVars.scoreAdder;
        }
        else {
            if(PublicVars.currScore > PublicVars.maxScore){
                PublicVars.maxScore = PublicVars.currScore;
            }
        }
        yield return new WaitForSeconds(2f);
    }
    void Jump()
    {
        _audioSource.PlayOneShot(jumpSound);
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        _rigidbody.AddForce(new Vector2(0, jumpForce));

    }
    void Down()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        _rigidbody.AddForce(new Vector2(0,-800f));
    }

    public void increaseJump()
    {
        airjumps++;
    }

    private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(feetTrans.position, .2f);
        }

}

    
