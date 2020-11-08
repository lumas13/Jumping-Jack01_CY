using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    float speed = 1.0f;
    float zLimit = 27.5f;
    bool isFoward = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < zLimit && isFoward) // == true
        {
            Foward();
        }
        else if (transform.position.z > 1 && !isFoward) // == false
        {
            Backward();
        }
        else
        {
            isFoward = !isFoward;
        }
    }

    private void Foward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void Backward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * -speed);
    }
}
