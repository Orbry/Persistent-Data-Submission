using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameplayManager Manager;

    private void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
        Manager.GameOver();
    }
}
