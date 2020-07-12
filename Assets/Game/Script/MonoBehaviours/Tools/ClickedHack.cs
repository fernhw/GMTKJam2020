

using UnityEngine;

public class ClickedHack : MonoBehaviour
{
    public string idString;
    public string objectIdentifier;
    public TypeOfTarget type;

    GameRunner mainBehaviour;

    void Start()
    {
        mainBehaviour = ( GameRunner )FindObjectOfType(typeof(GameRunner));
    }

    private void OnMouseDown () {
        mainBehaviour.ClickedData(idString, type, this);
    }

}

public enum TypeOfTarget {
    UI,
    UI_INVENTORY,
    ITEM,
    FIXER
}
