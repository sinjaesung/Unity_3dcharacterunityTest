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
        Debug.Log("게임플레이어의 무기공격색상,공격력:" + GameManager.playerDamage + "," + GameManager.playerEffectColor);
        impactMemoryPool.SpawnImpact(GameManager.playerEffectColor, other, selfTransform);
    }
}
