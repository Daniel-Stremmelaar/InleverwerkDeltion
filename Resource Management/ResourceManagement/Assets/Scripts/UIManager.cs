using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [Header("Units")]
    public List<GameObject> units = new List<GameObject>();
    public Transform spawn;
    public int costFood;
    public int costWood;

    [Header("Buttons")]
    public Button miner;
    public Button lumberjack;
    public Button farmer;
    public Button popCap;

    [Header("Text")]
    public Text stone;
    public Text wood;
    public Text food;
    public Text pop;

    [Header("Other")]
    public ResourceManager resources;
    public int popUpWood;
    public int popUpStone;
    private int multiplier;

	// Use this for initialization
	void Start () {
        miner.onClick.AddListener(delegate { Spawn(0); });
        lumberjack.onClick.AddListener(delegate { Spawn(1); });
        farmer.onClick.AddListener(delegate { Spawn(2); });
        popCap.onClick.AddListener(PopCapUp);
        multiplier = 1;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Spawn(int i)
    {
        if(resources.food >= costFood && resources.wood >= costWood && resources.pop < resources.popCap)
        {
            GameObject g = Instantiate(units[i], spawn.position, Quaternion.identity);
            resources.Spend(3, costFood);
            resources.Spend(2, costWood);
            resources.pop += 1;
        }
    }

    public void PopCapUp()
    {
        print("click");
        if(resources.wood >= popUpWood * multiplier && resources.stone >= popUpStone * multiplier)
        {
            print("bought");
            resources.Spend(2, popUpWood * multiplier);
            resources.Spend(1, popUpStone * multiplier);
            resources.popCap += 5;
            UpdateUI();
            multiplier += 1;
        }
    }

    public void UpdateUI()
    {
        stone.text = "Stone: " + resources.stone.ToString();
        wood.text = "Wood: " + resources.wood.ToString();
        food.text = "Food: " + resources.food.ToString();
        pop.text = "Population: " + resources.pop.ToString() + "/" + resources.popCap.ToString();
    }
}
