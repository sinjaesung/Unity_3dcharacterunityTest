using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;


    private void OnTriggerEnter(Collider other)
    {
        //Trigger�� ��� ���⼱ bullet�߻�ü���� ��ü�� �ǹ���.github���� �ݿ� �׽�Ʈ
        if(other.gameObject.tag == "Floor")
        {
            Debug.Log("floor trigger�ÿ� bullet��ü ����");
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "Wall")
        {
            Debug.Log("wall trigger�ÿ� bullet��ü ����");
            Destroy(gameObject);
        }
    }
}
