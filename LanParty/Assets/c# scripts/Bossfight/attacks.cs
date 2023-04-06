using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    
    public GameObject punch, stomp, spin;
    public Animator bossAnim;

    public IEnumerator call(int i){
        Debug.Log("Attacking");
        switch (i)
        {
            case 0:  Debug.Log("Spin Attack!"); yield return StartCoroutine(Spin()); break;
            case 1:  Debug.Log("Laser Attack!"); break;
            case 2:  Debug.Log("Punch Attack!"); yield return StartCoroutine(Punch()); break;
            case 3:  Debug.Log("Yeet Attack!"); break;
            case 4:  Debug.Log("IRA DEGLI DEI! Attack!"); break;
            case 5:  Debug.Log("Stomp Attack!"); yield return StartCoroutine(Stomp()); break;

            default: break;
        }
    }

    IEnumerator Punch(){
        GameObject punchtmp = GameObject.Instantiate(punch,new Vector3(this.transform.position.x+5,this.transform.position.y-15,0),Quaternion.identity);
        yield return new WaitForSeconds(1f);
        bossAnim.SetBool("punch",true);
        yield return new WaitForSeconds(1f);
        bossAnim.SetBool("punch",false);
        Destroy(punchtmp);
    }

    IEnumerator Stomp(){
        GameObject stomptmp = GameObject.Instantiate(stomp,new Vector3(this.transform.position.x+5,this.transform.position.y+5,0),Quaternion.identity);
        yield return new WaitForSeconds(1f);
        bossAnim.SetBool("stomp",true);
        yield return new WaitForSeconds(1.5f);
        bossAnim.SetBool("stomp",false);
        Destroy(stomptmp);
    }

    IEnumerator Spin(){
        GameObject spintmp = GameObject.Instantiate(spin,new Vector3(this.transform.position.x+5,this.transform.position.y+5,0),Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        GameObject spintmp1 = GameObject.Instantiate(spin,new Vector3(this.transform.position.x+5,this.transform.position.y+5,0),Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        GameObject spintmp2 = GameObject.Instantiate(spin,new Vector3(this.transform.position.x+5,this.transform.position.y+5,0),Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        GameObject spintmp3 = GameObject.Instantiate(spin,new Vector3(this.transform.position.x+5,this.transform.position.y+5,0),Quaternion.identity);
        yield return new WaitForSeconds(1f);
        bossAnim.SetBool("spin",true);
        yield return new WaitForSeconds(1.5f);
        bossAnim.SetBool("spin",false);
        Destroy(spintmp);
        Destroy(spintmp1);
        Destroy(spintmp2);
        Destroy(spintmp3);
    }

}
