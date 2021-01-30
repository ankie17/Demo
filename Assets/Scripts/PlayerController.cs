using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Direction
{
    Stay=0,
    Right,
    Left,
    Top,
    Down
}
public class PlayerController : MonoBehaviour
{

    public float MoveSpeed = 5.0f;
    private Direction moveDirection = Direction.Stay;
    private Transform transform;
    public float horizontalInput;
    public float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //получить инпут стрелки с клавиатуры
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (horizontalInput != 0)
        {
            verticalInput = 0;
        }
        //изменить направление движения
        if (horizontalInput == -1)
        {
            moveDirection = Direction.Left;
        }
        if(horizontalInput == 1)
        {
            moveDirection = Direction.Right;
        }
        if (verticalInput == -1)
        {
            moveDirection = Direction.Down;
        }
        if (verticalInput == 1)
        {
            moveDirection = Direction.Top;
        }
        //изменить координату объект, передвинув его на несколько условных единиц
        float moveDelta = MoveSpeed * Time.fixedDeltaTime;
        if (moveDirection == Direction.Left)
        {
            transform.position = new Vector3(transform.position.x - moveDelta, transform.position.y, 0);
        }
        if(moveDirection == Direction.Right)
        {
            transform.position = new Vector3(transform.position.x + moveDelta, transform.position.y, 0);
        }
        if (moveDirection == Direction.Top)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y + moveDelta, 0);
        }
        if(moveDirection == Direction.Down)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - moveDelta, 0);
        }
    }
}
