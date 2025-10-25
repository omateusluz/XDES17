using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //propriedades do chao
    [Header("Configuração do Chão")]
    public float        _chaoDestruido;
    public float        _chaoTamanho;
    public float        _chaoVelocidade;
    public GameObject   _chaoPrefab;

    [Header("Configuração do Obstáculo")]
    public float        _obstaculoTempo;
    public GameObject   _obstaculoPrefab;
    public float        _obstaculoVelocidade;

    [Header("Configuração do coin - Moeda")]
    public float        _coinTempo;
    public GameObject   _coinPrefab;

    [Header("Configuração UI")]
    public int          _pontosPlayer;
    public Text         _txtPontos;
    public int          _vidasPlayer;
    public Text         _txtVidas;
    public Text         _txtMetros;

    [Header("Configuração de Distância")]
    public int          _metrosPercorridos = 0;

    [Header("Sons e Efeitos")]
    public AudioSource  _fxGame;
    public AudioClip    _fxMoedaColetada;
    public AudioClip    _fxJump;
    public AudioClip    _fxDano;

    void Start()
    {
        StartCoroutine(SpawnObstaculo());
        StartCoroutine(SpawnCoin());
        InvokeRepeating("DistanciaPercorrida", 0f, 0.2f);

    }

    IEnumerator SpawnObstaculo()
    {
        yield return new WaitForSeconds(_obstaculoTempo);

        GameObject objetoObstaculoTemp = Instantiate(_obstaculoPrefab);
        StartCoroutine(SpawnObstaculo());

        yield return new WaitForSeconds(1.5f);

        StartCoroutine(SpawnCoin());
    }

    IEnumerator SpawnCoin()
    {
        int moedasleatorias = Random.Range(1, 5);
        for (int contagem = 1; contagem <= moedasleatorias; contagem++)
        {
            yield return new WaitForSeconds(_coinTempo);
            GameObject _objetoSpawn = Instantiate(_coinPrefab);
            _objetoSpawn.transform.position = new Vector3(_objetoSpawn.transform.position.x, _objetoSpawn.transform.position.y, 0);
        }
    }

    public void Pontos (int _qtdPontos)
    {
        _pontosPlayer += _qtdPontos;
        _txtPontos.text = _pontosPlayer.ToString();
    }

    void DistanciaPercorrida()
    {
        _metrosPercorridos++;
        _txtMetros.text = _metrosPercorridos.ToString() + " m";
    }

}
