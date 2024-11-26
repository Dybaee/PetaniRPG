using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationCompass : MonoBehaviour
{

    public RawImage CompassImage;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float uvOffset = player.localEulerAngles.y / 360f;
        CompassImage.uvRect = new Rect(uvOffset - 0.5f, 0, 1, 1);
        Vector3 forward = player.transform.forward;

        forward.y = 0;

        float headingAngle = Quaternion.LookRotation(forward).eulerAngles.y;
        headingAngle = 5 * (Mathf.RoundToInt(headingAngle / 5.0f));
    }
}
