using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(BoxCollider))]
public class MudController : MonoBehaviour {

    #region Public Properties

    public Mud mudPrefab;
    public int mudPatchesToGenerate = 300;
    public Text dirtRemainingText;

    #endregion

    #region Private Properties

    BoxCollider boxCollider;
    int numberOfMudPatchesLeft = 0;

    #endregion

    #region Unity Methods

    void Awake () {
        boxCollider = GetComponent<BoxCollider> ();
    }
    
	void Start () {
	    GenerateMud ();
        UpdateText ();
	}

    #endregion

    #region Public Methods

    public void MudPatchDestroyed () {
        numberOfMudPatchesLeft--;
        UpdateText ();
    }

    #endregion

    #region Private Methods

    void GenerateMud () {
        if (mudPrefab == null) {
            return;
        }

        Vector3 areaToGenerate = boxCollider.size;
        Vector3 positionToPlaceMud = new Vector3 (0.0f, 0.0f, -areaToGenerate.z);
        Quaternion rot = Quaternion.Euler (270.0f, 0.0f, 0.0f);

        for (int i = 0; i < mudPatchesToGenerate; i++) {
            positionToPlaceMud.x = Random.Range (-areaToGenerate.x/2.0f, areaToGenerate.x/2.0f);
            positionToPlaceMud.y = Random.Range (-areaToGenerate.y/2.0f, areaToGenerate.y/2.0f);

            Mud mud = Instantiate (mudPrefab, transform) as Mud;
            mud.transform.localPosition = positionToPlaceMud;
            mud.transform.localRotation = rot;
            mud.GetComponent<Mud> ().mudController = this;
            numberOfMudPatchesLeft++;
        }
    }

    void UpdateText () {
        if (dirtRemainingText == null) {
            return;
        }
        dirtRemainingText.text = "Dirt Remaining: " + numberOfMudPatchesLeft;
    }

    #endregion
}
