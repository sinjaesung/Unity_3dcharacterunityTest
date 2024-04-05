using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum Type { A, B, C, D }
    public Type enemyType;

    public int maxHealth;
    public int curHealth;
    public int score;
    public Transform target;

    public bool isDead;

    public Rigidbody rigid;
    public BoxCollider boxCollider;
    public SkinnedMeshRenderer[] meshs;
    public Animator anim;

    public Player player;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        meshs = GetComponentsInChildren<SkinnedMeshRenderer>();

        anim = GetComponentInChildren<Animator>();

        player = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Melee")
        {
            Weapon weapon = other.GetComponent<Weapon>();
            curHealth -= weapon.damage;
            Vector3 reactVec = transform.position - other.transform.position;

            Debug.Log("Melee : " + weapon.damage);

            StartCoroutine(OnDamage(reactVec));
        }
        else if(other.tag == "Bullet")
        {
            Debug.Log("Bullet공격 적용 데미지(무기데미지):" + GameManager.playerDamage);

            curHealth -= GameManager.playerDamage;
            Vector3 reactVec = transform.position - other.transform.position;
            Destroy(other.gameObject);

            Debug.Log("Range:" + GameManager.playerDamage);
            StartCoroutine(OnDamage(reactVec));
        }
    }

    IEnumerator OnDamage(Vector3 reactVec)
    {
        foreach (SkinnedMeshRenderer mesh in meshs)
        {
            mesh.material.color = Color.red;
        }

        yield return new WaitForSeconds(0.1f);

        if(curHealth > 0)
        {
            foreach (SkinnedMeshRenderer mesh in meshs)
                mesh.material.color = Color.white;
        }
        else
        {
            foreach (SkinnedMeshRenderer mesh in meshs)
                mesh.material.color = Color.gray;

            isDead = true;

            reactVec = reactVec.normalized;
            reactVec += Vector3.up;

            rigid.AddForce(reactVec * 5, ForceMode.Impulse);

            Destroy(gameObject, 4);
        }
    }
}
