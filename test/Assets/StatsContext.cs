using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsContext : MonoBehaviour
{
    public Text temperatura;
    public Text luminosidade;
    public Text vento;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        luminosidade.text = varGlobais.luminosidadeAtual;
        temperatura.text = varGlobais.temperaturaAtual;
        vento.text = varGlobais.ventoAtual;
    }
}
