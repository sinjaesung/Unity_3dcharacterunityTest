using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;


    private void OnTriggerEnter(Collider other)
    {
        //Trigger의 경우 여기선 bullet발사체형상 자체를 의미함.github변경 반영 테스트
        if(other.gameObject.tag == "Floor")
        {
            Debug.Log("floor trigger시에 bullet개체 삭제");
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "Wall")
        {
            Debug.Log("wall trigger시에 bullet개체 삭제");
            Destroy(gameObject);
        }
    }
}
