using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject getItem;
    public float itemShotSpeed = 10;
    public float Speed = 1;
    private Vector3 look = Vector3.down; // 기본 방향을 아래로 설정
    public GameObject scorePrefab;
    public GameObject Arrow;

    float vx = 0;
    float vy = 0;

    float itemShootCoolTime = 1f;
    float lastShotTime = 0;

    private void Awake()
    {
        if (Arrow != null)
        {
            Arrow.SetActive(false);
        }
    }

    void Start()
    {


    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        float fire = Input.GetAxisRaw("Fire1");

        vx = Input.GetAxisRaw("Horizontal") * Speed;
        vy = Input.GetAxisRaw("Vertical") * Speed;

        // 플레이어가 이동 방향을 변경하면 look을 업데이트
        if (horizontal != 0 || vertical != 0)
        {
            look = new Vector3(horizontal, vertical);
        }


        // 하나의 방향키만 허용
        if (horizontal != 0 && vertical != 0)
        {
            // 만약 둘 다 입력된 경우, 우선순위를 정해 한쪽 입력만 허용
            vy = 0;  // 여기서 vertical을 0으로 설정하면 좌우 입력이 우선됩니다.
        }

        if (fire > 0 && getItem != null && Time.time >= lastShotTime + itemShootCoolTime)
        {

            ItemShot();
            lastShotTime = Time.time;
        }


        if (getItem != null)
        {
            getItem.transform.localPosition = new Vector3(0.5f, 0, 0);

            Arrow.SetActive(true);

            // 원형 궤도를 따라 이동하는 Arrow 위치 설정
            float radius = 1.3f;  // 플레이어로부터의 거리(반지름)
            Arrow.transform.localPosition = look * radius;  // look 방향으로 일정 거리만큼 떨어져 위치 설정

            // 화살표가 항상 플레이어를 기준으로 look 방향을 가리키도록 회전
            Arrow.transform.rotation = Quaternion.LookRotation(Vector3.forward, look);

        }

        if (getItem == null)
        {
            Arrow.SetActive(false);

        }

        //GetComponent<Rigidbody2D>().linearVelocity += new Vector2(vx, vy) * Time.deltaTime;
        GetComponent<Transform>().position += new Vector3(vx, vy, 0) * Time.deltaTime;


        // 애니메이션 처리
        if (vx == 0 && vy == 0) GetComponent<Animator>().SetTrigger("PlayerIdle");
        if (vx > 0) GetComponent<Animator>().SetTrigger("PlayerSideR");
        if (vx < 0) GetComponent<Animator>().SetTrigger("PlayerSideL");
        if (vy > 0) GetComponent<Animator>().SetTrigger("PlayerUp");
        if (vy < 0) GetComponent<Animator>().SetTrigger("PlayerDown");





    }

    private void OnTriggerEnter2D(Collider2D triggerEnter)
    {
        //if (triggerEnter.gameObject.tag == "Object")
        //{
        //    Debug.Log("충돌");
        //}

        if ((triggerEnter.gameObject.tag == "Item" || triggerEnter.gameObject.tag == "Weapon") && getItem == null)
        {
            Debug.Log("아이템을 습득했다!");

            // 아이템을 플레이어의 자식 오브젝트로 설정해 들고 다니게 하기
            getItem = triggerEnter.gameObject;

            // 아이템을 플레이어의 자식으로 설정
            triggerEnter.transform.SetParent(this.transform);
            triggerEnter.transform.localPosition = new Vector3(0.5f, 0);

        }

        // 아이템을 들고 있는지 확인
        if (triggerEnter.gameObject.tag == "ItemDropZone" && getItem.gameObject.tag == "Item" && getItem != null)
        {
            Debug.Log("아이템을 드랍존에 가지고 들어옴!");

            // 아이템 스폰
            triggerEnter.GetComponent<ItemDropZone>().SpawnItem();

            // 아이템을 더 이상 들고 있지 않도록 설정
            Destroy(getItem); // 또는 getItem.SetActive(false);
            getItem = null; // 아이템 변수 초기화

            //// 새로운 오브젝트 생성
            //Instantiate(scorePrefab, transform.position + new Vector3(0,0,0), Quaternion.identity);

            //// 아이템을 플레이어의 자식에서 분리
            //getItem.transform.SetParent(null);

            //// 아이템을 더 이상 들고 있지 않도록 설정
            //Destroy(getItem); // 또는 getItem.SetActive(false);
            //getItem = null; // 아이템 변수 초기화
        }

    }

    void ItemShot()
    {
        getItem.transform.SetParent(null);

        Rigidbody2D itemRb = getItem.GetComponent<Rigidbody2D>();
        if (itemRb != null)
        {
            itemRb.linearVelocity = Vector2.zero;
            itemRb.AddForce(look * itemShotSpeed, ForceMode2D.Impulse);
        }


        getItem = null;
    }

}
