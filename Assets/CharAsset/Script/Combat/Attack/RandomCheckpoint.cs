using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCheckpoint : MonoBehaviour
{
    [field: SerializeField] public float radius {get; private set;} = 10f;

    public Vector3 GetRandomWaypoint(Vector3 center, float radius)
    {
        // Generate a random point within a circle (2D)
        Vector2 randomPoint = UnityEngine.Random.insideUnitCircle * radius;

        // Convert the random point to a Vector3, maintaining the center's height (y value)
        Vector3 waypoint = new Vector3(center.x + randomPoint.x, center.y, center.z + randomPoint.y);

        return waypoint;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
