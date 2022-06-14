using System;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyBehaviors {
    public class StalkerChaser : Enemy
    {
        public SpawnType spawnType;
        public GameObject player;
        private NavMeshAgent agent;
    
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();

            if (spawnType == SpawnType.Randomized) {
                transform.position = new Vector3(UnityEngine.Random.Range(-15, 75), Terrain.activeTerrain.SampleHeight(transform.position), UnityEngine.Random.Range(-115, 45));
            }
        }

        void Update() 
        {
            if (WithinRange(player.transform.position, transform.position, 20)) {
                agent.destination = player.transform.position;
            } else {
                agent.destination = transform.position;
            }
        }
    }
}