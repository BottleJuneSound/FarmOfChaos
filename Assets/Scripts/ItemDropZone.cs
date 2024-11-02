using UnityEngine;

public class ItemDropZone : MonoBehaviour
{
    public GameObject ItemPrefab; // ������ ������ ������
    public Vector3[] spawnPositions;
    int nextSpawnIndex = 0;

    // ������ ���� �޼ҵ�
    public void SpawnItem()
    {
        spawnPositions = new Vector3[]
        {
            new Vector3(1f,5.2f),
            new Vector3(0,5.2f),
            new Vector3(-1f,5.2f),
            new Vector3(1f,4.2f),
            new Vector3(0,4.2f),
            new Vector3(-1f,4.2f),


        };

        // ��� ���� �ݶ��̴� ũ�⸦ ���
        //CompositeCollider2D collider = GetComponent<CompositeCollider2D>();
        //if (collider != null)

        if (nextSpawnIndex < spawnPositions.Length)
        {
            Vector3 spawnPosition = spawnPositions[nextSpawnIndex];
            //    Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            //    Random.Range(collider.bounds.min.y, collider.bounds.max.y)
            //

            Instantiate(ItemPrefab, spawnPosition, Quaternion.identity);

            nextSpawnIndex++;
            //�Ʒ� ��ø if����Ͽ� ������Ʈ �ı��Ǹ� �ε���-- �־���ҵ�!
        }
        else
        {
            Debug.Log("�� �̻� ���� ������ �����ϴ�.");
            //Ŭ���� ȭ������ �̵��ϴ� �ڵ� ����
        }

    }

}