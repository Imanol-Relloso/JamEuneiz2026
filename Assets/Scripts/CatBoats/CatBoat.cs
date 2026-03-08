using UnityEngine;
using UnityEngine.EventSystems;

public class CatBoat : MonoBehaviour
{
    [Header("ERRORES DE NOMBRE")]
    [Tooltip("Error de nombre en el dialogo")]
    [SerializeField] public bool ErrorEnNombre;
    [Tooltip("Error el nombre del gato esta en la blacklist")]
    [SerializeField] public bool ErrorGatoNoPermitido;
    [Header("ERRORES DE PAIS")]
    [Tooltip("Error de pais en el dialogo")]
    [SerializeField] public bool ErrorEnPais;
    [Tooltip("Error de pais en la bandera")]
    [SerializeField] public bool ErrorEnBandera;
    [Tooltip("Error de pais no permitido")]
    [SerializeField] public bool ErrorEnPaisPermitido;
    [Header("ERRORES DE CARGA")]
    [Tooltip("Error de carga en el dialogo")]
    [SerializeField] public bool ErrorEnCarga;
    [Tooltip("Error de carga no permitida")]
    [SerializeField] public bool ErrorCargaNoPermitida;

    private NameSystem nameSystem;
    private CountrySystem countrySystem;
    private LoadSystem loadSystem;

    private void Start()
    {
        Generate();

        Debug.Log(IsValid());
        Debug.Log(nameSystem.catName);
        Debug.Log(nameSystem.dialogueName);
    }

    private void Generate()
    {
        nameSystem = new NameSystem();
        countrySystem = new CountrySystem();
        loadSystem = new LoadSystem();

        nameSystem.UpdateDayConditions();
        countrySystem.UpdateDayConditions();
        loadSystem.UpdateDayConditions();

        nameSystem.SetValues(ErrorEnNombre, ErrorGatoNoPermitido);
        countrySystem.SetValues(ErrorEnBandera,ErrorEnPais, ErrorEnPaisPermitido);
        loadSystem.SetValues(ErrorEnCarga, ErrorCargaNoPermitida);
    }

    public bool IsValid()
    {
        return
            nameSystem.IsCorrect() &&
            countrySystem.IsCorrect() &&
            loadSystem.IsCorrect();
    }
}
