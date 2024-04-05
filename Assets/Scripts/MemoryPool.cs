using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPool
{
    //�޸� Ǯ�� �����Ǵ� ������Ʈ ����
    private class PoolItem
    {
        public bool isActive; //gameObject�� Ȱ��ȭ,��Ȱ��ȭ ����
        public GameObject gameObject; //ȭ�鿡 ���̴� ���� ���ӿ�����Ʈ
    }

    private int increaseCount = 5; //������Ʈ�� ������ �� Instantiate()�� �߰� �����Ǵ� ������Ʈ ����
    private int maxCount; //���� ����Ʈ�� ��ϵǾ� �ִ� ������Ʈ ����
    private int activeCount; //���� ���ӿ� ���ǰ� �ִ�(Ȱ��ȭ) ������Ʈ ����
    private int initialMaxcnt = 55; //�ʱ⿡ �����ص� maxCount����limit��

    private GameObject poolObject; //������Ʈ Ǯ������ �����ϴ� ���� ������Ʈ ������
    private List<PoolItem> poolItemList; //�����Ǵ� ��� ������Ʈ�� �����ϴ� ����Ʈ

    public int MaxCount => maxCount; //�ܺο��� ���� ����Ʈ�� ��ϵǾ� �ִ� ������Ʈ ���� Ȯ���� ���� ������Ƽ
    public int ActiveCount => activeCount; //�ܺο��� ���� Ȱ��ȭ �Ǿ� �ִ� ������Ʈ ���� Ȯ���� ���� ������Ƽ

    //������Ʈ�� �ӽ÷� �����Ǵ� ��ġ
    private Vector3 tempPosition = new Vector3(48, 1, 48);

    public MemoryPool(GameObject poolObject, int maxcnt = 0)
    {
        initialMaxcnt = maxcnt;
        maxCount = 0;
        activeCount = 0;
        this.poolObject = poolObject;

        poolItemList = new List<PoolItem>();

        InstantiateObjects();
    }
    public void InstantiateObjects()
    {
        maxCount += increaseCount;
        if (maxCount >= initialMaxcnt)
        {
            maxCount = (maxCount - increaseCount);
        }
        else
        {
            for (int i = 0; i < increaseCount; ++i)
            {
                PoolItem poolItem = new PoolItem();

                poolItem.isActive = false;
                poolItem.gameObject = GameObject.Instantiate(poolObject);
                poolItem.gameObject.transform.position = tempPosition;
                poolItem.gameObject.SetActive(false);

                poolItemList.Add(poolItem);
            }
        }
    }
    public void DestroyObjects()
    {
        if (poolItemList == null) return;

        int count = poolItemList.Count;
        for (int i = 0; i < count; ++i)
        {
            GameObject.Destroy(poolItemList[i].gameObject);
        }

        poolItemList.Clear();
    }

    public GameObject ActivatePoolItem()
    {
        if (poolItemList == null) return null;

        //���� �����ؼ� �����ϴ� ��� ������Ʈ ������ ���� Ȱ��ȭ ������ ������Ʈ ���� ��
        //��� ������Ʈ�� Ȱ��ȭ �����̸� ���ο� ������Ʈ �ʿ�
        if (maxCount == activeCount)
        {
            InstantiateObjects();
        }

        int count = poolItemList.Count;
        for (int i = 0; i < count; ++i)
        {
            PoolItem poolItem = poolItemList[i];

            if (poolItem.isActive == false)
            {
                activeCount++;

                poolItem.isActive = true;
                poolItem.gameObject.SetActive(true);

                return poolItem.gameObject;
            }
        }
        //Debug.Log("���̻� inActive������ ������Ʈ�� �����ϴ�!");
        return null;
    }

    public void DeactivatePoolItem(GameObject removeObject)
    {
        if (poolItemList == null || removeObject == null) return;

        int count = poolItemList.Count;
        for (int i = 0; i < count; ++i)
        {
            PoolItem poolItem = poolItemList[i];

            if (poolItem.gameObject == removeObject)
            {
                activeCount--;

                poolItem.gameObject.transform.position = tempPosition;
                poolItem.isActive = false;
                poolItem.gameObject.SetActive(false);

                return;
            }
        }
    }

    public void DeactivateAllPoolItems()
    {
        if (poolItemList == null) return;

        int count = poolItemList.Count;
        for (int i = 0; i < count; ++i)
        {
            PoolItem poolItem = poolItemList[i];

            if (poolItem.gameObject != null && poolItem.isActive == true)
            {
                poolItem.gameObject.transform.position = tempPosition;
                poolItem.isActive = false;
                poolItem.gameObject.SetActive(false);
            }
        }

        activeCount = 0;
    }
}
