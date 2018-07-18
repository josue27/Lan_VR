using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Jugador_Network : NetworkBehaviour
{

    // Use this for initialization
    public GameMaster master;
    void Start()
    {

    }
    public override void OnStartLocalPlayer()
    {
        print("Jugador: " + this.transform.name + " conectado");
    }
    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)//Si no es el jugador local, para
        {
            return;
        }
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RpcEmpezarJuego();
        }
    }

    [ClientRpc]
    void RpcEmpezarJuego()
    {

        master = GameObject.FindGameObjectWithTag("gameMaster").GetComponent<GameMaster>();
        master.AnimarMatriz();
        StartCoroutine(TerminoAnimacion());
    }
    IEnumerator TerminoAnimacion()
    {
        yield return new WaitForSeconds(3.0f);
        RpcReiniciarJuego();
    }
    [Command]
    void CmdReiniciarJuego()// SI no funcion intentar con RPC
    {
        // SceneManager.LoadScene(1);
        NetworkManager.singleton.ServerChangeScene("Loby_espera_01");

    }
    [ClientRpc]
    void RpcReiniciarJuego()// SI no funcion intentar con RPC
    {
        // SceneManager.LoadScene(1);
        NetworkManager.singleton.ServerChangeScene("Loby_espera_01");
        // NetworkManager.networkSceneName;
    }// NetworkManager.networkSceneName;
}

