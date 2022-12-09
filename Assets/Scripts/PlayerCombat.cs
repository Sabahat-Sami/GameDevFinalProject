using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour
{
    public GameObject enemy;
    public bool recoveryTimerRunning = false;
    private IEnumerator recoveryTimer;
    public bool canHeal = false;

    private Vector2 endPos;
    private Vector2 midPos;
    private Vector2 startPos;
    private Vector2 currPos;

    private float lerpTime = .5f;
    private float currTime;
        
    private SpriteRenderer spriteRenderer;
    public Sprite newSprite;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        recoveryTimer = recoveryTime();
        startPos = enemy.transform.position;
        midPos = (enemy.transform.position + transform.position)/2;
        endPos = transform.position;
        currPos = startPos;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(recoveryTimerRunning == false && canHeal == false){
            recoveryTimerRunning = true;
            StartCoroutine(recoveryTimer);
        }
        if(canHeal == true && currPos != startPos){
            canHeal = false;
            StartCoroutine(recover());
        }
    }

    public void takeHit()
    {
        if(currPos == startPos)
        {
            StartCoroutine(lerpEnemy(midPos));
        }
        else if(currPos == midPos)
        {
            StartCoroutine(lerpEnemy(endPos));
        }
    }

    IEnumerator lerpEnemy(Vector2 end)
    {
        //Cancel Healing
        StopCoroutine(recoveryTimer);
        recoveryTimer = recoveryTime();
        recoveryTimerRunning = false;
        canHeal = false;

        //Lerp
        currTime = 0;
        float percentageDone = currTime/lerpTime;
        while(percentageDone < 1f)
        {
            enemy.transform.position = Vector2.Lerp(currPos, end, percentageDone);
            currTime += Time.deltaTime;
            percentageDone = currTime/lerpTime;
            yield return null;
        }
        currPos = end;
    }


    IEnumerator recover()
    {
        //Lerp
        currTime = 0;
        float percentageDone = currTime/lerpTime;
        while(percentageDone < 1f)
        {
            enemy.transform.position = Vector2.Lerp(currPos, startPos, percentageDone);
            currTime += Time.deltaTime;
            percentageDone = currTime/lerpTime;
            yield return null;
        }
        currPos = startPos;
        canHeal = true;
    }

    IEnumerator recoveryTime(){
        yield return new WaitForSeconds(7f);
        canHeal = true;
    }

    public IEnumerator Death()
    {
        gameObject.GetComponent<Animator>().enabled = false;
        spriteRenderer.sprite = newSprite; 
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene("PlayAgain");
    }
}
