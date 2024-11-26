using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationCompass : MonoBehaviour
{
    public RawImage CompassImage; // Reference to the RawImage containing the compass texture
    public Transform player;      // Reference to the player's transform

    void Update()
    {
        // Calculate UV offset (normalized player rotation)
        float uvOffset = player.localEulerAngles.y / 360f;

        // Wrap UV offset to prevent values outside the 0–1 range
        uvOffset = Mathf.Repeat(uvOffset, 1.0f);

        // Update the compass UV Rect (centered scrolling effect)
        CompassImage.uvRect = new Rect(uvOffset - 0.5f, 0, 1, 1);
    }
}
