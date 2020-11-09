using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public GameObject moveCube;

    float playerSpeed = 10.0f;
    float jumpForce = 10.0f;
    float gravityModifier = 3.0f;

    bool isGrounded;
    bool onMoveCube;

    Rigidbody playerRB;
    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
        onMoveCube = false;

        Physics.gravity *= gravityModifier;
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * playerSpeed);

        /*
        if (onMoveCube == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, moveCube.transform.position.z);
        }

        if (onMoveCube == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * playerSpeed);
        }
        */
        PlayerJump();       
    }

    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MoveCube"))
        {
            isGrounded = true;
            onMoveCube = true;
        }
    }
}
        
