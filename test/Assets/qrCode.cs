using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using ZXing;
using ZXing.QrCode;





public class qrCode : MonoBehaviour
{
    private WebCamTexture camTexture;
    private Rect screenRect;
    public Text resultado;
    //private float timer;
    public int currentSlot = 0;
    public GameObject cardLackey;
    public GameObject cardMagic;

    public bool isScanning = false;

    public int playermana;
    private Quaternion baseRotation; 
    //conteudo nfc
    
    public Button testSlot;
    public string slotOwner;


    void Start()
    {
        
    }

    
    
    // Extract toyxId from url
    

   

    void OnEnable()
    {
        
        screenRect = new Rect(0, 0, 1200, 1000);
        camTexture = new WebCamTexture();
        
        camTexture.requestedHeight = 1000;
        camTexture.requestedWidth = 1200;
        camTexture.requestedFPS = 60;


        if (camTexture != null)
        {
            camTexture.Play();
        }
        
    }

    void Update()
    {
        
        if(varGlobais.playerTurn == "P1")
        {
            playermana = varGlobais.p1Mana;
        } else {
            playermana = varGlobais.p2Mana;
        }

        try
        {

            

            IBarcodeReader barcodeReader = new BarcodeReader();
            // decode the current frame
            var result = barcodeReader.Decode(camTexture.GetPixels32(), camTexture.width, camTexture.height);
            if (result != null)
            {
                isScanning = true;
                Debug.Log("DECODED TEXT FROM QR:" + result.Text);
                //resultado.text = result.Text;
                //this.GetComponent<testSensor>().enabled = true;
                //this.GetComponent<qrCode>().enabled = false;

                String[] attribs = cardRecog.cardList(result.Text).Split(',');

                /*
                 * attribs[0] = atk ou efeito
                 * attribs[1] = def ou 0
                 * attribs[2] = elemento
                 * attribs[3] = Lacaio ou Mágica
                 * attribs[4] = Custo de mana
                 */

                /* @Renan
                 * Checagem pra ver se possui mana suficiente
                 */
                if (playermana >= int.Parse(attribs[4]) || varGlobais.evocaGratis > 0)
                {
                    if (attribs[3] == "Lacaio")
                    {
                        if (varGlobais.playerTurn == "P1" && varGlobais.evocaGratis <= 0)
                        {
                            varGlobais.p1Mana -= int.Parse(attribs[4]);
                        }
                        else if (varGlobais.playerTurn == "P2" && varGlobais.evocaGratis <= 0)
                        {
                            varGlobais.p2Mana -= int.Parse(attribs[4]);
                        }
                        else
                        {
                            varGlobais.evocaGratis -= 1;
                        }

                        GameObject newCard = Instantiate(cardLackey, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        newCard.transform.SetParent(this.transform);
                        newCard.transform.position = this.transform.position;
                        newCard.transform.GetComponent<Image>().sprite = Resources.Load<Sprite>(result.Text);

                        newCard.GetComponent<cardAtk>().Atk = int.Parse(attribs[0]);
                        newCard.GetComponent<cardAtk>().Def = int.Parse(attribs[1]);
                        newCard.GetComponent<cardStats>().element = attribs[2];
                        newCard.GetComponent<cardStats>().type = attribs[3];
                        String[] attribsCtx = contextPower(attribs[0], attribs[1], attribs[2], attribs[3]).Split(',');

                        newCard.transform.GetChild(0).GetComponent<Text>().text = attribsCtx[0];
                        newCard.transform.GetChild(1).GetComponent<Text>().text = attribsCtx[1];
                        newCard.GetComponent<cardAtk>().modifyAtk = int.Parse(attribsCtx[0]);
                        newCard.GetComponent<cardAtk>().modifyDef = int.Parse(attribsCtx[1]);
                        newCard.GetComponent<cardAtk>().playerOwner = varGlobais.playerTurn;

                        if (int.Parse(attribs[0]) < int.Parse(attribsCtx[0]))
                            newCard.transform.GetChild(0).GetComponent<Text>().color = Color.green;
                        if (int.Parse(attribs[0]) > int.Parse(attribsCtx[0]))
                            newCard.transform.GetChild(0).GetComponent<Text>().color = Color.red;
                        if (int.Parse(attribs[0]) == int.Parse(attribsCtx[0]))
                            newCard.transform.GetChild(0).GetComponent<Text>().color = Color.black;

                        if (int.Parse(attribs[1]) < int.Parse(attribsCtx[1]))
                            newCard.transform.GetChild(1).GetComponent<Text>().color = Color.green;
                        if (int.Parse(attribs[1]) > int.Parse(attribsCtx[1]))
                            newCard.transform.GetChild(1).GetComponent<Text>().color = Color.red;
                        if (int.Parse(attribs[1]) == int.Parse(attribsCtx[1]))
                            newCard.transform.GetChild(1).GetComponent<Text>().color = Color.black;

                        //resultado.text = result.Text;
                        this.transform.GetComponent<qrCode>().enabled = false;
                        camTexture.Stop();
                    }
                    if (attribs[3] == "Mágica")
                    {

                        resultado.text = "Este não é um lacaio !";
                        camTexture.Stop();

                        this.transform.GetComponent<qrCode>().enabled = false;


                    }
                }
                else
                {
                    resultado.text = "Você não tem mana suficiente";
                    camTexture.Stop();

                    this.transform.GetComponent<qrCode>().enabled = false;
                }
                

            }
        }
        catch (Exception ex) { Debug.LogWarning(ex.Message); }
        //timer = 0;
        //}

    }

    
    void OnGUI()
    {
        
        // drawing the camera on screen
        if (camTexture.isPlaying)
        {
            GUI.DrawTexture(screenRect, camTexture, ScaleMode.ScaleAndCrop);
        }
        
        // do the reading — you might want to attempt to read less often than you draw on the screen for performance sake
        
    }

    String contextPower(String atk, String life, String element, String type)
    {
        int auxAtk = 0;
        int auxLife = 0;
        GameObject keeper = GameObject.Find("testeTotalis");
        
        if (element == "Ar")
        {
            if (type == "Lacaio")
                if (keeper.GetComponent<waether>().tempStats <= 20)
                {
                    auxLife -= 100;
                }
            if (keeper.GetComponent<waether>().tempStats >= 26 && keeper.GetComponent<waether>().tempStats < 35)
            {
                auxLife += 100;
                auxAtk += 100;
            }
            if (keeper.GetComponent<waether>().tempStats >= 35)
            {
                auxAtk += 200;
                auxLife += 200;
            }
        }
        if (type == "Terra")
        {

        }
        if (type == "Fogo")
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

            if (keeper.GetComponent<waether>().tempStats >= 1000)
            {
                auxAtk += 100;
            }
            if (keeper.GetComponent<waether>().tempStats < 1000)
            {
                auxAtk -= 100;
            }
        }
        if (type == "Água")
        {

        }
        if (type == "Sombra")
        {
            if (keeper.GetComponent<waether>().tempStats >= 1000)
            {
                auxAtk -= 200;
                auxLife -= 300;
            }
            if (keeper.GetComponent<testSensor>().lums >= 300 && keeper.GetComponent<testSensor>().lums < 1000)
            {
                auxAtk -= 100;
                auxAtk -= 150;
            }
            if (keeper.GetComponent<testSensor>().lums < 300)
            {
                auxAtk += 100;
                auxAtk += 150;
            }
            if (keeper.GetComponent<testSensor>().lums == 0)
            {
                auxAtk += 200;
                auxAtk += 300;
            }
        }
        if (type == "Luz")
        {
            if (keeper.GetComponent<testSensor>().lums >= 1000)
            {
                auxAtk += 200;
                auxLife += 300;
            }
            if (keeper.GetComponent<testSensor>().lums >= 300 && keeper.GetComponent<testSensor>().lums < 1000)
            {
                auxAtk += 100;
                auxAtk += 150;
            }
            if (keeper.GetComponent<testSensor>().lums < 300 && keeper.GetComponent<testSensor>().lums != 0)
            {
                auxAtk -= 100;
                auxAtk -= 150;
            }
            if (keeper.GetComponent<testSensor>().lums == 0)
            {
                auxAtk -= 200;
                auxAtk -= 300;
            }
        }

        auxAtk = int.Parse(atk) + auxAtk;
        atk = auxAtk.ToString();
        auxLife = int.Parse(life) + auxLife;
        life = auxLife.ToString();

        return atk + "," + life;
    }
}
