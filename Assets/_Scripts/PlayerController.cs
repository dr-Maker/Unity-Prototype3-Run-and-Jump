using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;


    public float jumpForce;
    public float gravityMultiplier;
    public bool isOnGround = true;
    private bool _gameOver;
    public bool GameOver{get => _gameOver;}

    private float speedCounter;
    private const string SPEED_MULTIPLIER ="Speed multiplier";
    private const string JUMP_TRIGGER = "Jump_trig";
    private const string DEATH_B = "Death_b";
    private const string DEATH_TYPE_INT = "DeathType_int";


    private Animator _animator;


    public ParticleSystem trail;
    public ParticleSystem explosion;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    private AudioSource _audioSource;

    [Range(0,1)]
    public float audioVolume = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity = gravityMultiplier * new Vector3(0, -9.81f, 0);
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        speedCounter += Time.deltaTime / 10;
        _animator.SetFloat(SPEED_MULTIPLIER, 1+ speedCounter);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !GameOver)
        {
            /*
             * ForcMode
             * -Aceleration // Fuerza continua acelerara tan fuerte sin importar la masa sera igual  un camion que una canica
             * -Force // Fuerza continua considera la masa
             * -Impulse // Fuerza instantanea usando la masa
             * -VelocityChange // Fuerza instantanea no considera la masa
             * 
             */
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            _animator.SetTrigger(JUMP_TRIGGER);
            trail.Stop();

            _audioSource.PlayOneShot(jumpSound, audioVolume);
        }
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            if (!GameOver)
            { 
            trail.Play();
            isOnGround = true;
            }
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            _gameOver = true;
            _animator.SetBool(DEATH_B, true);
            _animator.SetInteger(DEATH_TYPE_INT, Random.Range(1,3));
            explosion.Play();
            trail.Stop();
            _audioSource.PlayOneShot(crashSound, audioVolume);
           
            Invoke("ReStartGame", 2.5f);
        }

    }

    void ReStartGame()
    {
        speedCounter = 1;
        //SceneManager.UnloadSceneAsync("Prototype 3");
        SceneManager.LoadSceneAsync("Prototype 3", LoadSceneMode.Single);
    }
}
