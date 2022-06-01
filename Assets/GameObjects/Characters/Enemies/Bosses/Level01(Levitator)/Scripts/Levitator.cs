using System;
using UnityEngine;

public class Levitator : MonoBehaviour
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
        if (transform.position.x > player.position.x && isFlipped)
        {
            Invoke(nameof(Flip1), 7f);
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            Invoke(nameof(Flip2),7f);
        }
    }
    void Flip1()
    {
        Vector3 flipped = transform.localScale;

        transform.localScale = flipped;
        transform.Rotate(0f, 180f, 0f);
        isFlipped = false;
    }
    void Flip2()
    {
        Vector3 flipped = transform.localScale;

        transform.localScale = flipped;
        transform.Rotate(0f, 180f, 0f);
        isFlipped = true;
    }
}
