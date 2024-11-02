using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyController : MonoBehaviour
{
    public Vector3 currentPosition;
    public Vector3 finishPosition;
    public Vector3 resetPosition;

    public float speed = 2;
    //public Collider2D rangeCollider;    // 이거 없어도 돌아가네? -> 콜리전2d 왜 되는지 알아보기__확인했음! istrigger없이 작동할대는 이거 없어두 돌아감!
    //public TilemapCollider2D waterCollider;
    bool moveResetZone;
    float vx;


    void Start()
    {

        currentPosition = transform.position;

        // 포지션 스타트에서 특정값으로 고정되고 있음 5 초에 한번씩 리셋해주자
        finishPosition = new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(3.5f, 5.8f));
        resetPosition = new Vector2(Random.Range(-1, 1.9f), Random.Range(-10, -11));

       vx = transform.position.x;

        InvokeRepeating("SetRandomPosition", 5f, 3f);
    }

    public void SetRandomPosition()
    {
        finishPosition = new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(3.5f, 5.8f));
        resetPosition = new Vector2(Random.Range(-1, 1.9f), Random.Range(-10, -11));
        //Debug.Log(finishPosition);
        //Debug.Log(resetPosition);
    }

    void Update()
    {
        currentPosition = transform.position;
        vx = transform.localPosition.x;

        if (vx > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            //Debug.Log("플립!");
        }
        if(vx < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            //Debug.Log("작동안되는 플립!");
        }

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
            //Debug.Log("리셋포인트로 이동!");

            transform.position = Vector3.MoveTowards
                (transform.position, resetPosition, resetSpeed * Time.deltaTime);
        }

        //리셋포인트에 도착하면 정지
        if (resetPosition == currentPosition)
        {
            moveResetZone = false;
            //Debug.Log("리셋포인트에 도착했습니다.");
        }

    }



    public void Hit()
    {

        //Destroy(gameObject);
        speed = 0;
        // 안멈추넹.... 여튼 이자리에 죽는 애니메이션 or효과 넣으셈!
        Invoke("DestroyThis", 3f);
    }

    public void DestroyThis()
    {
        Destroy(gameObject);
    }

    public void GoFinishZone()  //목적지로 이동하는 메서드
    {
        speed = 2f;
        transform.position = Vector3.MoveTowards
            (transform.position, finishPosition, speed * Time.deltaTime);
        //Debug.Log("목적지로 이동중!");

    }

    public void StopMove()  //정지를 관리하는 메서드
    {
        speed = 0;
        Debug.Log("충돌");

    }


    private void OnCollisionEnter2D(Collision2D collision)  // 오브젝트 자체의 충돌관리. 농장 파괴. 사용법 몰라서 트리거 엔터로 반영되었슴...
    {
        currentPosition = transform.position;

    }

    private void OnTriggerEnter2D(Collider2D collider)  //isTrigger의 충돌관리
    {
        currentPosition = transform.position;

        if (collider.gameObject.tag == "Object")
        {
            StopMove();
            moveResetZone = true;
        }

        if (collider.gameObject.tag == "Bullet" || collider.gameObject.tag == "ScoreObject")
        {
            Debug.Log("아이템이 적에게 맞았다.");
            DestroyThis();

            collider.GetComponent<Item>().DestroyItem();
        }

        //if (collider.gameObject.tag == "ScoreObject")
        //{
        //    DestroyThis();
        //    collider.GetComponent<Item>().DestroyItem();
        //}

    }


}
