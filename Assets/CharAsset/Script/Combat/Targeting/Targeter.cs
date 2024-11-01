using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    [SerializeField] private CinemachineTargetGroup cineTargetGroup;
    public List<Target> targetList = new List<Target>();
    private Camera mainCam;

    public Target CurrentTarget { get; private set; }

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        Target target = other.GetComponent<Target>();
        if (target == null)
        {
            return;
        }

        targetList.Add(target);
        target.OnEnemyDestroyed += RemoveTarget;
    }

    private void OnTriggerExit(Collider other)
    {
        Target target = other.GetComponent<Target>();
        if (target == null)
        {
            return;
        }

        RemoveTarget(target);
    }

    public bool SelectTarget() 
    {
        if(targetList.Count == 0) 
        {
            return false;
        }

        Target closestTarget = null;
        float closestTargetDistance = Mathf.Infinity;

        foreach(Target target in targetList)
        {
            Vector2 viewPos = mainCam.WorldToViewportPoint(target.transform.position);
            if(viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
            {
                continue;
            }

            Vector2 toCenter = viewPos - new Vector2(0.5f, 0.5f);
            if(toCenter.sqrMagnitude < closestTargetDistance)
            {
                closestTarget = target;
                closestTargetDistance = toCenter.sqrMagnitude;
            }
        }

        if(closestTarget == null) { return false; }

        CurrentTarget = closestTarget;
        cineTargetGroup.AddMember(CurrentTarget.transform, 1f, 2f);

        return true;
    }

    public void CancelTargeter()
    {
        if(CurrentTarget == null) { return; }
        cineTargetGroup.RemoveMember(CurrentTarget.transform);
        CurrentTarget = null;
    }

    private void RemoveTarget(Target target)
    {
        if(CurrentTarget == target)
        {
            cineTargetGroup.RemoveMember(CurrentTarget.transform);
            CurrentTarget = null;
        }

        target.OnEnemyDestroyed -= RemoveTarget;
        targetList.Remove(target);
    }
}