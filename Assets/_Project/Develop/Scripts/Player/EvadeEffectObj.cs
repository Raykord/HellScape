using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadeEffectObj : MonoBehaviour
{
    private EchoEffect echoEffect;

    void Awake()
    {
        echoEffect = FindObjectOfType<EchoEffect>();
    }

    void OnEnable()
    {
        transform.position = echoEffect.gameObject.transform.position;
    }

    public void Deactivate()
    {
        echoEffect.CallRelease(this);
    }
}
