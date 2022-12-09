using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject walls;
    public GameObject slowers;
    public GameObject grounds;

    public GameObject scoreMultipliers;
    public GameObject timeSlowers;
    public GameObject doubleJumps;

    private int numOfGrounds;
    private int numOfObstacles = 2;
    private int numOfPowerups = 3;
    private int obstacleChooser;
    private int powerupChooser;
    private int powerupChance;

    private bool canGenerate = true;
    private float spawnTime;



    // Start is called before the first frame update
    void Start()
    {
        Random.InitState((int)(System.DateTime.Now.Ticks));
    }

    // Update is called once per frame
    void Update()
    {
        // print(PublicVars.speed);
        numOfGrounds = GameObject.FindGameObjectsWithTag("Ground").Length;
        if(numOfGrounds < 2){
            genGround();
        }
        spawnTime = .75f / PublicVars.speed;
        if(spawnTime > 4f)
        {
            spawnTime = 4f;
        }

        if(canGenerate){
            canGenerate = false;
            StartCoroutine(GenerateObstacle());

        }
    }

    IEnumerator GenerateObstacle()
    {
        powerupChance = Random.Range(1, 6);

        if(powerupChance == 1)
        {
            powerupChooser = Random.Range(1,numOfPowerups+1);
            switch (powerupChooser)
            {
                //Score Multiplier Gen
                case 1:
                    genScoreMultiplier();
                    break;
                //Time slower powerup
                case 2:
                    genTimeSlower();
                    break;
                case 3:
                    genDoubleJump();
                    break;
            }
        }

        else
        {
            obstacleChooser = Random.Range(1,numOfObstacles+1);
            switch (obstacleChooser)
            {
                //Wall Gen
                case 1:
                    genSlower();
                    break;
                //Wall Gen
                case 2:
                    genWall();
                    break;
            }
        }


        yield return new WaitForSeconds(spawnTime);
        canGenerate = true;
    }

    void genSlower()
    {
        Vector2 location = new Vector2(transform.position.x, Random.Range(-1f, 2.5f));
        GameObject slower = Instantiate(slowers, location, Quaternion.identity);
    }

    void genWall()
    {
        //Max height 2.5
        //Min height 1
        //Wall default size = 1.5
        Vector2 location = new Vector2(transform.position.x, -2.2f);
        GameObject wall = Instantiate(walls, location, Quaternion.identity);
        float newSize = Random.Range(1f, 2.51f);
        wall.transform.localScale = new Vector2(wall.transform.localScale.x, newSize);
        wall.transform.position = new Vector2(wall.transform.position.x, location.y + (newSize - 1.7f)/2f);
    }

    void genGround()
    {
        Vector2 location = new Vector2(transform.position.x - Random.Range(5f, 6f), -3.176f);
        GameObject ground = Instantiate(grounds, location, Quaternion.identity);
    }

    void genTimeSlower()
    {
        Vector2 location = new Vector2(transform.position.x, 0f);
        GameObject timeSlower = Instantiate(timeSlowers, location, Quaternion.identity);
    }

    void genScoreMultiplier()
    {
        Vector2 location = new Vector2(transform.position.x, 0f);
        GameObject scoreMultiplier =  Instantiate(scoreMultipliers, location, Quaternion.identity);
    }

    void genDoubleJump()
    {
        Vector2 location = new Vector2(transform.position.x, 0f);
        GameObject doubleJump =  Instantiate(doubleJumps, location, Quaternion.identity);
    }
}


