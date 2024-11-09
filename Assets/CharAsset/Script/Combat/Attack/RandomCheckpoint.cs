using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomCheckpoint : MonoBehaviour
{
    [field: SerializeField] public float radius {get; private set;} = 10f;
    private Vector3 waypoint;

    public Vector3 GetRandomWaypoint(Vector3 center)
    {
        //Generate a random point within a circle (2D)
        // Vector2 randomPoint = UnityEngine.Random.insideUnitCircle * radius;

        //Convert the random point to a Vector3, maintaining the center's height (y value)
        // Vector3 waypoint = new Vector3(center.x + randomPoint.x, center.y, center.z + randomPoint.y);

        Vector3 randomizePoint = new Vector3(
            center.x + Random.Range(-radius, radius),
            center.y,
            center.z + Random.Range(-radius, radius)
        );

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomizePoint, out hit, radius, NavMesh.AllAreas))
        {
            return hit.position; // Return the valid waypoint position
        }
        return Vector3.zero;

        // return waypoint;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
