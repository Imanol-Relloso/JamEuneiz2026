using UnityEngine;

public class ChangeFlagSprite : MonoBehaviour
{
    private Sprite flagSprite;
    void Start()
    {
        flagSprite = GetComponentInParent<CatBoat>().countrySystem.countrySprite;

        transform.GetComponent<SpriteRenderer>().sprite = flagSprite;
    }
}
