using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    public Vector3 startPos;
   // private float positionXOffset = 56.5f; // The half of the bacground sprite +10 + 1.5
    private Vector3 size;
    private float repeatLength;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        size = GetComponent<BoxCollider>().size;
        Debug.Log(size);
        repeatLength = size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startPos.x - repeatLength)
        {
            transform.position = startPos;
        }
    }
}
