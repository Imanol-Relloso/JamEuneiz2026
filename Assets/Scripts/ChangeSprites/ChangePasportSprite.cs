using TMPro;
using UnityEngine;

public class ChangePasportSprite : MonoBehaviour
{
    [SerializeField] private TMP_Text catname, country, load;
    void Start()
    {
        transform.GetComponent<SpriteRenderer>().sprite = GetComponentInParent<CatBoat>().nameSystem.catPasport;

        catname.text = "Nombre: " + GetComponentInParent<CatBoat>().nameSystem.catName.ToString();
        country.text = "País: " + GetComponentInParent<CatBoat>().countrySystem.catCountry.ToString();
        load.text = "Cargamento: " + GetComponentInParent<CatBoat>().loadSystem.boatLoad.ToString();
    }
}
