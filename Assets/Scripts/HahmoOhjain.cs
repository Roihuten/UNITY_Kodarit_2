using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;

public class HahmoOhjain : MonoBehaviour
{

    public float juoksuNopeus = 3f;
    public float painoVoima = 10f;


    public float hiirenNopeus = 3f;

    public float horisontaalinenPyorinta = 0f;
    public float vertikaalinenPyorinta = 0f;
    public float maxKaannosAsteet = 60f;


    public CursorLockMode hiirenMoodi;

    private Vector3 liikesuunta = Vector3.zero;
    private CharacterController controller;
    

    void Start()
    {
        controller = GetComponent<CharacterController>();

        UnityEngine.Cursor.lockState = hiirenMoodi;

        UnityEngine.Cursor.visible = (CursorLockMode.Locked != hiirenMoodi);
    }



    void Update()
    {
        horisontaalinenPyorinta += Input.GetAxis("Mouse X") * hiirenNopeus;
        vertikaalinenPyorinta -= Input.GetAxis("Mouse Y") * hiirenNopeus;
        //Debug.Log($"asteet {horisontaalinenPyorinta}");
        vertikaalinenPyorinta = Mathf.Clamp(vertikaalinenPyorinta, -maxKaannosAsteet, maxKaannosAsteet);
        // Mathf.Clamp rajoittaa "vertikaalisen pyörinnän" max ja min lukujen väliin
        Camera.main.transform.localRotation = Quaternion.Euler(vertikaalinenPyorinta, horisontaalinenPyorinta, 0);

        //LIIKKEET! TEE LIIKKEET VALMIIKSI TÄHÄN!!
        float nopeusEteen = Input.GetAxis("Vertical");
        float nopeusSivulle = Input.GetAxis("Horizontal");
        Vector3 nopeus = new Vector3(nopeusSivulle, 0, nopeusEteen);

        nopeus = transform.rotation * nopeus;
        controller.SimpleMove(nopeus * juoksuNopeus);
    }
}
