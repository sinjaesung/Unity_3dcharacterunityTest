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
        //파티클 재생중이 아니면 삭제
        if (particles.isPlaying == false)
        {
            memoryPool.DeactivatePoolItem(gameObject);
        }
    }
}
