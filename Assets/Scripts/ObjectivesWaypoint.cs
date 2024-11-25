using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectivesWaypoint : MonoBehaviour
{
    public Image img;             
    public Transform target;       
    public TextMeshProUGUI meter;  
    public Vector3 offset;         
    public float disappearThreshold = 5f;  // jarak dimana waypoint dissapear

    private void Update()
    {
        // menghitung jarang antara pemain dan target
        float distance = Vector3.Distance(target.position, transform.position);

        // if the target is too close, hide the waypoint
        if (distance <= disappearThreshold)
        {
            img.gameObject.SetActive(false);  
            meter.gameObject.SetActive(false); 
        }
        else
        {
            img.gameObject.SetActive(true);  
            meter.gameObject.SetActive(true); 
        }

        
        if (img.gameObject.activeSelf)
        {
            float minX = img.GetPixelAdjustedRect().width / 2;
            float maxX = Screen.width - minX;

            float minY = img.GetPixelAdjustedRect().height / 2;
            float maxY = Screen.height - minY;

            // mengubah world position menjadi screen position dengan offset
            Vector2 pos = Camera.main.WorldToScreenPoint(target.position + offset);

            if (Vector3.Dot((target.position - transform.position), transform.forward) < 0)
            {
                if (pos.x < Screen.width / 2)
                {
                    pos.x = maxX;
                }
                else
                {
                    pos.x = minX;
                }
            }

            // tetap berada dalam batas layar
            pos.x = Mathf.Clamp(pos.x, minX, maxX);
            pos.y = Mathf.Clamp(pos.y, minY, maxY);

            // position of the waypoint image
            img.transform.position = pos;

            // distance text
            meter.text = distance.ToString("0") + "m";
        }
    }
}
