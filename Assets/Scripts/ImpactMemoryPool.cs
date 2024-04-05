using UnityEngine;

public enum ImpactType { Fire=0,Fire2,Fire3,Ice,Ice2,Ice3 }

public class ImpactMemoryPool : MonoBehaviour
{
    [SerializeField]
    private GameObject[] impactPrefab; //피격 이벤트(일단 한종류:색상만달리)
    private MemoryPool[] memoryPool; //피격 이벤트 메모리풀

    private void Awake()
    {
        memoryPool = new MemoryPool[impactPrefab.Length];
        for (int i = 0; i < impactPrefab.Length; ++i)
        {
            Debug.Log("임의 오브젝트에서 impactMemoryPool사용:" + impactPrefab[i]);
            memoryPool[i] = new MemoryPool(impactPrefab[i], 50);
        }
    }

    public void SpawnImpact(Color impactcolor,RaycastHit hit)
    {
        //부딪힌 오브젝트의 Tag 정보에 따라 다르게 처리
        if (hit.transform.CompareTag("ImpactNormal"))
        {
            OnSpawnImpact(impactcolor, hit.point, Quaternion.LookRotation(hit.normal));
        }
        else
        {
            OnSpawnImpact(impactcolor, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
    public void SpawnImpact(Color impactcolor, Collider other, Transform knifeTransform)
    {
        //부딪힌 오브젝트의 Tag 정보에 따라 다르게 처리
        if (other.transform.CompareTag("ImpactNormal"))
        {
            OnSpawnImpact(impactcolor, knifeTransform.position, Quaternion.Inverse(knifeTransform.rotation));
        }
        else
        {
            OnSpawnImpact(impactcolor, knifeTransform.position, Quaternion.Inverse(knifeTransform.rotation));
        }
    }


    public void OnSpawnImpact(Color impactcolor, Vector3 position, Quaternion rotation)
    {
        Debug.Log("활성화할 imapct EnemyMemoryPool관련:" + memoryPool[0]);
        GameObject item = memoryPool[0].ActivatePoolItem();
        item.transform.position = position;
        item.transform.rotation = rotation;
        item.GetComponent<Impact>().Setup(memoryPool[0]);

        ParticleSystem.MainModule main = item.GetComponent<ParticleSystem>().main;
        main.startColor = impactcolor;
    }
}
