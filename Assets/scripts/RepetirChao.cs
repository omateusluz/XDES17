using UnityEngine;

public class RepetirChao : MonoBehaviour
{
    private GameController _gameController;

    public bool _chaoinstanciado = false;

    //start is called before the first frame update
    void Start()
    {
       _gameController = FindFirstObjectByType<GameController>();

    }

    //update is called once per frame
    void Update()
    {
        if(_chaoinstanciado == false)
        {
            if(transform.position.x <=0)
            {
                _chaoinstanciado = true;
                GameObject objetoTemporarioChao = Instantiate(_gameController._chaoPrefab);
                objetoTemporarioChao.transform.position = new Vector3(transform.position.x + _gameController._chaoTamanho, transform.position.y, 0);

                Debug.Log("o chão foi instanciado!");
            }

            if(transform.position.x < _gameController._chaoDestruido)
            {
                Destroy(this.gameObject);
                Debug.Log("o chão foi destruido!");
            }
        }
    }

    private void FixedUpdate()
    {
        MoveChao();
    }

    void MoveChao()
    {
        transform.Translate(Vector2.left * _gameController._chaoVelocidade * Time.deltaTime);
    }
}
