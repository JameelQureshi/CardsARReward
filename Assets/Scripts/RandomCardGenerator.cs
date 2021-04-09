using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCardGenerator : MonoBehaviour
{

    public static RandomCardGenerator instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    public Texture2D[] cardFronts;
    public int[] cardIds;
    public MeshRenderer[] cardMeshRenderers;

    private void Start()
    {
        AssignRandomCard();
    }

    public void AssignRandomCard()
    {
        RandomUnique();
        for (int i = 0; i<cardMeshRenderers.Length;i++)
        {
            cardMeshRenderers[i].material.mainTexture = cardFronts[intArray[i]];
            cardMeshRenderers[i].transform.parent.GetComponent<AnimationEvents>().cardId = cardIds[intArray[i]];
        }
        Debug.Log("Random Assign Done!");
    }


    private int[] intArray = new int[9];

    private void RandomUnique()
    {
        for (int i = 0; i < 9; i++)
        {
            intArray[i] = i;
        }
        Shuffle(intArray);
    }

    public void Shuffle(int[] obj)
    {
        for (int i = 0; i < obj.Length; i++)
        {
            int temp = obj[i];
            int objIndex = Random.Range(0, obj.Length);
            obj[i] = obj[objIndex];
            obj[objIndex] = temp;
        }
    }
}
