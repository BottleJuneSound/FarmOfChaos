using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyController : MonoBehaviour
{
    public Vector3 currentPosition;
    public Vector3 finishPosition = new Vector3(0,0,0);
    public Vector3 resetPosition;

    public float speed = 2;
    public Collider2D rangeCollider;
    //public TilemapCollider2D waterCollider;




    void Start()
    {

        currentPosition = transform.position;
        resetPosition = new Vector2(Random.Range(-1,1.9f), Random.Range(-10, -11));
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPosition != finishPosition)
        {
            GoFinishZone();
      
        }


    }

    public void GoFinishZone()
    {
        currentPosition = transform.position;


        transform.position = Vector3.MoveTowards
            (transform.position, finishPosition, speed * Time.deltaTime);


        // 이동 후 위치를 업데이트하여 currentPosition을 새로 설정
        currentPosition = transform.position;
    }

    public void StopMove()
    {

        speed = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentPosition = transform.position;


        if (collision.gameObject.tag == "Object")
        {
            StopMove();

            float resetSpeed = 2;

            Debug.Log("충돌");
            currentPosition = Vector3.MoveTowards
                (currentPosition, resetPosition, resetSpeed *Time.deltaTime);
        }

        
    }
}
