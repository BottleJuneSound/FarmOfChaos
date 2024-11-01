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

        //�������� �̵�
        if (currentPosition != finishPosition)
        {
            if (moveResetZone == false) //��ø if�� Ȱ���Ͽ� ������ �̵����̶�� �۵����� ����
            {
                GoFinishZone();
            }
        }

        //object �±� �浹�� �����ϸ� ����
        if (moveResetZone == true)
        {
            float resetSpeed = 2;
            Debug.Log("��������Ʈ�� �̵�!");

            transform.position = Vector3.MoveTowards
                (transform.position, resetPosition, resetSpeed * Time.deltaTime);
        }

        //��������Ʈ�� �����ϸ� ����
        if (resetPosition == currentPosition)
        {
            moveResetZone = false;
            Debug.Log("��������Ʈ�� �����߽��ϴ�.");
        }
    }

    public void GoFinishZone()  //�������� �̵��ϴ� �޼���
    {
        speed = 2f;
        transform.position = Vector3.MoveTowards
            (transform.position, finishPosition, speed * Time.deltaTime);
        Debug.Log("�������� �̵���!");

    }

    public void StopMove()  //������ �����ϴ� �޼���
    {
        speed = 0;
        Debug.Log("�浹");

    }

    public void MadEnemy()
    {
        //�ݶ��̴��� ���ھ� ������Ʈ ã���� ���� �޾Ƽ� �ı�����!
        speed = 3;
        transform.Translate(finishPosition * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)  //�ݶ��̴� �浹����
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
