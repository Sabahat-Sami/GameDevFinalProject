using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            PublicVars.speed = 0f;
            PublicVars.objectSpeed = 0f;
            StartCoroutine(other.gameObject.GetComponent<PlayerCombat>().Death());
        }
    }
}
