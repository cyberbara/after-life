using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    bullet,
    sworld,
}

public class Bullet : MonoBehaviour
{
    public BulletType DamageType;
    public int damage;

    public GameObject flash;
    public GameObject voidFlash;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (DamageType == BulletType.bullet)
            {
                EnemyHealth HP = collision.gameObject.GetComponent<EnemyHealth>();
                HP.Hit(damage);
                print("Пулей в лоб");
                Destroy(gameObject);
                Instantiate(flash, transform.position, Quaternion.identity);
            }
        }
        else
        {
            if (DamageType == BulletType.bullet)
            {
                print("Это была пуля!");
                Destroy(gameObject);
                Instantiate(flash, transform.position, Quaternion.identity);
            }
        }
        
    }

}
