using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArmLeg : MonoBehaviour
{
    public GameObject enemyGO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void limbHurt(float damage)
    {
        enemyGO.GetComponent<Enemy>().Hurt(damage);
    }
    public void limbknifeHurt(float damage)
    {
        enemyGO.GetComponent<Enemy>().Hurt(damage);
    }
}
