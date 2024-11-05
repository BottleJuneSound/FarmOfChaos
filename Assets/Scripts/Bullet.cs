using UnityEngine;

public class Bullet : MonoBehaviour
{
    public void Update()
    {
        if(transform.position.x > 30 || transform.position.x < -30 || transform.position.y > 30 || transform.position.y < -30)
        {
            DestroyItem();
        }
    }

    public void DestroyItem()
    {
        Destroy(this.gameObject);
    }
}
