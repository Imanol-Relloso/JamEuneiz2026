using UnityEngine;

public class ChangeCatSprite : MonoBehaviour
{
    private Sprite catSprite;
    void Start()
    {
        catSprite = GetComponentInParent<CatBoat>().nameSystem.catSprite;

        transform.GetComponent<SpriteRenderer>().sprite = catSprite;
    }
}
