using System;
using UnityEngine;

public class ItemDropZone : MonoBehaviour
{
    public GameObject ItemPrefab; // ������ ������ ������
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
                Debug.Log(i+"�� ���� ������ �����ϴ�.");
            }

        }

        //GetComponent<GameManager>().GameClear(); ////��� �迭�� á�ٸ� ����Ŭ����� �̵�


    }
    // ������ ���� �޼ҵ�
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