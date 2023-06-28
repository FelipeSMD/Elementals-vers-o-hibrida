using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EscudoDeVento : MonoBehaviour
{
    Color teste = new Color(255, 255, 255, 0);
    // Start is called before the first frame update
    void Start()
    {
        varGlobais.buffLiberado = true;
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
