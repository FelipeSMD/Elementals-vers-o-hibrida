using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class varGlobais : MonoBehaviour
{
    public static Player p1 = new Player("P1");
    public static Player p2 = new Player("P2");

    public static int p1Rounds = 1;
    public static int p2Rounds = 0;

    public static int p1Mana = 1;
    public static int p2Mana = 0;

    public static int p1Vida = 4000;
    public static int p2Vida = 4000;
   
    public static string playerTurn = "P1";
    public static int playerMana = 5;
    
    public static int atkLackey = 0;
    public static int defLackey = 0;

    public static bool amplify = false;
    public static GameObject cardSelect = null;

    public static string luminosidadeAtual = "Neutro";
    public static string temperaturaAtual = "Neutro";
    public static string ventoAtual = "Neutro";

    public static int evocaGratis = 0;
    public static bool buffLiberado = false;
}
