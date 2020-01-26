using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public float speed = 15f;
    private Rigidbody2D body2D;
    public bool moving { get; private set; } = true;
    private bool isAllowToJump;

    // Start is called before the first frame update
    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!moving)
        {
            return;
        }

        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = 0;

        if (isAllowToJump)
        {
            verticalMove = Input.GetAxis("Vertical");
        }

        Vector2 movementInput = new Vector2(horizontalMove, verticalMove) * Time.deltaTime * speed;

        body2D.MovePosition(body2D.position + movementInput);
        //body2D.velocity = new Vector2(speed * value, body2D.velocity.y);
    }
    public void EnableMovemnt()
    {
        moving = true;
        Debug.Log("Enabled the movement of the player");
    }

    public void SetMoving(bool value)
    {
        moving = value;
        

        if (!value)
        {
            body2D.velocity = Vector2.zero;
        }
    }
}
