using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{

    //List<List<int>> allRounds = new List<List<int>>(new List<int>(new int[3]));
    //List<int> round = new List<int>(new int[3]); //list of 0s

    const int ROUND = 3;
    const int MOVE = 3;
    const double STARTINGSTATS = 20;
    const double STARTINGHEALTH = 50;
    const double STARTINGDEDUCT = 1;
    const int START = 0;
    double PENALTYPERCENTAGE = 1.5; //Multiplication to reduce more stats if repeated

    int[,] matrix = new int[MOVE, ROUND]; // each player has a matrix to keep track of each move for each round
    enum Moves
    {
        Nothing,
        Attack,
        Dodge,
        Charge
    }

    public int round;
    public int move;

    public double attack;
    public double dodge;
    public double charge;
    public double health;

    public double attackDeduct;
    public double dodgeDeduct;

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
        isCharged = false;
        double deduct = attackDeduct;
        if (penalty) { deduct *= PENALTYPERCENTAGE; }
        attack = (attack - attackDeduct);
        return attack;
    }
    public bool Dodge()
    {
        dodge--;
        bool dodgeSuccess = true;
        var chance = Random.Range(1, 20);
        if (chance > dodge) dodgeSuccess = false; 
        return dodgeSuccess;
    }
    public void Charge()
    {
        //increase charge bar
        isCharged = true;
        charge++;
    }

    public void inputMove(int currentMove)
    {
        Debug.Log(currentMove);
        matrix[move, round] = currentMove;
        if (currentMove == (int)Moves.Attack) Attack();
        else if (currentMove == (int)Moves.Dodge) Dodge();
        else if (currentMove == (int)Moves.Charge) Charge();
        nextMove();
    }
}
