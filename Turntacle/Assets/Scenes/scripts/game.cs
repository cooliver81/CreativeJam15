using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game : MonoBehaviour
{
    const int TOTALMOVES = 3;
    const int ROUNDS = 3;

    public int round;
    public Player player1;
    public Player player2;

    public GameObject ActionSequenceP1;
    public GameObject ActionSequenceP2;

    bool takeInputs = true;

    public Button buttonA;
    public Button buttonX;
    public Button buttonY;

    // Start is called before the first frame update
    void Start()
    {
        round = 0;
        player1 = new Player();
        player2 = new Player();
    }

    // Update is called once per frame
    void Update()
    {
        //check health to see if dead
        //check inputs?
        if (takeInputs == true)
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
    }

    public void onInput()
    {
        
    }

    public void Move()
    {
        if (player1.move < 3)
        {

        }
    }

}
