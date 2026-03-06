using UnityEngine;

public class CatBoat : MonoBehaviour
{
    [Header("Errores")]
    [Tooltip("Error de nombre en el dialogo")]
    [SerializeField] private bool ErrorEnNombre;
    [Tooltip("Error de pais en el dialogo")]
    [SerializeField] private bool ErrorEnPais;
    [Tooltip("Error de pais en la bandera")]
    [SerializeField] private bool ErrorEnBandera;
    [Tooltip("Error de carga en el dialogo")]
    [SerializeField] private bool ErrorEnCarga;

    private NameSystem nameSystem;
    private CountrySystem countrySystem;
    private LoadSystem loadSystem;

    private void Start()
    {
        Generate();
    }

    private void Generate()
    {
        nameSystem = new NameSystem();
        nameSystem.SetValues(ErrorEnNombre);

        countrySystem = new CountrySystem();
        countrySystem.SetValues(ErrorEnBandera,ErrorEnPais);

        loadSystem = new LoadSystem();
        loadSystem.SetValues(ErrorEnCarga);
    }

    public bool IsValid()
    {
        return
            nameSystem.IsCorrect() &&
            countrySystem.IsCorrect() &&
            loadSystem.IsCorrect();
    }
}
