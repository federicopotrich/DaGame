using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    
    // attacks = [laser, spin, punch, yeet, ira_degli_dei, stomp]
    public Animator bossAnim;

    public IEnumerator call(int i){
        Debug.Log("Attacking");
        switch (i)
        {
            case 0:  Debug.Log("Spin Attack!"); break;
            case 1:  Debug.Log("Laser Attack!"); break;
            case 2:  Debug.Log("Punch Attack!"); yield return StartCoroutine(Punch()); break;
            case 3:  Debug.Log("Yeet Attack!"); break;
            case 4:  Debug.Log("IRA DEGLI DEI! Attack!"); break;
            case 5:  Debug.Log("Stomp Attack!"); yield return StartCoroutine(Stomp()); break;

            default: break;
        }
    }

    IEnumerator Punch(){
        Debug.Log("Punch!");
        yield return new WaitForSeconds(1f);
        bossAnim.SetBool("punch",true);
        yield return new WaitForSeconds(1f);
        bossAnim.SetBool("punch",false);
    }

    IEnumerator Stomp(){
        Debug.Log("Stomp!");
        yield return new WaitForSeconds(1f);
        bossAnim.SetBool("stomp",true);
        yield return new WaitForSeconds(1.5f);
        bossAnim.SetBool("stomp",false);
    }

}
