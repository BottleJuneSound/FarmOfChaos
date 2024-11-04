using UnityEngine;
using UnityEngine.Tilemaps;

public class OpeningEnemy : MonoBehaviour
{
    public Vector3 currentPosition;
    public Vector3 finishPosition;
    

    public float speed = 2;
    //public Collider2D rangeCollider;    // �̰� ��� ���ư���? -> �ݸ���2d �� �Ǵ��� �˾ƺ���__Ȯ������! istrigger���� �۵��Ҵ�� �̰� ����� ���ư�!
    //public TilemapCollider2D waterCollider;
    
    float vx;


    void Start()
    {

        currentPosition = transform.position;

        // ������ ��ŸƮ���� Ư�������� �����ǰ� ���� 5 �ʿ� �ѹ��� ����������
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
            //Debug.Log("�ø�!");
        }
        if (vx < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            //Debug.Log("�۵��ȵǴ� �ø�!");
        }
        speed = 2f;
        transform.position = Vector3.MoveTowards
            (transform.position, finishPosition, speed * Time.deltaTime);

    }
}
