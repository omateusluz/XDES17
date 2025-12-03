using UnityEngine;
using TMPro; // 1. BIBLIOTECA NECESSÁRIA PARA O TEXT MESH PRO

public class MostraPontuacaoFinal : MonoBehaviour
{
    [Header("Arraste os Textos aqui")]
    // 2. Mudei de 'Text' para 'TMP_Text' para aceitar o texto novo
    public TMP_Text txtPontuacaoFinal; 
    public TMP_Text txtRecorde;        

    void Start()
    {
        int ultimaPontuacao = PlayerPrefs.GetInt("UltimaPontuacao", 0);
        int recorde = PlayerPrefs.GetInt("Recorde", 0);

        if (txtPontuacaoFinal != null)
        {
            txtPontuacaoFinal.text = "Distância: " + ultimaPontuacao.ToString() + " m";
        }

        if (txtRecorde != null)
        {
            txtRecorde.text = "Recorde: " + recorde.ToString() + " m";
        }
    }
}