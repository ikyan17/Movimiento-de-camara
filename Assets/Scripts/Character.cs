using UnityEngine;

public class Character : MonoBehaviour


{
    [SerializeField] private float vel;
    protected Vector2 inputMove;
    protected Vector2 inputJump;

    private void Start()
    {

    }
    private void FixedUpdate()
    {

    }
    public void Mover()
    {
        Vector3 direction = new Vector3(inputMove.x, 0, inputMove.y);
        transform.Translate(direction * vel * Time.deltaTime);
    }

    


}