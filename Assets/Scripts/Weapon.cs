using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum Type { Melee, Range };
    public Type type;
    [SerializeField]
    public int damage;

    public float rate;

    public BoxCollider meleeArea;
    public TrailRenderer trailEffect;
    public Transform bulletPos;
    public GameObject bullet;

    [SerializeField]
    private Transform weaponTransform;
    [SerializeField]
    private ImpactMemoryPool impactmemorypool;
    [SerializeField]
    public  Color impactColor;

    public void Use(int attacktype)
    {
        if(attacktype == 0)
        {
            if (type == Type.Melee)
            {
                StopCoroutine("Swing");
                StartCoroutine("Swing");
            }
        }else if(attacktype == 1)
        {
            StartCoroutine("Shot");
        }
      
    }

    IEnumerator Swing()
    {
        yield return new WaitForSeconds(0.1f);
        meleeArea.enabled = true;
        trailEffect.enabled = true;

        yield return new WaitForSeconds(0.3f);
        meleeArea.enabled = false;

        yield return new WaitForSeconds(0.3f);
        trailEffect.enabled = false;
    }

    IEnumerator Shot()
    {
        //원거리 투사체 발사
        GameObject intantBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
        Rigidbody bulletRigid = intantBullet.GetComponent<Rigidbody>();
        bulletRigid.velocity = bulletPos.forward * 20;

        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("무기 충돌발생!!!:" + other.transform.name+","+ impactColor);

        impactmemorypool.SpawnImpact(impactColor,other, weaponTransform);
    }
}
