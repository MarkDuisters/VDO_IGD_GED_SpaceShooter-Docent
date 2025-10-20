using UnityEngine;

public class ClipToBounds : MonoBehaviour
{
    [SerializeField] bool clipY = false;
    [SerializeField] SpriteRenderer spriteRenderer;
    Vector2 spriteBoundsExtens;

    Vector2 screenDimensions = new Vector2(Screen.width, Screen.height);
    Vector2 worldBottomLeft;
    Vector2 worldTopRight;

    void Awake()
    {
        //initialiseer onze world projection voor dat we andere code uitvoeren.
        worldBottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        worldTopRight = Camera.main.ScreenToWorldPoint(new Vector2(screenDimensions.x, screenDimensions.y));
        spriteBoundsExtens = spriteRenderer.sprite.bounds.extents;
    }

    void LateUpdate()
    {
        if (OutofBounds())
        {
            print($"yes it does, {transform.position}");
            AdjustPositionToValidPoint(transform);
        }
    }



    bool OutofBounds()
    {
        return SuperBool() != Vector4.zero;
    }
    Vector4 SuperBool()
    {
        Vector4 superBool = Vector4.zero;
        superBool.x = transform.position.x >= worldTopRight.x - spriteBoundsExtens.x ? 1f : 0f;
        superBool.y = transform.position.x <= worldBottomLeft.x + spriteBoundsExtens.x ? 1f : 0f;
        superBool.z = transform.position.y >= worldTopRight.y - spriteBoundsExtens.y ? 1f : 0f;
        superBool.w = transform.position.y <= worldBottomLeft.y + spriteBoundsExtens.y ? 1f : 0f;
        return superBool;
    }

    void AdjustPositionToValidPoint(Transform target)
    {
        // transform.position = new Vector3(worldTopRight.x, transform.position.y, 0f);
        Vector2 adjustedPostion = target.position;
        if (SuperBool().x > 0)
        {
            adjustedPostion.x = worldTopRight.x - spriteBoundsExtens.x;
        }
        if (SuperBool().y > 0)
        {
            adjustedPostion.x = worldBottomLeft.x + spriteBoundsExtens.x;
        }
        if (clipY)
        {
            if (SuperBool().z > 0)
            {
                adjustedPostion.y = worldTopRight.y - spriteBoundsExtens.y;
            }
            if (SuperBool().w > 0)
            {
                adjustedPostion.y = worldBottomLeft.y + spriteBoundsExtens.y;
            }
        }
        target.position = adjustedPostion;
    }

}
