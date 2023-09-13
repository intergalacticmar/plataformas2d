using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float _playerSpeed = 5;
    private float _playerInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _playerInput = Input.GetAxis ("Horizontal");

        transform.Translate(new Vector2(_playerInput, 0) * _playerSpeed * Time.deltaTime);
    }
}
