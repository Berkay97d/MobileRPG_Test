using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleBackgroundScaler : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer; 
     

    void Start()
    {
        AdjustBackgroundSize();
    }

    private void AdjustBackgroundSize()
    {
        var spriteHeight = spriteRenderer.sprite.bounds.size.y;
        var spriteWidth = spriteRenderer.sprite.bounds.size.x;
        var screenAspect = (float)Screen.width / (float)Screen.height;
        var cameraHeight = Camera.main.orthographicSize * 2;
        
        var cameraWidth = cameraHeight * screenAspect;
        
        var newScale = transform.localScale;
        
        if (cameraWidth / cameraHeight > spriteWidth / spriteHeight)
        {
            newScale = new Vector3(cameraWidth / spriteWidth, cameraWidth / spriteWidth, 1);
            transform.localScale = newScale;
            return;
        }
        
        
        newScale = new Vector3(cameraHeight / spriteHeight, cameraHeight / spriteHeight, 1);
        transform.localScale = newScale;
    }
    
    
}
