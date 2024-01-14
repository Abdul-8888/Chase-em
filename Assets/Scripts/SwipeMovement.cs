using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwipeMovement : MonoBehaviour
{
    Vector2 startTouchPosition;
    Vector2 endTouchPosition;
    Vector3 prevPosition;
    float charDistance;

    public bool canContinue = true;

    public GameObject can;

    public GameObject explosion;

    public int levelScore = 0;
    private int currentScore = 0;

    Vector3[] directions;

    public AudioSource deathSound;
    public AudioSource CollisionSound2;
    public AudioSource WinSound3;
    public AudioSource LoseSound4;

    float startTime;
    float timeDiff;
    float distance;
    float xDistance;
    float yDistance;
    float swipeSpeed;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        prevPosition = transform.position;
        directions = new Vector3[4];
        directions[0] = new Vector3(0, 0, -20); //up
        directions[1] = new Vector3(0, 0, 20); //down
        directions[2] = new Vector3(20, 0, 0); //left
        directions[3] = new Vector3(-20, 0, 0); //right
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,1,0) * 17);

        if (canContinue)
        {

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startTouchPosition = Input.GetTouch(0).position;
                startTime = Time.time;
            }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endTouchPosition = Input.GetTouch(0).position;

                timeDiff = Time.time - startTime;
                startTime = 0;

                distance = Vector2.Distance(startTouchPosition, endTouchPosition);
                if (timeDiff != 0)
                    swipeSpeed = distance / timeDiff;

                xDistance = Mathf.Abs(startTouchPosition.x - endTouchPosition.x);
                yDistance = Mathf.Abs(startTouchPosition.y - endTouchPosition.y);

                charDistance = Vector3.Distance(prevPosition, transform.position);

                if (charDistance < 0.1)
                {
                    if (swipeSpeed > 100)
                    {
                        if (endTouchPosition.x < startTouchPosition.x && xDistance > yDistance)
                        {
                            //Move Left
                            rb.AddForce(directions[2], ForceMode.VelocityChange);
                        }

                        else if (endTouchPosition.x > startTouchPosition.x && xDistance > yDistance)
                        {
                            //Move Right
                            rb.AddForce(directions[3], ForceMode.VelocityChange);
                        }

                        else if (endTouchPosition.y < startTouchPosition.y && xDistance < yDistance)
                        {
                            //Move Down
                            rb.AddForce(directions[1], ForceMode.VelocityChange);
                        }

                        else if (endTouchPosition.y > startTouchPosition.y && xDistance < yDistance)
                        {
                            //Move Up
                            rb.AddForce(directions[0], ForceMode.VelocityChange);
                        }
                    }
                }
            }

            prevPosition = transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (canContinue)
        {
            if (collision.gameObject.layer == 10 || collision.gameObject.layer == 8)
            {
                deathSound.Play();
                Destroy(Instantiate(explosion, transform.position, Quaternion.identity), 2.0f);
                Destroy(gameObject);
                LoseSound4.Play();
                can.SetActive(true);

                string buttonName = "btnNext";
                Button button = can.transform.Find(buttonName).GetComponent<Button>();
                button.gameObject.SetActive(false);
            }
            else if (collision.gameObject.layer == 7)
            {
                CollisionSound2.Play();
            }
            else if (collision.gameObject.layer == 9)
            {
                currentScore++;

                if (currentScore == levelScore)
                {
                    WinSound3.Play();
                    canContinue = false;
                    can.SetActive(true);
                }
            }
        }
    }
}
