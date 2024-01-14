//using System;
using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
    Rigidbody rb;
    public float force = 2f;
    public AudioSource squashSound;
    private float groundPosition;

    private void Awake()
    {
        groundPosition = transform.position.y;
    }

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float charDistance = Mathf.Abs(groundPosition - transform.position.y);

        if (charDistance <= 0.1)
        {
            rb.AddForce(new Vector3(0, 1, 0) * force, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            squashSound.Play();
            Destroy(gameObject);
        }

    }
}
