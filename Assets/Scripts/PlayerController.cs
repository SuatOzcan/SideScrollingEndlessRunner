using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isOnGround = true;
    public bool isGameOver = false;
    // public float gravityModifier;
    private Rigidbody PlayersRigidbody { get; set; }
    public Vector3 force = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        PlayersRigidbody = GetComponent<Rigidbody>();
       // Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            PlayersRigidbody.AddForce(force, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            isOnGround = true;
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game over!");
            isGameOver = true;
        }
    }
}
