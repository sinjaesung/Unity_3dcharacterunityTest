using UnityEngine;

public enum ImpactType { Fire=0,Fire2,Fire3,Ice,Ice2,Ice3 }

public class ImpactMemoryPool : MonoBehaviour
{
    [SerializeField]
    private GameObject[] impactPrefab; //�ǰ� �̺�Ʈ(�ϴ� ������:���󸸴޸�)
    private MemoryPool[] memoryPool; //�ǰ� �̺�Ʈ �޸�Ǯ

    private void Awake()
    {
        memoryPool = new MemoryPool[impactPrefab.Length];
        for (int i = 0; i < impactPrefab.Length; ++i)
        {
            Debug.Log("���� ������Ʈ���� impactMemoryPool���:" + impactPrefab[i]);
            memoryPool[i] = new MemoryPool(impactPrefab[i], 50);
        }
    }

    public void SpawnImpact(Color impactcolor,RaycastHit hit)
    {
        //�ε��� ������Ʈ�� Tag ������ ���� �ٸ��� ó��
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
        //�ε��� ������Ʈ�� Tag ������ ���� �ٸ��� ó��
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
        Debug.Log("Ȱ��ȭ�� imapct EnemyMemoryPool����:" + memoryPool[0]);
        GameObject item = memoryPool[0].ActivatePoolItem();
        item.transform.position = position;
        item.transform.rotation = rotation;
        item.GetComponent<Impact>().Setup(memoryPool[0]);

        ParticleSystem.MainModule main = item.GetComponent<ParticleSystem>().main;
        main.startColor = impactcolor;
    }
}
