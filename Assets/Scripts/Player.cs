using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player : Character
{
    [SerializeField] private TextMeshProUGUI vidas;

    void Start()
    {
        vidas.text += 10;
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
