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
    //        Debug.Log("�������� ������ �¾Ҵ�.");
    //        Destroy(this.gameObject);

    //        bullet.GetComponent<EnemyController>().Hit();
    //    }
    //}


    //�ݸ��� ���ʹ� isTrigger ���������� ����!
    //private void OnCollisionEnter2D(Collision2D bullet)
    //{
    //    if (bullet.gameObject.tag == "Enemy")
    //    {
    //        Debug.Log("�������� ������ �¾Ҵ�.");
    //    }
    //}



}
