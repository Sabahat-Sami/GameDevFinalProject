using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    Renderer _renderer;
    Rigidbody _rigidbody;
    float curr_time;
    public Material _mat;

    //public float speed = .1f;
    void Start()
    {
        //_renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {   
        if(PublicVars.speed < 0.75f && PublicVars.speed !=0f)
        {
            PublicVars.speed = PublicVars.speed + PublicVars.accel;
            PublicVars.objectSpeed = PublicVars.speed * PublicVars.image_offset * Time.deltaTime;
        }
        //_renderer.material.mainTextureOffset += new Vector2(1, 0) * PublicVars.speed * Time.deltaTime;
        
        _mat.mainTextureOffset += new Vector2(1, 0) * PublicVars.speed * Time.deltaTime;
    }
}
