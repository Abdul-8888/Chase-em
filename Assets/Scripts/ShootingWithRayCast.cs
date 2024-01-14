using System;
using System.Collections;
using UnityEngine;

public class ShootingWithRayCast : MonoBehaviour
{
    public GameObject bullet;
    public AudioSource shootSound;
    private GameObject temp;

    public SwipeMovement player;

    public float speed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        // Create a ray from the object's position, pointing in a specific direction
        Ray ray = new Ray(transform.position, transform.up);

        RaycastHit hit;

        if (player.canContinue)
        {

            // Cast the ray and check if it hits an object
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.layer == 3)
                {
                    temp = (GameObject)Instantiate(bullet);
                    temp.transform.position = gameObject.transform.position;
                    temp.transform.rotation = gameObject.transform.rotation;
                    Rigidbody rb = temp.GetComponent<Rigidbody>();
                    rb.AddForce(ray.direction * speed, ForceMode.VelocityChange);
                    shootSound.Play();
                }
            }
        }
    }
}
