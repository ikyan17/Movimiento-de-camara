using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : Character
{
    [SerializeField] private TextMeshProUGUI monedasText;
    [SerializeField] private TextMeshProUGUI vidas;
    

    private int monedasColectadas;



    void OnTriggerEnter(Collider collider)
    {
        if (monedasColectadas >= 10)
        {
            SceneManager.LoadScene("You win");
        }

       
        if (collider.gameObject.CompareTag("Moneda"))

        {
            monedasColectadas++; //= que sumar +1
         
            AcualizarTexto();
            Destroy(collider.gameObject);
        }
    }

    void AcualizarTexto()
    {
        
        monedasText.text = "Monedas: " + monedasColectadas;

    }

    void Start()
    {
        vidas.text += 10;
    }

    
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
    public void OnJump(InputValue inputValue)

    {
        inputJump = inputValue.Get<Vector2>();
    }
    

}
