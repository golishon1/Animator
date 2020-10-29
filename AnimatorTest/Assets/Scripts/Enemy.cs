using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private GameObject prefBullet;
    [SerializeField] private float shootDelay = 1f;
    [SerializeField] private float shootDistance = 1f;
    [SerializeField] private float speedBullet = 2f;

    [SerializeField] private float speed = 2f;
    [SerializeField] private float interval = 1f;
    [SerializeField] private Transform pointToMove;
    private Transform point1;

    void Start()
    {
        point1 = transform;
        Move();
      
    }

    private void Move()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveX(pointToMove.position.x, speed))
            .AppendInterval(interval).Append(transform.DOMoveX(point1.position.x, speed))
            .SetLoops(-1);
    }

    private IEnumerator Shoot()
    {
        for (;;)
        {
            yield return new WaitForSeconds(shootDelay);
            SpawnBullet(shootDistance);
            SpawnBullet(-shootDistance);
        }

        yield return null;
    }

    private void SpawnBullet(float dir)
    {
        var bullet = Instantiate(prefBullet, transform.position, Quaternion.identity);
        bullet.transform.DOMoveX(bullet.transform.position.x - dir, speedBullet)
            .OnComplete(() => { Destroy(bullet); });
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Shoot());
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
