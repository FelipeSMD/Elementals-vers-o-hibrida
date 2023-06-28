using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardStats : MonoBehaviour
{
    int atk;
    int life;
    public string element;
    public string type;
    public int iniAtk;
    public int iniDef;
    void Start()
    {
        iniAtk = this.GetComponent<cardAtk>().Atk;
        iniDef = this.GetComponent<cardAtk>().Def;
    }

    // Update is called once per frame
    void Update()
    {
        atk = this.GetComponent<cardAtk>().Atk;
        life = this.GetComponent<cardAtk>().Def;
        int auxAtk = 0;
        int auxLife = 0;
        GameObject keeper = GameObject.Find("testeTotalis");
        
        if (element == "Ar")
        {
            
            if (varGlobais.temperaturaAtual == "Frio")
            {
                auxAtk -= 100;
                auxLife -= 100;
            }
            if (varGlobais.temperaturaAtual == "Neutro")
            {
                auxLife += 0;
                auxAtk += 0;
            }
            if (varGlobais.temperaturaAtual == "Quente")
            {
                auxAtk += 100;
                auxLife += 100;
            }

            if (varGlobais.ventoAtual == "Neutro")
            {
                auxLife += 0;
                auxAtk += 0;
            }
            if (varGlobais.ventoAtual == "Forte")
            {
                auxAtk += 100;
                auxLife += 100;
            }
        }
        //if (type == "Terra")
        //{

        //}
        if (element == "Fogo")
        {
            if (keeper.GetComponent<waether>().tempStats <= 10)
            {
                auxLife -= 200;
            }
            if (keeper.GetComponent<waether>().tempStats > 10 && keeper.GetComponent<waether>().tempStats <= 20)
            {
                auxLife -= 100;
            }
            if (keeper.GetComponent<waether>().tempStats >= 30 && keeper.GetComponent<waether>().tempStats < 35)
            {

                auxAtk += 200;
            }
            if (keeper.GetComponent<waether>().tempStats >= 35)
            {
                auxAtk += 300;

            }

            if (varGlobais.luminosidadeAtual == "Claro")
            {
                auxAtk += 100;
            }
            if (varGlobais.luminosidadeAtual == "Escuro")
            {
                auxAtk -= 100;
            }
        }
        if (element == "Água")
        {
            if (keeper.GetComponent<waether>().tempStats <= 10)
            {
                auxLife += 200;
            }
            if (keeper.GetComponent<waether>().tempStats > 10 && keeper.GetComponent<waether>().tempStats <= 20)
            {
                auxLife += 100;
            }
            if (keeper.GetComponent<waether>().tempStats >= 30 && keeper.GetComponent<waether>().tempStats < 35)
            {

                auxAtk -= 200;
            }
            if (keeper.GetComponent<waether>().tempStats >= 35)
            {
                auxAtk -= 300;

            }
        }
        if (element == "Sombra")
        {
            // Comentei aqui porque tava como se a criatura fosse
            // bufada ou debufada duas vezes em seguida
            if (varGlobais.luminosidadeAtual == "Claro")
            {
                auxAtk -= 100;
                auxLife -= 100;
            }
            if (varGlobais.luminosidadeAtual == "Neutro")
            {
                auxLife += 0;
                auxAtk += 0;
            }
            if (varGlobais.luminosidadeAtual == "Escuro")
            {
                auxAtk += 100;
                auxLife += 100;
            }

        }
        if (element == "Luz")
        {
            // Mesma coisa aqui
            if (keeper.GetComponent<testSensor>().lums >= 1000)
            {
                auxAtk += 200;
                auxLife += 300;
            }
            if (keeper.GetComponent<testSensor>().lums >= 300 && keeper.GetComponent<testSensor>().lums < 1000)
            {
                auxAtk += 100;
                auxLife += 150;
            }
            if (keeper.GetComponent<testSensor>().lums < 300 && keeper.GetComponent<testSensor>().lums != 0)
            {
                auxAtk -= 100;
                auxLife -= 150;
            }
            if (keeper.GetComponent<testSensor>().lums == 0)
            {
                auxAtk -= 200;
                auxLife -= 300;
            }
        }

        auxAtk = atk + auxAtk;
        this.GetComponent<cardAtk>().modifyAtk = auxAtk;
        auxLife = life + auxLife;
        this.GetComponent<cardAtk>().modifyDef = auxLife;
        StatsBuff();

    }

    void StatsBuff() {
        if (iniAtk < this.GetComponent<cardAtk>().modifyAtk)
        {
            this.GetComponent<cardAtk>().atkTxt.color = Color.green;
        }
        else if (iniAtk > this.GetComponent<cardAtk>().modifyAtk)
        {
            this.GetComponent<cardAtk>().atkTxt.color = Color.red;
        }
        else
        {
            this.GetComponent<cardAtk>().atkTxt.color = Color.black;
        }

        if (iniDef < this.GetComponent<cardAtk>().modifyDef)
        {
            this.GetComponent<cardAtk>().defTxt.color = Color.green;
        }
        else if (iniDef > this.GetComponent<cardAtk>().modifyDef)
        {
            this.GetComponent<cardAtk>().defTxt.color = Color.red;
        }
        else
        {
            this.GetComponent<cardAtk>().defTxt.color = Color.black;
        }
    }
}

