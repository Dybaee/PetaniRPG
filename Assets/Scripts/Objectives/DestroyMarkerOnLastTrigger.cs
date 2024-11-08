using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMarkerOnLastTrigger : MonoBehaviour
{
    public GameObject markerObject;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(markerObject);
    }
}
