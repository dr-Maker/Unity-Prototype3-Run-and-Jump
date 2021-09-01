using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovment : MonoBehaviour
{

    public float speed;
    private PlayerController _playerController;
    private RepeteBackground _repeteBackground;


    private void Start()
    {
        _playerController = GameObject.Find("player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!_playerController.GameOver)
        {
            this.transform.Translate(Vector3.left * speed * Time.deltaTime);

        }



    }
}
