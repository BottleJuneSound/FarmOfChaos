using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyController : MonoBehaviour
{
    public Vector3 currentPosition;
    public Vector3 finishPosition;
    public Vector3 resetPosition;

    public float speed = 2;
    public Collider2D rangeCollider;
    //public TilemapCollider2D waterCollider;
    bool moveResetZone;



    void Start()
    {

        currentPosition = transform.position;
        finishPosition = new Vector3(Random.Range(0f, 1f), Random.Range(2f, 5.2f));
        resetPosition = new Vector2(Random.Range(-1, 1.9f), Random.Range(-10, -11));
    }

    void Update()
    {
        currentPosition = transform.position;

        //목적지로 이동
        if (currentPosition != finishPosition)
        {
            if (moveResetZone == false) //중첩 if를 활용하여 리셋존 이동중이라면 작동하지 않음
            {
                GoFinishZone();
            }
        }

        //object 태그 충돌이 충족하면 시작
        if (moveResetZone == true)
        {
            float resetSpeed = 2;
            Debug.Log("리셋포인트로 이동!");

            transform.position = Vector3.MoveTowards
                (transform.position, resetPosition, resetSpeed * Time.deltaTime);
        }

        //리셋포인트에 도착하면 정지
        if (resetPosition == currentPosition)
        {
            moveResetZone = false;
            Debug.Log("리셋포인트에 도착했습니다.");
        }
    }

    public void GoFinishZone()  //목적지로 이동하는 메서드
    {
        speed = 2f;
        transform.position = Vector3.MoveTowards
            (transform.position, finishPosition, speed * Time.deltaTime);
        Debug.Log("목적지로 이동중!");

    }

    public void StopMove()  //정지를 관리하는 메서드
    {
        speed = 0;
        Debug.Log("충돌");

    }

    public void MadEnemy()
    {
        //콜라이더가 스코어 오브젝트 찾으면 들이 받아서 파괴하자!
        speed = 3;
        transform.Translate(finishPosition * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)  //콜라이더 충돌관리
    {
        currentPosition = transform.position;

        if (collision.gameObject.tag == "Object")
        {
            StopMove();
            moveResetZone = true;
        }

        if(collision.gameObject.tag == "ScoreObject")
        {
            MadEnemy();
        }


    }
}
