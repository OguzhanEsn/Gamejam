using UnityEngine;


[CreateAssetMenu(fileName = "PatientInteract", menuName = "Interactions/PatientInteract")]
public class PatientInteract : Interactions
{

    public string typeText = "Patient";

    private Patient _patient;

    public override void Activate(GameObject go, HudHandler hudHandler)
    {
        Debug.Log("Interacting with Patient");
    }

    public override void Deactivate(GameObject go, HudHandler hudHandler)
    {
        hudHandler.DeactivateElement();
    }

    public override void ShowInteractUI(GameObject go, HudHandler hudHandler)
    {

        //itemText = "Patient";
        _patient = go.GetComponent<Patient>();

        if(_patient.ContractType == ContractType.None)
            typeText = "Patient";
        else{
            typeText = _patient.ContractType.ToString() + " Contract";
            }

        if(_patient.IsDead)
        {
            typeText = "Dead";
        }
        if (_patient.IsPoisoned)
        {
            typeText = "Poisoned";
        }
 
        hudHandler.ActivateHudElement
        (UIElements.InteractableUI, go.transform, 1.0f, typeText, _patient.patientInfo.nameText);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
