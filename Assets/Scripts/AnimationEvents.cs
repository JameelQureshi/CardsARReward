using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public Material backMaterial;
    public MeshRenderer meshRenderer;
    public static bool canClick = false;
    public int cardId;
    private Material oldMaterial;

    public void OnRotationDone()
    {
        oldMaterial = meshRenderer.material;
        meshRenderer.material = backMaterial;
    }

    private void OnMouseDown()
    {
        if (!canClick)
        {
            return;
        }
        AnimationController.instance.OnCardClicked(cardId);
    }

    public void RestoreFront()
    {
        meshRenderer.material = oldMaterial;
    }

    public void OnCardClickAnimation()
    {
        
        // meshRenderer.material = AnimationController.instance.GetRandomMaterial(cardId);
    }
}
