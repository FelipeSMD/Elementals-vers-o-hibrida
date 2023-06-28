using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player
{
    int lifePoints = 4000; // Cada jogar começa com 4000 pontos
    int manaShards = 4; // 4 unidades de mana, ganha +1 quando inicia o turno
    string playerName; // Na hora de criar o objeto passa o nome 'p1' ou 'p2'

    

    public Player(string name)
    {
        playerName = name;
    }

    // Seta de quem é turno
    public void startPlayerTurn()
    {
        varGlobais.playerTurn = playerName;
        
        if( playerName == "P1" )
        {
            varGlobais.p1Vida = lifePoints;
            
        }
        else
        {
            varGlobais.p2Vida = lifePoints;
        }

        addMana();
        if (playerName == "P1")
        {
            varGlobais.p1Mana = manaShards;
        }
        else
        {
            varGlobais.p2Mana = manaShards;
        }
        
        varGlobais.playerMana = manaShards;
    }

    // Chama o gameController pra mudar o turno
    public void changeTurn()
    {
        //gameController.turnChange();
    }

    public void takeDamage(int damage)
    {
        lifePoints -= damage;
        if( playerName == "P1" )
        {
            varGlobais.p1Vida = lifePoints;
           
        }
        else
        {
            varGlobais.p2Vida = lifePoints;
        }
        
        if( lifePoints <= 0 )
        {
            endGame();
        }
    }

    // Ação de atacar outro monstro
    public void attack(int atkLackey, int defLackey, Player oponent)
    {
        // Se a defesa do monstro oponent for menor
        // oponente toma dano
        if( atkLackey > defLackey )
        {
            oponent.takeDamage(atkLackey - defLackey);
        }
        // se não jogar toma dano
        else if((atkLackey < defLackey))
        {
            takeDamage(defLackey - atkLackey);
        }
    }

    private void endGame()
    {
        if (playerName == "P1")
        {
            

        }
        else
        {
            
        }
    }

    // Antes de sumunar, checa se tem mana suficiente
    public bool canSummon(int manaNedded)
    {
        if( manaNedded > manaShards )
        {
            return false;
        }

        return true;
    }

    // No começo do turno o jagador ganha +1 de mana
    public void addMana()
    {
        manaShards += 1;
    }
    
}
