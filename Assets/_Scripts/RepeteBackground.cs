using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class RepeteBackground : MonoBehaviour
{

    private Vector3 startPost;
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        startPost = this.transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;


    }

    // Update is called once per frame
    void Update()
    {
        if (startPost.x - this.transform.position.x > repeatWidth)
        {
            this.transform.position = startPost;
        } 
        
    }
}
