using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class feedback : MonoBehaviour
{
    public Text vidaP1;
    public Text vidaP2;
    public Text resultado;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vidaP1.text = varGlobais.p1Vida.ToString();
        vidaP2.text = varGlobais.p2Vida.ToString();

        if(varGlobais.p1Vida == 0)
        {
            resultado.text = "Player 1 wins !!";
        }
        if (varGlobais.p2Vida == 0)
        {
            resultado.text = "Player 2 wins !!";
        }
    }

   

}
