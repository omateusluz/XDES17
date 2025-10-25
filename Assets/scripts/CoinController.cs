using UnityEngine;

public class CoinController : MonoBehaviour
{

    private GameController _gameController;

    private const int Y = 0;
    private Rigidbody2D _moedasRB2D;

    // Você pode definir a velocidade desejada aqui no inspetor
    [SerializeField] private float velocidadeInicialX = -6f;


    void Start()
    {

        _gameController = FindFirstObjectByType<GameController>();

        _moedasRB2D = GetComponent<Rigidbody2D>();
        _moedasRB2D.AddForce(new Vector2(velocidadeInicialX, Y), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _gameController.Pontos(1);
            _gameController._fxGame.PlayOneShot(_gameController._fxMoedaColetada);
            Debug.Log("Pegou a moeda!");
            Destroy(this.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
        Debug.Log("Moeda foi destruída!");
    }
}