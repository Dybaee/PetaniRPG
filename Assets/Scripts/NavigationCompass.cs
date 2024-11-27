using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationCompass : MonoBehaviour
{
    public RawImage CompassImage; 
    public Transform player;     

    void Update()
    {
        CompassImage.uvRect = new Rect(player.localEulerAngles.y / 360f, 0f, 1f, 1f);
    }
}
