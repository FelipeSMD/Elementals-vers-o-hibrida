using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testeLuminosidade : MonoBehaviour
{
    public Button ativador;
    public Button lumsBt;
    public Button wind;
    public Button menu;
    LightSensorPluginScript test;
    public GameObject painel;
    public float lums;
    public Text textoLuminosidade;
    public float valorDesejado = 0;
    private float valorDesejadoMin = 0;
    private float valorDesejadoMax = 0;
    public RectTransform painelRange;
    public RectTransform painelUser;
    public float limite = 0;
    public float minimo = 0;
    public bool aumentaLums = true;
    // Start is called before the first frame update
    void Start()
    {
        test = GetComponent<LightSensorPluginScript>();
        Button btnAtivador = ativador.GetComponent<Button>();
        btnAtivador.onClick.AddListener(accOnClick);

    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            lums = test.getLux();
            //textoLuminosidade.text = lums.ToString();
        }
        catch 
        {
            Debug.Log("Sem Sensor de Luminosidade");
        }

       //textoLuminosidade.text = lums.ToString();
        
        painelUser.anchoredPosition = new Vector3(Mathf.Clamp(lums, 0, 900), 0, 0);
    }

    void accOnClick()
    {
        painel.SetActive(true);
        ativador.image.enabled = false;
        lumsBt.gameObject.SetActive(false);
        wind.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
        valorDesejado = Random.Range(minimo, limite);
        valorDesejadoMin = valorDesejado - 20;
        valorDesejadoMax = valorDesejado + 120;
        painelRange.anchoredPosition = new Vector3(Mathf.Clamp(valorDesejado, minimo, limite), 0, 0);
        StartCoroutine(WaitAndPrint(10.0f));
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {


            yield return new WaitForSecondsRealtime(waitTime);
            painel.SetActive(false);
            
            if (lums >= valorDesejadoMin && lums <= valorDesejadoMax)
            {
                textoLuminosidade.text = "Sucesso";
                if (aumentaLums)
                {
                    varGlobais.luminosidadeAtual = "Claro";
            }
                else
                {
                    varGlobais.luminosidadeAtual = "Escuro";
                }    
            }
            else
            {
                textoLuminosidade.text = "falha";
            }
             
        
    }
}
