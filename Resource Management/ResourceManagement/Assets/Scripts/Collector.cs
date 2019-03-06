using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Collector : MonoBehaviour {

    [Header("Gathering")]
    public int searchSpeed;
    public float moveSpeed;
    public int gatherRange;
    public float gatherTime;
    public int carryCap;
    //type 1: stone, type 2: wood, type 3: food

    [Header("UI")]
    public UIManager ui;

    public SphereCollider search;
    public GameObject home;
    public GameObject resourceManager;
    public int carried;
    public float timer;
    public GameObject target;
    public enum job { search, gather, deliver };
    public job current;
    public bool found;
    public NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        found = false;
        current = job.search;
        home = GameObject.FindGameObjectWithTag("home");
        ui = home.GetComponent<UIManager>();
        agent = GetComponent<NavMeshAgent>();
        search = GetComponent<SphereCollider>();
        resourceManager = GameObject.FindGameObjectWithTag("resourcemanager");
        agent.speed = moveSpeed;
        //Set home & resourcemanager
    }
	
	// Update is called once per frame
	void Update () {
		switch (current)
        {
            case job.search:
                //Grow trigger to find resource
                if(found == false)
                {
                    search.radius += Time.deltaTime * searchSpeed;
                }
                break;

            case job.gather:
                //Go to gather point and stay until gathered
                break;

            case job.deliver:
                //Go to home until collision
                break;
        }
	}

    public virtual void OnTriggerEnter(Collider other)
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject == target)
        {
            timer -= Time.deltaTime;
            if(carried < carryCap && timer <= 0)
            {
                carried++;
                timer = gatherTime;
            }
            if(carried >= carryCap)
            {
                current = job.deliver;
                agent.destination = home.transform.position;
            }
        }
    }

    /*public virtual void OnCollisionEnter(Collision collision)
    {
        
    }*/
}
