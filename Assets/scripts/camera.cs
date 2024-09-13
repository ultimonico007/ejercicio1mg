using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    // Start is called before the first frame update

    Vector2 mouselook;
    Vector2 smoothV;

    public float sensibility = 5f;
    public float smooth = 2f;

    public GameObject Player;
    void Start()
    {
        Player = this.transform.parent.gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
