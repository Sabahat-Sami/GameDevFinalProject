using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject enemy;
    public bool canHeal = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeHit(){
        enemy.transform.position = Vector2.Lerp(enemy.transform.position, transform.position/2, Time.deltaTime);
    }
}
