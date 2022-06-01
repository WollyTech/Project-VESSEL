using UnityEngine;
using System;

public class Tank : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = false;

    public void Start()
    {
        transform.Rotate(0f, 180f, 0f);
    }

    void Update()
    {
        try
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        catch (NullReferenceException)
        {
            Debug.Log("Couldn't find gameObject with tag ");
        }

    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;
        
        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
}
