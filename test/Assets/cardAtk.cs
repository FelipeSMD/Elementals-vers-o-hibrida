using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cardAtk : MonoBehaviour
{
    // Start is called before the first frame update
    public int Atk;
    public int Def;
    public int modifyAtk;
    public int modifyDef;
    public string playerOwner;
    public Button atkBTn;
   

    public GameObject amplifyAtk;
    public GameObject highlight;
    public GameObject nauseated;
    private bool isFirstClick = true;
    private bool isSecondClick = false;
    public bool isAtacked = false;
    public bool accOn = false;

    public float aux = 0;
    private string m_MyVar = varGlobais.playerTurn;
    public AudioSource alert;

    public delegate void OnVariableChangeDelegate(string newVal);
    public event OnVariableChangeDelegate OnVariableChange;

    public bool isNauseated = true;

    public Text atkTxt;
    public Text defTxt;

    public GameObject[] slots;
    public bool noCanGoFace = false;

    void Start()
    {

        Button btn = atkBTn.GetComponent<Button>();
        btn.onClick.AddListener(atkClick);
     

        if (playerOwner == "P2")
        {
            GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
            this.transform.rotation = new Quaternion(0, 0, -180, 0);
        }

        this.OnVariableChange += VariableChangeHandler;

        modifyAtk = Atk;
        modifyDef = Def;
    }

    private void Update()
    {
        
        atkTxt.text = modifyAtk.ToString();
        defTxt.text = modifyDef.ToString();



        if (varGlobais.playerTurn != m_MyVar && OnVariableChange != null)
        {
            m_MyVar = varGlobais.playerTurn;
            OnVariableChange(varGlobais.playerTurn);
        }

        if (isNauseated)
        {
            nauseated.SetActive(true);
        }
        else
        {
            nauseated.SetActive(false);
        }

        if (accOn)
        {
            aux += Input.accelerationEventCount;

            if (aux <= 100)
            {
                alert.volume = 0.4f;
                alert.pitch = 1.1f;
                
            }
            else if ((aux > 100) && aux <= 300)
            {
                alert.volume = 0.5f;
                alert.pitch = 1.2f;
            }
            else if ((aux > 300) && aux <= 500)
            {
                alert.volume = 0.6f;
                alert.pitch = 1.3f;
            }
            else if ((aux > 500) && aux <= 700)
            {
                alert.volume = 0.7f;
                alert.pitch = 1.4f;
            }else if (aux > 700)
            {
                isNauseated = true;
                varGlobais.atkLackey = 0;
                varGlobais.defLackey = 0;
                isFirstClick = true;
                varGlobais.cardSelect = null;
                highlight.SetActive(false);
                amplifyAtk.SetActive(false);
            }

        }
       
    }

    private void VariableChangeHandler(string newVal)
    {
        isNauseated = false;
        isAtacked = false;
        isFirstClick = true;
        varGlobais.evocaGratis = 0;
        varGlobais.buffLiberado = false;
        this.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

    void atkClick()
    {
        if (varGlobais.buffLiberado)
        {
            Def += 200;
            varGlobais.buffLiberado = false;
        }

        if(playerOwner == varGlobais.playerTurn && isAtacked ==false && isNauseated == false)
        {

            if (isFirstClick)
            {
                isFirstClick = false;
                varGlobais.atkLackey = modifyAtk;
                varGlobais.defLackey = modifyDef;
                varGlobais.cardSelect = this.gameObject;
                

                if (CanGoFace())
                {
                    if (varGlobais.playerTurn == "P1")
                    {
                        varGlobais.p2Vida -= varGlobais.atkLackey;
                        Debug.Log(varGlobais.p2Vida);
                    }
                    else
                    {
                        varGlobais.p1Vida -= varGlobais.atkLackey;
                    }

                    varGlobais.cardSelect.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
                    varGlobais.cardSelect.GetComponent<cardAtk>().isAtacked = true;
                    varGlobais.cardSelect.GetComponent<cardAtk>().amplifyAtk.SetActive(false);

                    
                } else
                {
                    highlight.SetActive(true);
                }
            }
            else
            {
                varGlobais.atkLackey = 0;
                varGlobais.defLackey = 0;
                isFirstClick = true;
                varGlobais.cardSelect = null;
                highlight.SetActive(false);
                //amplifyAtk.SetActive(false);
            }
        }
        else if(playerOwner != varGlobais.playerTurn && isAtacked == false)
        {
            
            if (varGlobais.cardSelect != null)
            {
                varGlobais.cardSelect.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
                varGlobais.cardSelect.GetComponent<cardAtk>().isAtacked = true;
                varGlobais.cardSelect.GetComponent<cardAtk>().amplifyAtk.SetActive(false);
            }


            if (varGlobais.atkLackey != 0 &&(modifyDef <= varGlobais.atkLackey))
            {
                varGlobais.cardSelect.GetComponent<cardAtk>().highlight.SetActive(false);

                /*
                 * @Renan
                 * Diminuindo a vida do oponente passando o atk e
                 * a defesa das cartas selecionadas e quem vai ser
                 * atacado, lá dentro é feito o cálculo
                 */
                if ( varGlobais.playerTurn == "P1" )
                {
                    varGlobais.p1.attack(varGlobais.atkLackey, modifyDef, varGlobais.p2);
                }
                else
                {
                    varGlobais.p2.attack(varGlobais.atkLackey, modifyDef, varGlobais.p1);
                }

                varGlobais.atkLackey = 0;
                varGlobais.defLackey = 0;
                varGlobais.cardSelect = null;
                Destroy(this.gameObject);
            }
            if (varGlobais.atkLackey != 0 && (modifyDef > varGlobais.atkLackey))
            {
                /*
                 * Se defesa maior que ataque, chama ataque passando ele mesmo
                 */
                if (varGlobais.playerTurn == "P1")
                {
                    varGlobais.p1.attack(varGlobais.atkLackey, modifyDef, varGlobais.p1);
                }
                else
                {
                    varGlobais.p2.attack(varGlobais.atkLackey, modifyDef, varGlobais.p2);
                }

                Destroy(varGlobais.cardSelect);
            }
            varGlobais.amplify = false;
            
        }
    }

    private void OnDestroy()
    {
        if(varGlobais.cardSelect == this.gameObject)
        {
            varGlobais.atkLackey = 0;
            varGlobais.defLackey = 0;
            varGlobais.cardSelect = null;
        }
    }

    private void isAmplified()
    {
        for (var i = 0; i < slots.Length; i++)
        {
            Debug.Log(slots[i].gameObject.name);
            if (slots[i].transform.childCount > 0)
            {
                noCanGoFace = true;
            }
        }

        if (!noCanGoFace)
        {
            varGlobais.p1.attack(varGlobais.atkLackey, modifyDef, varGlobais.p2);
        }
    }

    private bool CanGoFace()
    {
        if (varGlobais.playerTurn == "P1")
        {
            slots = GameObject.FindGameObjectsWithTag("Slot");
        }
        else
        {
            slots = GameObject.FindGameObjectsWithTag("Slot2");
        }

        for (var i = 0; i < slots.Length; i++)
        {
            if (slots[i].transform.childCount > 0)
            {
                return false;
            }
        }

        return true;
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {

        while (true)
        {

            yield return new WaitForSeconds(waitTime);
            accOn = false;
            alert.Stop();
            Destroy(GameObject.Find("cardCentral").transform.GetChild(0));
            modifyAtk += (int) aux;
            amplifyAtk.SetActive(false);
            
            
        }
    }
}
