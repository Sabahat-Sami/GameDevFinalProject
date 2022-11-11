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
        print("hit");
        print(enemy.transform.position);
        enemy.transform.position = Vector2.Lerp(enemy.transform.position, new Vector2(transform.position.x, -2.429525f), 0.5f);
        print(enemy.transform.position);
    }
}
