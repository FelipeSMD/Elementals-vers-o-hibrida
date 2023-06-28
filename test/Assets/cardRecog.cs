using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardRecog : MonoBehaviour
{
    static string aux;
    public static string cardList(string cardName)
    {

        switch (cardName)
        {
            //Deck de Ar
            case "Criatura de Ar":
                aux = "100,100,Ar,Lacaio, 1";
                break;
            case "Aprendiz do Vento":
                aux = "200,200,Ar,Lacaio, 2";
                break;
            case "Mestre do Vento":
                aux = "500,300,Ar,Lacaio, 3";
                break;
            case "Doutor do Vento":
                aux = "800,200,Ar,Lacaio, 4";
                break;
            case "Comandante do Vento":
                aux = "900,900,Ar,Lacaio, 8";
                break;
            case "Golem de Ar":
                aux = "100,600,Ar,Lacaio, 3";
                break;
            case "Guarda de Ar":
                aux = "400,400,Ar,Lacaio, 3";
                break;
            case "Harpia suicida":
                aux = "400,100,Ar,Lacaio, 2";
                break;
            case "Trupe do Vento":
                aux = "Compre 3 cartas. Se forem criaturas evoque-as,0,Ar,Mágica,7";
                break;
            case "Escudo de Vento":
                aux = "Aumenta em 200 a defesa de qualquer criatura.,0,Ar,Mágica,1";
                break;
            case "Flechada de Vácuo":
                aux = "Implode o núcleo de qualquer criatura. Destrua uma criatura inimiga.,0,Ar,Mágica,4";
                break;
            case "Tufão":
                aux = "Destrua todas as criaturas do inimigo.,0,Ar,Mágica,10";
                break;
            case "Rajada de Vento":
                aux = "Cause 200 de dano a todas as criaturas inimigas.,0,Ar,Mágica,3";
                break;
            case "Ar quente":
                aux = "Aumente a temperatura em 1 nivel.,0,Ar,Mágica,1";
                break;
            case "Ventos quentes":
                aux = "Compre duas cartas.,0,Ar,Mágica,3";
                break;

            //Deck de Fogo
            case "Criatura de Fogo":
                aux = "100,100,Fogo,Lacaio";
                break;
            case "Aprendiz do Fogo":
                aux = "200,200,Fogo,Lacaio,2";
                break;
            case "Mestre do Fogo":
                aux = "500,300,Fogo,Lacaio";
                break;
            case "Doutor do Fogo":
                aux = "800,200,Fogo,Lacaio";
                break;
            case "Comandante do Fogo":
                aux = "1000,100,Fogo,Lacaio";
                break;
            case "Golem de Fogo":
                aux = "100,600,Fogo,Lacaio";
                break;
            case "Guarda de Fogo":
                aux = "400,400,Fogo,Lacaio";
                break;
            // case "Cerberus":
            //aux = "400,100,Fogo,Lacaio";
            //break;
            case "Trupe do Fogo":
                aux = "Invoque: 1 Aprendiz; 1 Mestre e 1 Doutor do Fogo.,0,Fogo,Mágica";
                break;
            case "Escudo de Fogo":
                aux = "Aumenta em 200 a vida de qualquer criatura de Fogo.,0,Fogo,Mágica";
                break;
            case "Explosão de fogo":
                aux = "Implode o núcleo de qualquer criatura. Destrua uma criatura inimiga.,0,Fogo,Mágica";
                break;
            case "Erupção Vulcânica":
                aux = "Destrua todas as criaturas do inimigo.,0,Fogo,Mágica";
                break;
            case "Incêndio":
                aux = "Cause 200 de dano a todas as criaturas inimigas e empurre-as para trás.,0,Fogo,Mágica";
                break;
            case "Onda de Calor":
                aux = "Aumenta a temperatura em 10 graus.,0,Fogo,Mágica";
                break;
            case "Manhã ensolarada":
                aux = "Aumenta a luminosidade em 400.,0,Fogo,Mágica";
                break;

            //Deck de Água
            case "Criatura de Água":
                aux = "100,100,Água,Lacaio";
                break;
            case "Aprendiz da Água":
                aux = "200,200,Água,Lacaio";
                break;
            case "Mestre da Água":
                aux = "500,300,Água,Lacaio";
                break;
            case "Doutor da Água":
                aux = "800,200,Água,Lacaio";
                break;
            case "Comandante da Água":
                aux = "1000,100,Água,Lacaio";
                break;
            case "Golem de Água":
                aux = "100,600,Água,Lacaio";
                break;
            case "Guarda de Água":
                aux = "400,400,Água,Lacaio";
                break;
            case "Serpente Marinha":
                aux = "400,100,Água,Lacaio,2";
                break;
            case "Trupe de Água":
                aux = "Invoque: 1 Aprendiz; 1 Mestre e 1 Doutor da Água.,0,Água,Mágica";
                break;
            case "Escudo de Água":
                aux = "Aumenta em 200 a vida de qualquer criatura de Água.,0,Água,Mágica";
                break;
            case "Canhão de Água":
                aux = "Implode o núcleo de qualquer criatura. Destrua uma criatura inimiga.,0,Água,Mágica";
                break;
            case "Tsunami":
                aux = "Destrua todas as criaturas do inimigo.,0,Água,Mágica";
                break;
            case "Alagamento":
                aux = "Cause 200 de dano a todas as criaturas inimigas e empurre-as para trás.,0,Água,Mágica";
                break;
            case "Temporal":
                aux = "Diminui a temperatura em 10 graus.,0,Água,Mágica";
                break;
            case "Céu Nublado":
                aux = "Diminui a luminosidade em 400.,0,Água,Mágica";
                break;

            // Deck das sombras
            // Atk,Def,Atributo,Tipo,Custo
            case "Criatura das sombras":
                    aux = "100,100,Sombra,Lacaio,1";
                break;
            case "Vulto":
                aux = "200,200,Sombra,Lacaio,2";
                break;
            case "Aparição nervosa":
                aux = "500,300,Sombra,Lacaio,3";
                break;
            case "Enviado das Trevas":
                aux = "700,300,Sombra,Lacaio,4";
                break;
            case "Comandante das sombras":
                aux = "600,500,Sombra,Lacaio,6";
                break;
            case "Parede de Fumaça":
                aux = "0,800,Sombra,Lacaio,3";
                break;
            case "Criador de trevas":
                aux = "500,600,Sombra,Lacaio,6";
                break;
            case "Demônio inferior":
                aux = "400,400,Sombra,Lacaio,3";
                break;
            case "Cerberus":
                aux = "800,800,Sombra,Lacaio,7";
                break;
            case "Manifestação das profundezas":
                aux = "Invoque: 1 Aprendiz; 1 Mestre e 1 Doutor das Sombras.,0,Sombra,Mágica,8";
                break;
            case "Escudo das sombras":
                aux = "Aumenta em 200 a vida de qualquer criatura de Luz.,0,Sombra,Mágica,1";
                break;
            case "Flecha sônica":
                aux = "Destrua uma criatura inimiga.,0,Sombra,Mágica,4";
                break;
            case "Maldição dos caídos":
                aux = "Destrua todas as criaturas do inimigo.,0,Sombra,Mágica,10";
                break;
            case "Gás venenoso":
                aux = "Diminui a defesa das criaturas inimigas em 100.,0,Sombra,Mágica,3";
                break;
            case "Bréu Noturno":
                aux = "Diminui a luminosidade em 1 nivel,0,Sombra,Mágica,1";
                break;
            case "Sombra do abismo":
                aux = "Compre 2 cartas. Se forem criaturas evoque-as.,0,Sombra,Mágica,5";
                break;
            case "Nevoeiro":
                aux = "Aumenta em 100 a defesa das criaturas aliadas.,0,Sombra,Mágica,3";
                break;
            case "Visão Restrita":
                aux = "Deixe as criaturas inimigas sem atacar no proximo turno.,0,Sombra,Mágica,4";
                break;
            case "Vislumbre sombrio":
                aux = "Compre 3 cartas. Se forem criaturas evoque-as.,0,Sombra,Mágica,7";
                break;

            // Deck de luz
            case "Ceiatura de luz":
                aux = "500,200,Luz,Lacaio,1";
                break;
            case "Aprendiz da luz":
                aux = "700,300,Luz,Lacaio,2";
                break;
            case "Mestre da luz":
                aux = "900,500,Luz,Lacaio,3";
                break;
            case "Doutor da luz":
                aux = "1500,500,Luz,Lacaio,4";
                break;
            case "Comandante da luz":
                aux = "2000,500,Luz,Lacaio,6";
                break;
            case "Golem de luz":
                aux = "500,1500,Luz,Lacaio,3";
                break;
            case "Guarda da luz":
                aux = "800,1000,Luz,Lacaio,3";
                break;
            case "Arcanjo":
                aux = "1200,0,Luz,Lacaio,2";
                break;
            case "Benção do céus":
                aux = "Invoque: 1 Aprendiz; 1 Mestre e 1 Doutor da Luz.,0,Luz,Mágica,8";
                break;
            case "Escudo de Luz":
                aux = "Aumenta em 200 a vida de qualquer criatura de Luz.,0,Luz,Mágica,1";
                break;
            //case "Flecha sônica":
                //aux = "Destrua uma criatura inimiga.,0,Luz,Mágica,4";
                //break;
            case "Punição divina":
                aux = "Destrua todas as criaturas do inimigo.,0,Luz,Mágica,6";
                break;
            case "Rajada de vento":
                aux = "Diminui o ataque das criaturas inimigas em 500.,0,Luz,Mágica,3";
                break;
            case "Onda de calor":
                aux = "Aumenta temperatura em 10 graus.,0,Luz,Mágica,1";
                break;
            case "Dia ensolarado":
                aux = "Aumenta a luminosidade em 400.,0,Luz,Mágica,2";
                break;

            //Default case
            default:
                aux = "Carta não reconhecida";
                break;
        }
        return aux;
    }
}
