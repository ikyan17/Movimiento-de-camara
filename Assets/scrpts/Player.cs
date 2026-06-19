using UnityEngine;
using UnityEngine.InputSystem;


public class Player : Character
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
    public void OnMove(InputValue inputValue)
    {
        inputMove = inputValue.Get<Vector2>();
    }
    public virtual void Move()
    {
        base.Mover();
    }


}
