using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public Animator matriz_anim;

	// Use this for initialization
	void Start () {
		
	}
	
	
    public void AnimarMatriz()
    {
        matriz_anim.SetBool("girar", true);
    }
}
