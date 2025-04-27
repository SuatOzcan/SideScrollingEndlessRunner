using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float moveSpeed = 15.0f;
    private float _leftBoundary = -10.0f;
    private string _player = "Player";
    private PlayerController _playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
           _playerControllerScript = GameObject.Find(_player).GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerControllerScript != null && _playerControllerScript.isGameOver == false)
            this.transform.Translate(moveSpeed * Time.deltaTime * Vector3.left);

        if(transform.position.x < _leftBoundary && gameObject.CompareTag( "Obstacle"))
            Destroy(gameObject);
    }
}
