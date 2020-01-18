using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game : MonoBehaviour
{
    const int TOTALMOVES = 3;
    const int ROUNDS = 5;

    int round;
    Player player1;
    Player player2;
    bool takeInputs;
    bool roundStart = true;

    bool isReady1;
    bool isReady2;

    public Button buttonA;
    public Button buttonX;
    public Button buttonY;

    // Start is called before the first frame update
    void Start()
    {
        round = 0;
        player1 = new Player();
        player2 = new Player();

        isReady1 = false;
        isReady2 = false;
        takeInputs = true;
    }

    // Update is called once per frame
    void Update()
    {
        //check health to see if dead
        //check inputs?
        if (roundStart)
        {
            roundStart = false;
            if (round < 5) Debug.Log("ROUND " + round + " START, CHOOSE YOUR MOVES!");
            else endGame(0);
        }
        if (takeInputs == true)
        {

            if (player1.move < 3 && !isReady1)
            {
                if (Input.GetKeyDown(KeyCode.A)) //ATTACK
                {
                    Debug.Log("p1");
                    player1.inputMove(1);
                }
                if (Input.GetKeyDown(KeyCode.D)) //DODGE
                {
                    Debug.Log("p1");
                    player1.inputMove(2);
                }
                if (Input.GetKeyDown(KeyCode.S)) //CHARGE
                {
                    Debug.Log("p1");
                    player1.inputMove(3);
                }
            }
            else if (!isReady1)
            {
                Debug.Log("Player 1 Ready!");
                isReady1 = true;
            }
            if (player2.move < 3 && !isReady2)
            {
                if (Input.GetKeyDown(KeyCode.Joystick1Button0)) //ATTACK, A button
                {
                    Debug.Log("p2");
                    player2.inputMove(1);
                }
                if (Input.GetKeyDown(KeyCode.Joystick1Button2)) //DODGE, X button
                {
                    Debug.Log("p2");
                    player2.inputMove(2);
                }
                if (Input.GetKeyDown(KeyCode.Joystick1Button3)) //CHARGE, Y button
                {
                    Debug.Log("p2");
                    player2.inputMove(3);
                } 
            }
            else if (!isReady2)
            {
                Debug.Log("Player 2 Ready!");
                isReady2 = true;
            }
        }

        if (isReady1 && isReady2)
        {
            takeInputs = false;
            player1.move = 0;
            player2.move = 0;
            Round();
        }
    }

    public void onInput()
    {
        
    }

    public void Round()
    {
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("Round " + round + " Move " + i);

            //PLAYERS DO THE SAME MOVES
            if (player1.matrix[i, round] == 1 && player2.matrix[i, round] == 1)
            {
                Debug.Log("Both players attack!");
                player1.health -= player2.attack;
                player2.health -= player1.attack;
                player2.Attack();
                player1.Attack();
            }
            else if (player1.matrix[i, round] == 2 && player2.matrix[i, round] == 2)
            {
                Debug.Log("Both players dodge! Nothing happens!");
                player1.Dodge();
                player2.Dodge();
            }
            else if (player1.matrix[i, round] == 3 && player2.matrix[i, round] == 3)
            {
                Debug.Log("Both players charge!");
                player1.Charge();
                player2.Charge();
            }

            //ATTACK AND DEFEND
            else if (player1.matrix[i, round] == 1 && player2.matrix[i, round] == 2)
            {
                Debug.Log("Player 1 attacks! Player 2 dodges!");
                if (!player2.Dodge())
                {
                    Debug.Log("Player 2 fails to dodge!");
                    player2.health -= player1.attack;
                }
                player1.Attack();
            }
            else if (player1.matrix[i, round] == 2 && player2.matrix[i, round] == 1)
            {
                Debug.Log("Player 1 dodges! Player 2 attacks!");
                if (!player1.Dodge())
                {
                    Debug.Log("Player 1 fails to dodge!");
                    player1.health -= player2.attack;
                }
                player2.Attack();
            }

            //ATTACK AND CHARGE
            else if (player1.matrix[i, round] == 1 && player2.matrix[i, round] == 3)
            {
                Debug.Log("Player 1 attacks! Player 2 can't charge!");
                player2.health -= player1.attack;
                player1.Attack();
            }
            else if (player1.matrix[i, round] == 3 && player2.matrix[i, round] == 1)
            {
                Debug.Log("Player 1 can't charge! Player 2 attacks!");
                player1.health -= player2.attack;
                player2.Attack();
            }

            //DEFEND AND CHARGE
            else if (player1.matrix[i, round] == 2 && player2.matrix[i, round] == 3)
            {
                Debug.Log("Player 1 dodges! Player 2 charges!");
                player1.Dodge();
                player2.Charge();
            }
            else if (player1.matrix[i, round] == 3 && player2.matrix[i, round] == 2)
            {
                Debug.Log("Player 1 charges! Player 2 dodges!");
                player2.Dodge();
                player1.Charge();
            }

            if (player1.health <= 0) { endGame(2); }
            if (player2.health <= 0) { endGame(1); }

            Debug.Log("Player1: Health: " + player1.health + " Attack: " + player1.attack + " Dodge: " + player1.dodge + " Charge: " + player1.charge);
            Debug.Log("Player2: Health: " + player2.health + " Attack: " + player2.attack + " Dodge: " + player2.dodge + " Charge: " + player2.charge);

        }
        Debug.Log("Round " + round + " completed!");
        round++;
        player1.round++;
        player2.round++;
        roundStart = true;
        isReady1 = false;
        isReady2 = false;
        takeInputs = true;
    }


    void endGame(int winner)
    {
        if (winner == 0)
        {
            if (player1.health > player2.health)
            {
                Debug.Log("Player 1 has more health! Player 1 wins!");
            }
            if (player1.health < player2.health)
            {
                Debug.Log("Player 2 has more health! Player 2 wins!");
            }
            if (player1.health == player2.health)
            {
                Debug.Log("It's a tie!");
            }
        }
        if (winner == 1)
        {
            Debug.Log("Knockout! Player 1 wins!");
        }
        if (winner == 2)
        {
            Debug.Log("Knockout! Player 2 wins!");
        }
        Application.Quit();
    }
}
