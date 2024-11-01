using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    public void DestroyItem()
    {
        Destroy(this.gameObject);
    }

    //private void OnTriggerEnter2D(Collider2D bullet)
    //{
    //    if (bullet.gameObject.tag == "Enemy")
    //    {
    //        Debug.Log("아이템이 적에게 맞았다.");
    //        Destroy(this.gameObject);

    //        bullet.GetComponent<EnemyController>().Hit();
    //    }
    //}


    //콜리전 엔터는 isTrigger 켜져있을때 가능!
    //private void OnCollisionEnter2D(Collision2D bullet)
    //{
    //    if (bullet.gameObject.tag == "Enemy")
    //    {
    //        Debug.Log("아이템이 적에게 맞았다.");
    //    }
    //}



}
