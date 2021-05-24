using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota1AudioController : MonoBehaviour
{
    //This is an ARRAY
    AudioSource[] sources;
    Rigidbody rb;
    //velocidad de la pelota
    float speed = 0.0f;
    bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        sources = GetComponents<AudioSource>();
        rb = GetComponent<Rigidbody>();
        sources[1].pitch = 1.0f / rb.mass;
    }

    // Update is called once per frame
    void Update()
    {
        speed = rb.velocity.magnitude;
        if (speed > 0.1f && ! isPlaying)
        {
            isPlaying = true;
            sources[0].Play();
        }
        else if (speed < 0.1f )
        {
            isPlaying = false;
            sources[0].Stop();
        }

        sources[0].pitch = speed / rb.mass;

    }

    // métod llamada por Unity cuando chocamos con algo ...
    void OnCollisionEnter(Collision collision)
    {

        Rigidbody otherRb = collision.gameObject.GetComponent<Rigidbody>();
        if (otherRb)
        {
            if(otherRb.mass < rb.mass)
            {
                //acceder al segundo fuente
                sources[1].Play();
            }
            else
            {

            }
        }
        else
        {
            //acceder al segundo fuente
            sources[1].Play();
        }

    }

}
