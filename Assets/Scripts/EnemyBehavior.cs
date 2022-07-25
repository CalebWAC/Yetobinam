using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

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

    // Patroller data
    [Space(15)]
    public List<Vector3> patrolPoints;
    [HideInInspector] public int currentPatrolPoint = 0;

    // Boundaries of spawning area
    private float minX = -15;
    private float maxX = 75;
    private float minZ = -115;
    private float maxZ = 45;

    // Diver variables
    private bool floating = false;
    private bool diving = false;
    private AimConstraint lookAt;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        if (attackType == AttackType.Diver) lookAt = GetComponent<AimConstraint>();

        if (spawnType == SpawnType.Randomized) {
            if (movementType != MovementType.Patroller) {
                transform.position = new Vector3(UnityEngine.Random.Range(minX, maxX), Terrain.activeTerrain.SampleHeight(transform.position), UnityEngine.Random.Range(minZ, maxZ));
            } else {
                Debug.LogError("Patroller types cannot be randomized");
            }
        }
    }

    void Update() {
        // Attack
        switch (attackType) {
            case AttackType.Chaser:
                if (WithinRange(player.transform.position, transform.position, 20)) {
                    agent.destination = player.transform.position;
                } else if (movementType != MovementType.Wanderer && movementType != MovementType.Patroller) {
                    agent.destination = transform.position;
                } 
                break;
            case AttackType.Diver:
                if (WithinRange(player.transform.position, transform.position, 15)) {
                    if (!diving) {
                        StartCoroutine(Dive());
                    }
                } else {
                    lookAt.constraintActive = false;
                    if (!floating) {
                        StartCoroutine(Float());
                    }
                }
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

        // Movement
        if (movementType == MovementType.Wanderer) {
            if (!agent.pathPending && agent.remainingDistance < 0.5f) {
                agent.destination = new Vector3(UnityEngine.Random.Range(minX, maxX), Terrain.activeTerrain.SampleHeight(transform.position), UnityEngine.Random.Range(minZ, maxZ));
            }
        } else if (movementType == MovementType.Patroller) {
            if (!agent.pathPending && agent.remainingDistance < 0.5f) {
                agent.destination = patrolPoints[currentPatrolPoint];
                currentPatrolPoint = (currentPatrolPoint + 1) % patrolPoints.Count;
            }
        }
    }

    public static bool WithinRange(Vector3 playerPos, Vector3 enemyPos, float distance) 
    {
        if (Math.Sqrt(Math.Pow(playerPos.x - enemyPos.x, 2) + Math.Pow(playerPos.y - enemyPos.y, 2) + Math.Pow(playerPos.z - enemyPos.z, 2)) <= distance) {
            return true;
        }
        return false;
    }

    // Diver functions
    IEnumerator<WaitForSeconds> Float() 
    {
        floating = true;

        for (float i = 0; i < 1; i += 0.03f) {
            transform.Translate(0, 0.01f, 0);
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(0.2f);

        for (float i = 0; i < 2; i += 0.03f) {
            transform.Translate(0, -0.01f, 0);
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(0.2f);

        for (float i = 0; i < 1; i += 0.03f) {
            transform.Translate(0, 0.01f, 0);
            yield return new WaitForSeconds(0.01f);
        }

        floating = false;
    }

    IEnumerator<WaitForSeconds> Dive()
    {
        diving = true;

        lookAt.constraintActive = false;
        Vector3 beginning = transform.position;
        // Vector3 end = new Vector3(player.transform.forward.x, transform.position.y, player.transform.forward.z);
        Vector3 distanceToPlayer = transform.position - player.transform.position;
        Vector3 end = new Vector3(-distanceToPlayer.x, transform.position.y, -distanceToPlayer.z);
        for (float t = 0; t <= 1; t += 0.01f) {
            Vector3 q0 = Vector3.Lerp(beginning, player.transform.position - new Vector3(0, 3, 0), t);
            Vector3 q1 = Vector3.Lerp(player.transform.position - new Vector3(0, 3, 0), end, t);
            Vector3 r = Vector3.Lerp(q0, q1, t);
            transform.position = r;
            yield return new WaitForSeconds(0.01f);
        }


        lookAt.constraintActive = true;
        yield return new WaitForSeconds(4f);
        diving = false;
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