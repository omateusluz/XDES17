using UnityEngine;
using System.Collections;

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

    void Start()
    {
        StartCoroutine(SpawObstaculo());
    }

    IEnumerator SpawObstaculo()
    {
        yield return new WaitForSeconds(_obstaculoTempo);

        GameObject objetoObstaculoTemp = Instantiate(_obstaculoPrefab);
        StartCoroutine(SpawObstaculo());
    }
}
