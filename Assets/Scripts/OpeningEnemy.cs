using UnityEngine;
using UnityEngine.Tilemaps;

public class OpeningEnemy : MonoBehaviour
{
    public Vector3 currentPosition;
    public Vector3 finishPosition;
    

    public float speed = 2;
    //public Collider2D rangeCollider;    // 이거 없어도 돌아가네? -> 콜리전2d 왜 되는지 알아보기__확인했음! istrigger없이 작동할대는 이거 없어두 돌아감!
    //public TilemapCollider2D waterCollider;
    
    float vx;


    void Start()
    {

        currentPosition = transform.position;

        // 포지션 스타트에서 특정값으로 고정되고 있음 5 초에 한번씩 리셋해주자
        finishPosition = new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(3.5f, 5.8f));

        vx = transform.position.x;
        InvokeRepeating("SetRandomPosition", 5f, 3f);
    }

    public void SetRandomPosition()
    {
        finishPosition = new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(3.5f, 5.8f));

    }

    void Update()
    {
        currentPosition = transform.position;
        vx = transform.localPosition.x;
        //finishPosition = new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(3.5f, 5.8f));


        if (vx > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            //Debug.Log("플립!");
        }
        if (vx < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            //Debug.Log("작동안되는 플립!");
        }
        speed = 2f;
        transform.position = Vector3.MoveTowards
            (transform.position, finishPosition, speed * Time.deltaTime);

    }
}
