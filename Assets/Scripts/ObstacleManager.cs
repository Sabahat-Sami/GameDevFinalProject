using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject walls;

    private int numOfObstacles = 1;
    private int obstacleChooser;

    private bool canGenerate = true;
    private float spawnTime = 4f;



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(canGenerate){
            canGenerate = false;
            StartCoroutine(GenerateObstacle());

        }
    }

    IEnumerator GenerateObstacle()
    {
        obstacleChooser = Random.Range(1,numOfObstacles+1);
        switch (obstacleChooser)
        {
            //Wall Gen
            case 1:
                genWall();
                break;
        }

        yield return new WaitForSeconds(spawnTime);
        canGenerate = true;
    }

    void genWall()
    {
        Vector2 location = new Vector2(transform.position.x, Random.Range(-2f, 5f));
        print(location);
        GameObject wall = Instantiate(walls, location, Quaternion.identity);
    }
}


