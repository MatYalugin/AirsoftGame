using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    private float Damage = 1;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Player>().Hurt(Damage);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().Hurt(Damage);
        }
        if (other.gameObject.CompareTag("Head"))
        {
            other.GetComponent<EnemyHead>().headHurt(Damage);
        }
        if (other.gameObject.CompareTag("Limb"))
        {
            other.GetComponent<EnemyArmLeg>().limbHurt(Damage);
        }
    }
}
