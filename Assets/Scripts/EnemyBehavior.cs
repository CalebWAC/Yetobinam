using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public enum SpawnType {
        Localized,
        Randomized
    }

    public enum MovementType {
        Stalker,
        Patroller,
        Wanderer
    }

    public enum AttackType {
        Chaser,
        Diver,
        Swimmer,
        Climber,
        Archer,
        Digger
    }

    [Header("Enemy Type")]
    public SpawnType spawnType;
    public AttackType attackType;
    public MovementType movementType;

    [Space(10)]
    [Header("Objects")]
    public GameObject player;
    private NavMeshAgent agent;

    [Space(15)]
    public List<Vector3> patrolPoints;
    [HideInInspector] public int currentPatrolPoint = 0;

    void Start() {
        agent = GetComponent<NavMeshAgent>();

        if (spawnType == SpawnType.Randomized) {
            transform.position = new Vector3(UnityEngine.Random.Range(-15, 75), Terrain.activeTerrain.SampleHeight(transform.position), UnityEngine.Random.Range(-115, 45));
        }
    }

    void Update() {
        switch (attackType) {
            case AttackType.Chaser:
                if (WithinRange(player.transform.position, transform.position, 20)) {
                    agent.destination = player.transform.position;
                } else if (movementType != MovementType.Wanderer && movementType != MovementType.Patroller) {
                    agent.destination = transform.position;
                } 
                break;
            case AttackType.Diver:
                break;
            case AttackType.Swimmer:
                break;
            case AttackType.Climber:
                break;
            case AttackType.Archer:
                break;
            case AttackType.Digger:
                break;
        }

        if (movementType == MovementType.Wanderer) {
           
        } else if (movementType == MovementType.Patroller) {
            if (!agent.pathPending) {
                agent.destination = patrolPoints[currentPatrolPoint];
                currentPatrolPoint = (currentPatrolPoint + 1) % patrolPoints.Count;
            }

        } else if (movementType == MovementType.Stalker) {
           
        }
    }

    public static bool WithinRange(Vector3 playerPos, Vector3 enemyPos, float distance) {
        if (Math.Sqrt(Math.Pow(playerPos.x - enemyPos.x, 2) + Math.Pow(playerPos.y - enemyPos.y, 2) + Math.Pow(playerPos.z - enemyPos.z, 2)) <= distance) {
            return true;
        }
        return false;
    }
}

/* [CustomEditor(typeof(EnemyBehavior))]
public class EnemyBehaviorEditor : Editor {
    public override void OnInspectorGUI() {
        EnemyBehavior myScript = target as EnemyBehavior;

        base.OnInspectorGUI();

        if (myScript.movementType == EnemyBehavior.MovementType.Patroller) {
            myScript.patrolPoints = EditorGUILayout.PropertyField(myScript.patrolPoints) as List<Vector3>;
        } 
    }
} */