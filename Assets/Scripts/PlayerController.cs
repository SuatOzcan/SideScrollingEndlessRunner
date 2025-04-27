using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isOnGround = true;
    public bool isGameOver = false;
    // public float gravityModifier;
    private Rigidbody PlayersRigidbody { get; set; }
    private Animator _playerAnimator;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public Vector3 force = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        PlayersRigidbody = GetComponent<Rigidbody>();
        _playerAnimator = GetComponent<Animator>();
       // Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver)
        {
            PlayersRigidbody.AddForce(force, ForceMode.Impulse);
            _playerAnimator.SetTrigger("Jump_trig");
           // _playerAnimator.ResetTrigger("Jump_trig");
            isOnGround = false;
            dirtParticle.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
           // _playerAnimator.ResetTrigger("Jump_trig");
            isOnGround = true;
            if (!isGameOver)
            {
                dirtParticle.Play();
            }
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            explosionParticle.Play(true);
            Debug.Log("Game over!");
            isGameOver = true;
            _playerAnimator.SetBool("Death_b", true);
            _playerAnimator.SetInteger("DeathType_int", 1);
            dirtParticle.Stop();
        }
    }
}
