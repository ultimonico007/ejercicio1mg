using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rigidbodymov : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float jumpsforce;
    public Vector2 inputVector;
    public Rigidbody rigidBody;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");
        rigidBody.AddForce(inputVector.x * speed,0f,inputVector.y * speed,ForceMode.Impulse);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(0f, jumpsforce, 0f,ForceMode.Impulse);
        }
    }
}
