using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Player : MonoBehaviour
{
    [Header ("Player Stats")]
    [Tooltip("Controla la velocidad de movimiento del personaje")]
    [SerializeField]private float _playerSpeed = 5;
    [Tooltip ("Controla la fuerza de salto del personaje")]
    [SerializeField]private float _jumpForce = 5;
    //[SerializeField]private float _playerSpeedVertical = 5;
    private float _playerInputHorizontal;
    private float _playerInputVertical;

    private Rigidbody2D _rBody2D;
    private Animator _animator;
    private PlayableDirector _director;
    private SpriteRenderer _renderer;

    // Start is called before the first frame update

    void Start()
    {
        _rBody2D = GetComponent<Rigidbody2D>();
        //_sensor = GetComponentInChildren<GroundSensor>();
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       PlayerMovement(); 

       if(Input.GetButtonDown("Jump") && GroundSensor._isGrounded)
       {
        Jump();
       }

       if(Input.GetButtonDown("Fire2"))
       {
        _director.Play();
       }
    }

    void Jump()
    {
        _rBody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        _animator.SetBool("IsJumping", true);
    }

    void FixedUpdate() 
    {
        //_rBody2D.AddForce(new Vector2(_playerInputHorizontal * _playerSpeed, 0), ForceMode2D.Impulse);   
        _rBody2D.velocity = new Vector2(_playerInputHorizontal * _playerSpeed, _rBody2D.velocity.y);
    }

    void PlayerMovement()
    {
        _playerInputHorizontal = Input.GetAxis ("Horizontal");

        if(_playerInputHorizontal < 0)
        {
          //  _renderer.flipX = true;
          transform.rotation = Quaternion.Euler(0, 180, 0);
          _animator.SetBool("IsRunning", true);
        }
        else if(_playerInputHorizontal > 0)
        {
           // _renderer.flipX = false;
           transform.rotation = Quaternion.Euler(0, 0, 0);
            _animator.SetBool("IsRunning", true);
        }

        else
        {
            _animator.SetBool("IsRunning", true);
        }


        }
        /*_playerInputVertical = Input.GetAxis ("Vertical");
        transform.Translate(new Vector2(_playerInputHorizontal, _playerInputVertical) * _playerSpeed * Time.deltaTime);*/

       public void SignalTest()
        {
            Debug.Log("Señal recibida");
        }
    }
