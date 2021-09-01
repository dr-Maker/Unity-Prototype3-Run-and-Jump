using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 0;
    public float tranlateSpeed = 0;

    private PlayerController _playerController;

    private void Start()
    {
        _playerController = GameObject.Find("player").GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {

        if (!_playerController.GameOver)
        {
        this.transform.localPosition += Vector3.left * tranlateSpeed * Time.deltaTime;
        this.transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }

    }
}
