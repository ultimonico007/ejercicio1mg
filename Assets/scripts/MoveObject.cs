using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveObject : MonoBehaviour
{
    public float speed;
    public float jumpsforce;
    public Vector2 inputVector;
    public Rigidbody rigidBody;
    public Vector3 velocity;
    public float velocitymagnitude;
    public bool CanJump;
    public int points;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        CanJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        rigidBody.AddForce(inputVector.x * speed, 0f, inputVector.y * speed, ForceMode.Impulse);

        velocity = rigidBody.velocity;
        velocitymagnitude = velocity.magnitude;
        if (Input.GetKeyDown(KeyCode.Space) && CanJump)
        {
            rigidBody.AddForce(0f, jumpsforce, 0f, ForceMode.Impulse);
            CanJump = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "piso")
        {
            CanJump = true;
        }
        if (collision.gameObject.CompareTag("dead"))
        {
            Debug.Log("killplayer");
            SceneManager.LoadScene("DEATH");
        }
        if (collision.gameObject.CompareTag("win"))
        {
            SceneManager.LoadScene(1);
        }
        if (collision.gameObject.CompareTag("items"))
        {
            Destroy(collision.gameObject);
            points++;
            scoretext.text = points.ToString();
        }
    }
    public TMPro.TextMeshProUGUI scoretext;
}
