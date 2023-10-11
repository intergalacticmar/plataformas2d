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
    }

    void FixedUpdate() 
    {
        //_rBody2D.AddForce(new Vector2(_playerInputHorizontal * _playerSpeed, 0), ForceMode2D.Impulse);   
        _rBody2D.velocity = new Vector2(_playerInputHorizontal * _playerSpeed, _rBody2D.velocity.y);
    }

    void PlayerMovement()
    {
        _playerInputHorizontal = Input.GetAxis ("Horizontal");

        if(_playerInputHorizontal != 0 )
        {
            _animator.SetBool("IsRunning", true);
        }

         if(_playerInputHorizontal == 0 )
        {
            _animator.SetBool("IsRunning", false);
        }
        /*_playerInputVertical = Input.GetAxis ("Vertical");
        transform.Translate(new Vector2(_playerInputHorizontal, _playerInputVertical) * _playerSpeed * Time.deltaTime);*/
    }
}
