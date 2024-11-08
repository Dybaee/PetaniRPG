using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMarkerOnLastTrigger : MonoBehaviour
{
    public GameObject markerObject;

   public void DestroyedMarker()
    {
        Destroy(markerObject);
    }
}
