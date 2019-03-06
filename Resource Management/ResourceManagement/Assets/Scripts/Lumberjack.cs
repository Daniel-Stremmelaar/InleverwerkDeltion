using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumberjack : Collector
{
    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wood")
        {
            target = other.gameObject;
            agent.destination = target.transform.position;
        }

        if (found == false && target != null)
        {
            found = true;
            search.radius = gatherRange;
            current = job.gather;
        }

        if (other.gameObject.tag == "home" && carried != 0)
        {
            resourceManager.GetComponent<ResourceManager>().wood += carried;
            ui.UpdateUI();
            carried = 0;
            current = job.gather;
            agent.destination = target.transform.position;
        }
    }

    /*public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Home")
        {
            resourceManager.GetComponent<ResourceManager>().wood += carried;
            carried = 0;
            current = job.gather;
            agent.destination = target.transform.position;
        }
    }*/
}
