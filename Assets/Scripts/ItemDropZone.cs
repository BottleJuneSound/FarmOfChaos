using System;
using UnityEngine;

public class ItemDropZone : MonoBehaviour
{
    public GameObject ItemPrefab; // 생성할 아이템 프리팹
    public Vector3[] spawnPositions;
    public GameObject[] ItemArray;
    public int nextInex = 0;


    public void Start()
    {
        ItemArray = new GameObject[6];

    }

    private void Update()
    {
        for (int i = 0; i < spawnPositions.Length; i++)
        {

            if (ItemArray[i] == null)
            {
                ItemArray[i] = null;
                //Debug.Log(i + "");
            }
            else if (ItemArray[i] != null)
            {
                Debug.Log(i+"에 놓을 공간이 없습니다.");
            }

        }

        //GetComponent<GameManager>().GameClear(); ////모든 배열이 찼다면 게임클리어로 이동


    }
    // 아이템 생성 메소드
    public void SpawnItem()
    {
        //ItemArray = new GameObject[6];
        spawnPositions = new Vector3[]
        {
            new Vector3(1f,5.2f),
            new Vector3(0,5.2f),
            new Vector3(-1f,5.2f),
            new Vector3(1f,4.2f),
            new Vector3(0,4.2f),
            new Vector3(-1f,4.2f),
        };


        if (ItemArray[nextInex] == null)
        {
            Debug.Log(nextInex);
            Vector3 spawnPosition = spawnPositions[nextInex];
            ItemArray[nextInex] = Instantiate(ItemPrefab, spawnPosition, Quaternion.identity);
            nextInex++;

            if (nextInex >= 6)
            {

                for (int i = 0; i < spawnPositions.Length; i++)
                {

                    if (ItemArray[i] == null)
                    {
                        nextInex = i;
                        break;
                    }

                }

            }

        }

    }

}