using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {

    [Header ("Resources")]
    public int stone;
    public int wood;
    public int food;
    public int pop;
    public int popCap;

    [Header("UI")]
    public UIManager ui;
    private void Start()
    {
        popCap = 5;
        pop = 0;
        stone = 0;
        wood = 0;
        food = 0;
        //pop = 4;
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("collector"))
        {
            pop++;
        }
        ui.UpdateUI();
    }

    public void Spend(int type, int amount)
    {
        if(type == 1)
        {
            stone -= amount;
        }
        if(type == 2)
        {
            wood -= amount;
        }
        if(type == 3)
        {
            food -= amount;
        }

        ui.UpdateUI();
    }
}
