using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testeAcelerometro : MonoBehaviour
{
    public Button ativador;
    public Button lumsUp;
    public Button lumsDown;
    public Button menu;
    public GameObject painel;
    public float aceleracao;
    public Text textoLuminosidade;
    public float valorDesejado = 0;
    private float valorDesejadoMin = 0;
    private float valorDesejadoMax = 0;
    public RectTransform painelRange;
    public RectTransform painelUser;

    // Start is called before the first frame update
    void Start()
    {
        Button btnAtivador = ativador.GetComponent<Button>();
        btnAtivador.onClick.AddListener(accOnClick);

    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            aceleracao += Input.acceleration.x;
        }
        catch
        {
            Debug.Log("Sem Sensor de Luminosidade");
        }

        //textoLuminosidade.text = aceleracao.ToString();

        painelUser.anchoredPosition = new Vector3(Mathf.Clamp(aceleracao, 0, 900), 0, 0);
    }

    void accOnClick()
    {
        painel.SetActive(true);
        ativador.image.enabled = false;
        lumsUp.gameObject.SetActive(false);
        lumsDown.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
        valorDesejado = Random.Range(0, 291);
        valorDesejadoMin = valorDesejado - 20;
        valorDesejadoMax = valorDesejado + 120;
        painelRange.anchoredPosition = new Vector3(Mathf.Clamp(valorDesejado, 0, 291), 0, 0);
        StartCoroutine(WaitAndPrint(10.0f));
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {

            yield return new WaitForSeconds(waitTime);
            painel.SetActive(false);
            
            if (aceleracao >= valorDesejadoMin && aceleracao <= valorDesejadoMax)
            {
                textoLuminosidade.text = "Sucesso";
                varGlobais.ventoAtual = "Forte";
            }
            else
            {
                textoLuminosidade.text = "falha";
            }

            aceleracao = 0;
        
    }
}
