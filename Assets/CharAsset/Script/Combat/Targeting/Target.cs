using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Target : MonoBehaviour
{
    public event Action<Target> OnEnemyDestroyed;
    private void OnDestroy()
    {
        OnEnemyDestroyed?.Invoke(this);
    }
}
