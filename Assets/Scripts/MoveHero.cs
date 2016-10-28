using UnityEngine;
using System.Collections;

public class MoveHero : MonoBehaviour {
    public float speed = 6.0f;
    const string RIGHT = "Right";
    const string LEFT = "Left";
    const string UP = "Up";
    const string DOWN = "Down";
    string directionMoving = DOWN;
    string previousDirectionMoving = DOWN;
    Animator anim;
    bool flipped = false;
    Rigidbody2D rigidbody;

    void Start ()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        // Default to false so we idle if we're not holding down a direction.
        bool moving = false;
       
        if (moveX > 0)
        {
            moving = true;
            Debug.Log("Right");
            previousDirectionMoving = directionMoving;
            directionMoving = RIGHT;
        }
        else if (moveX < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            moving = true;
            Debug.Log("Left");
            previousDirectionMoving = directionMoving;
            directionMoving = LEFT;

        }
        else if (moveY > 0)
        {
            moving = true;
            Debug.Log("Up");
            previousDirectionMoving = directionMoving;
            directionMoving = UP;

        }
        else if (moveY < 0)
        {
            moving = true;
            Debug.Log("Down");
            previousDirectionMoving = directionMoving;
            directionMoving = DOWN;
        } 
        if (moving)
        {
            anim.speed = 1;
            rigidbody.MovePosition(new Vector2(moveX * speed * Time.deltaTime, moveY * speed * Time.deltaTime));
            //transform.Translate(new Vector2(moveX * speed * Time.deltaTime, moveY * speed * Time.deltaTime));

            if (directionMoving != previousDirectionMoving)
            {
                anim.SetTrigger(directionMoving);
            }
        } else
        {
            anim.speed = 0;
        }
    }
}