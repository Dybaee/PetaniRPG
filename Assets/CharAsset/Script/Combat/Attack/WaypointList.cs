using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointList : MonoBehaviour
{
    [field: SerializeField] public List<Transform> wayPointsSet { get; private set; }
}
