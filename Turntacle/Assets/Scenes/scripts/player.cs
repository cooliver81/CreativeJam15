using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{

    //List<List<int>> allRounds = new List<List<int>>(new List<int>(new int[3]));
    //List<int> round = new List<int>(new int[3]); //list of 0s

    const int ROUND = 5;
    const int MOVE = 3;
    const double STARTINGSTATS = 20;
    const double STARTINGHEALTH = 100;
    const double STARTINGDEDUCT = 2;
    const int START = 0;
    const double PENALTYPERCENTAGE = 1.5; //Multiplication to reduce more stats if repeated
    const double CHARGEMULT = 5;

    public int[,] matrix = new int[MOVE, ROUND]; // each player has a matrix to keep track of each move for each round
    enum Moves
    {
        Nothing,
        Attack,
        Dodge,
        Charge
    }

    public int round;
    public int move;

    public double attack = STARTINGSTATS;
    public double dodge = STARTINGSTATS;
    public double charge = 0;
    public double health = STARTINGHEALTH;

    public double attackDeduct = STARTINGDEDUCT;
    public double dodgeDeduct = STARTINGDEDUCT;

    public bool penalty;
    public bool isCharged;


    // Start is called before the first frame update
    void Start()
    {
        move = START;
        round = START;

        attack = STARTINGSTATS;
        dodge = STARTINGSTATS;
        charge = 0;
        health = STARTINGHEALTH;

        attackDeduct = STARTINGDEDUCT;
        dodgeDeduct = STARTINGDEDUCT;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void nextMove() { move++; }
    public void nextRound()
    {
        charge = 0;
        move = 0;
        round++;
    }

    public double Attack()
    {
        double currentAttack = attack;
        currentAttack += charge * CHARGEMULT;
        double deduct = attackDeduct;
        if (penalty) { deduct *= PENALTYPERCENTAGE; }
        attack = (attack - attackDeduct);
        charge = 0;
        return currentAttack;
    }
    public bool Dodge()
    {
        double deduct = dodgeDeduct;
        if (penalty) { deduct *= PENALTYPERCENTAGE; }
        bool dodgeSuccess = true;
        var chance = Random.Range(1, 20);
        if (chance > dodge) dodgeSuccess = false;
        dodge = (dodge - deduct);
        return dodgeSuccess;
    }
    public void Charge()
    {
        //increase charge bar
        
        charge++;
    }

    public void inputMove(int currentMove)
    {
        if (move < 3)
        {
            Debug.Log(currentMove);
            matrix[move, round] = currentMove;
            move++;
        }
        else
        {
            Debug.Log("out of moves!");
        }
    }
}
