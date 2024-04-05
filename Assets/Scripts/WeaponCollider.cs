using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    [SerializeField]
    private ImpactMemoryPool impactmemorypool;
    [SerializeField]
    private Transform weaponTransform;

    private new Collider collider;
    private int damage;

    private void Awake()
    {
        collider = GetComponent<Collider>();
        collider.enabled = false;
    }

    public void StartCollider(int damage)
    {
        this.damage = damage;
        collider.enabled = true;

        StartCoroutine("DisabledbyTime", 0.1f);
    }

    private IEnumerator DisablebyTime(float time)
    {
        yield return new WaitForSeconds(time);

        collider.enabled = false;
    }
}
