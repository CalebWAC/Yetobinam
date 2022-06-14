using System;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyBehaviors {
    public class Enemy : MonoBehaviour
    {
        public enum SpawnType {
            Localized,
            Randomized
        }

        public static bool WithinRange(Vector3 playerPos, Vector3 enemyPos, float distance) {
            if (Math.Sqrt(Math.Pow(playerPos.x - enemyPos.x, 2) + Math.Pow(playerPos.y - enemyPos.y, 2) + Math.Pow(playerPos.z - enemyPos.z, 2)) <= distance) {
                return true;
            }
            return false;
        }
    }
}