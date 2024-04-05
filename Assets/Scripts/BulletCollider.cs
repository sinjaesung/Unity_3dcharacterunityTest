using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour
{
    [SerializeField]
    private ImpactMemoryPool impactMemoryPool;
    [SerializeField]
    private Transform selfTransform;

    private new Collider collider;

    [SerializeField]
    public Color impactColor;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("�����÷��̾��� ������ݻ���,���ݷ�:" + GameManager.playerDamage + "," + GameManager.playerEffectColor);
        impactMemoryPool.SpawnImpact(GameManager.playerEffectColor, other, selfTransform);
    }
}
