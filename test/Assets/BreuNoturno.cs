using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreuNoturno : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (varGlobais.luminosidadeAtual == "Claro")
        {
            varGlobais.luminosidadeAtual = "Neutro";
        }
        else
        {
            varGlobais.luminosidadeAtual = "Escuro";
        }
        this.GetComponent<Image>().CrossFadeAlpha(0, 1f, false);
        StartCoroutine(Wait(1f));
    }
    private IEnumerator Wait(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
