using UnityEngine;

public class Impact : MonoBehaviour
{
    private ParticleSystem particles;
    private MemoryPool memoryPool;

    private void Awake()
    {
        particles = GetComponent<ParticleSystem>();
    }

    public void Setup(MemoryPool pool)
    {
        memoryPool = pool;
    }

    private void Update()
    {
        //��ƼŬ ������� �ƴϸ� ����
        if (particles.isPlaying == false)
        {
            memoryPool.DeactivatePoolItem(gameObject);
        }
    }
}
