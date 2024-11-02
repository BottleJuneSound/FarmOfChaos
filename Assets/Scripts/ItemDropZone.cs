using UnityEngine;

public class ItemDropZone : MonoBehaviour
{
    public GameObject ItemPrefab; // 생성할 아이템 프리팹
    public Vector3[] spawnPositions;
    int nextSpawnIndex = 0;

    // 아이템 생성 메소드
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

        // 드랍 존의 콜라이더 크기를 얻기
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
            //아래 중첩 if사용하여 오브젝트 파괴되면 인덱스-- 넣어야할듯!
        }
        else
        {
            Debug.Log("더 이상 놓을 공간이 없습니다.");
            //클리어 화면으로 이동하는 코드 구현
        }

    }

}