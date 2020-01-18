using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceOutput : MonoBehaviour
{

    public GameObject AttackAct1;
    public GameObject DefenseAct1;
    public GameObject ChargeAct1;

    public GameObject AttackAct2;
    public GameObject DefenseAct2;
    public GameObject ChargeAct2;

    public GameObject AttackAct3;
    public GameObject DefenseAct3;
    public GameObject ChargeAct3;

    public List<GameObject> FirstAct;
    public List<GameObject> SecondAct;
    public List<GameObject> ThirdAct;

    public game game;

    public int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        Transform t = this.transform;
        

        for (int i = 0; i < t.childCount; i++)
        {
            if (t.GetChild(i).gameObject.CompareTag("act1"))
            {
                AttackAct1 = t.GetChild(i).GetChild(0).gameObject;
                DefenseAct1 = t.GetChild(i).GetChild(1).gameObject;
                ChargeAct1 = t.GetChild(i).GetChild(2).gameObject;

            }else if (t.GetChild(i).gameObject.CompareTag("act2"))
            {
                AttackAct2 = t.GetChild(i).GetChild(0).gameObject;
                DefenseAct2 = t.GetChild(i).GetChild(1).gameObject;
                ChargeAct2 = t.GetChild(i).GetChild(2).gameObject;

            }else if (t.GetChild(i).gameObject.CompareTag("act3"))
            {
                AttackAct3 = t.GetChild(i).GetChild(0).gameObject;
                DefenseAct3 = t.GetChild(i).GetChild(1).gameObject;
                ChargeAct3 = t.GetChild(i).GetChild(2).gameObject;

            }
        }
        // First action
        FirstAct.Add(AttackAct1);
        FirstAct.Add(DefenseAct1);
        FirstAct.Add(ChargeAct1);
        // Second action
        SecondAct.Add(AttackAct2);
        SecondAct.Add(DefenseAct2);
        SecondAct.Add(ChargeAct2);
        // Third action
        ThirdAct.Add(AttackAct3);
        ThirdAct.Add(DefenseAct3);
        ThirdAct.Add(ChargeAct3);

        foreach (GameObject action in FirstAct)
        {
            action.SetActive(false);
        }
        foreach (GameObject action in SecondAct)
        {
            action.SetActive(false);
        }
        foreach (GameObject action in ThirdAct)
        {
            action.SetActive(false);
        }

    }

    void showAction(List<GameObject> list, int index){
        foreach(GameObject action in list){
            
            action.SetActive(false);
        }
        list[index-1].SetActive(true);

    }

    void showSequence()
    {
        for(int i = 0; i < 3; i++){
            if(i == 0){
                showAction(FirstAct, game.player1.matrix[i, game.round]);
            }
            if (i == 1)
            {
                showAction(SecondAct, game.player1.matrix[i, game.round]);
            }
            if (i == 2)
            {
                showAction(ThirdAct, game.player1.matrix[i, game.round]);
            }

        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
            showSequence();
    }
}
