using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyBoss : MonoBehaviour
{
  [Header("Weapon Stats")]
  [SerializeField] private float shootIntervalInSeconds;

  [Header("Bullets")]
  public Bullet bullet;
  [SerializeField] private Transform bulletSpawnPoint;

  [Header("Bullet Pool")]
  private IObjectPool<Bullet> objectPool;

  private readonly bool collectionCheck = true;
  private readonly int defaultCapacity = 30;
  private readonly int maxSize = 100;
  private float timer;
  public Transform parentTransform;

  private void Awake()
  {
    objectPool = new ObjectPool<Bullet>(CreateBullet, OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject, collectionCheck, defaultCapacity, maxSize);
  }

  private Bullet CreateBullet()
  {
    Bullet bulletInstance = Instantiate(bullet);
    bulletInstance.ObjectPool = objectPool;
    return bulletInstance;
  }

  private void OnGetFromPool(Bullet bullet)
  {
    bullet.gameObject.SetActive(true);
  }

  private void OnReleaseToPool(Bullet bullet)
  {
    bullet.gameObject.SetActive(false);
  }

  private void OnDestroyPooledObject(Bullet bullet)
  {
    Destroy(bullet.gameObject);
  }

  private void FixedUpdate()
  {
    if ( Time.time > timer && objectPool != null)
    {
      bullet = objectPool.Get();

      if (bullet == null)
      {
        return;
      }

      bullet.transform.SetPositionAndRotation(bulletSpawnPoint.position, bulletSpawnPoint.rotation);

      bullet.InitializeBullet(Vector2.down);


      //bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.up * bullet.speed, ForceMode.Acceleration);

      bullet.Deactivate();

      timer = Time.time + shootIntervalInSeconds;
    }
  }
}
