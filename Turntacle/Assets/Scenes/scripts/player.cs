using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //List<List<int>> allRounds = new List<List<int>>(new List<int>(new int[3]));
    //List<int> round = new List<int>(new int[3]); //list of 0s

    const int ROUND = 3;
    const int MOVE = 3;
    const double STARTINGSTATS = 20;
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

    int round;
    int move;

    private double attack;
    private double dodge;
    private double charge;
    private double health;

    private double attackDeduct;
    private double dodgeDeduct;

    private bool penalty;

    // Start is called before the first frame update
    void Start()
    {
        move = START;
        round = START;

        attack = STARTINGSTATS;
        dodge = STARTINGSTATS;
        charge = STARTINGSTATS;
        health = STARTINGSTATS;

        attackDeduct = STARTINGDEDUCT;
        dodgeDeduct = STARTINGDEDUCT;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    double getMove() { return move; }
    double getRound() { return round; }
    double getAttack() { return attack; }
    double getDodge() { return dodge; }
    double getCharge() { return charge; }
    double getHealth() { return health; }
    double getAttackDeduct() { return attackDeduct; }
    double getDodgeDeduct() { return dodgeDeduct; }
    bool getPenalty() { return penalty; }

    void setMove(int newMove) { this.move = newMove; }
    void setRound(int newRound) { this.round = newRound; } 
    void setAttack(double newAttack) { this.attack = newAttack; } 
    void setDodge(double newDodge) { this.dodge = newDodge; } 
    void setCharge(double newCharge) { this.charge = newCharge; } 
    void setHealth(double newHealth) { this.health = newHealth; } 
    void setAttackDeduct(double newAttackDeduct) { this.attackDeduct = newAttackDeduct; } 
    void setDodgeDeduct(double newDodgeDeduct) { this.dodgeDeduct = newDodgeDeduct; }
    void isPenalty() { penalty = !penalty; }

    void nextMove() { move++; }
    void nextRound()
    {
        
        round++;
    }

    double Attack()
    {
        double deduct = getAttackDeduct();
        if (penalty) { deduct *= PENALTYPERCENTAGE; }
        double newAttack = (getAttack() - getAttackDeduct());
        setAttack(newAttack);
        return getAttack();
    }
    double Dodge()
    {
        return getDodge();
    }
    void Charge()
    {
        //increase charge bar
    }

    void inputMove(int currentMove)
    {
        matrix[move, round] = currentMove;
        if (currentMove == (int)Moves.Attack) Attack();
        else if (currentMove == (int)Moves.Dodge) Dodge();
        else if (currentMove == (int)Moves.Charge) Charge();
        nextMove();
    }
}
