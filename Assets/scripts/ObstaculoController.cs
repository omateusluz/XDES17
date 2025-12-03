using UnityEngine;

public class ObstaculoController : MonoBehaviour
{
    private Rigidbody2D ObstaculoRB;

    private GameController _GameController;
    private CameraShaker _CameraShaker;

    void Start()
    {
        ObstaculoRB = GetComponent<Rigidbody2D>();

        _GameController = Object.FindFirstObjectByType<GameController>();

        _CameraShaker = Object.FindFirstObjectByType<CameraShaker>() as CameraShaker;
    }

    void FixedUpdate()
    {
        MoveObjeto();
    }

    void MoveObjeto()
    {
        // Verifica se o GameController existe para evitar erros se a cena mudar rápido
        if (_GameController != null) 
        {
            transform.Translate(Vector2.left * _GameController._obstaculoVelocidade * Time.fixedDeltaTime); // Usei fixedDeltaTime pois está no FixedUpdate
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _CameraShaker != null)
        {
            _GameController._vidasPlayer--;
            
            if (_GameController._vidasPlayer <= 0)
            {
                // Atualiza o texto para 0 antes de sair
                _GameController._txtVidas.text = "0";
                
                // CHAMA O GAME OVER
                _GameController.GameOver();
            }
            else 
            { 
                _GameController._txtVidas.text = _GameController._vidasPlayer.ToString();
                _CameraShaker.ShakeIt();
                _GameController._fxGame.PlayOneShot(_GameController._fxDano);
                
                // Destroi o obstáculo para não bater duas vezes seguidas
                Destroy(this.gameObject); 
            }
                
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}