using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class menuButton : MonoBehaviour
{
    public Button ativador;
    public Button lumsUp;
    public Button lumsDown;
    public Button windUp;
    private bool firstClick = true;

    // Start is called before the first frame update
    void Start()
    {
        Button btnAtivador = ativador.GetComponent<Button>();
        btnAtivador.onClick.AddListener(AccOnClick);
        firstClick = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        firstClick = true;
    }

    void AccOnClick()
    {
        if (firstClick)
        {
            Debug.Log("abriu");
            lumsUp.gameObject.SetActive(true);
            lumsDown.gameObject.SetActive(true) ;
            windUp.gameObject.SetActive(true) ;
            lumsUp.image.enabled = true;
            lumsDown.image.enabled = true;
            windUp.image.enabled = true;
            firstClick = false;
        }
        else
        {
            Debug.Log("fechou");
            lumsUp.gameObject.SetActive(false) ;
            lumsDown.gameObject.SetActive(false) ;
            windUp.gameObject.SetActive(false);
            firstClick = true;
        }
        
    }
}
