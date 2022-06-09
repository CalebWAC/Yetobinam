using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent agent;
 
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (WithinRange(player.transform.position, 20)) {
            agent.destination = player.transform.position;
        } else {
            agent.destination = transform.position;
        }
    }

    void Update() 
    {
        if (WithinRange(player.transform.position, 20)) {
            agent.destination = player.transform.position;
        } else {
            agent.destination = transform.position;
        }
    }

    bool WithinRange(Vector3 playerPos, float distance) {
        if (Math.Sqrt(Math.Pow(playerPos.x - transform.position.x, 2) + Math.Pow(playerPos.y - transform.position.y, 2) + Math.Pow(playerPos.z - transform.position.z, 2)) <= distance) {
            return true;
        }
        return false;
    }
}
