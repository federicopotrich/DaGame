using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    
    public GameObject punch, stomp, spin, idd;
    public Animator bossAnim;

    public IEnumerator call(int i){
        Debug.Log("Attacking");
        switch (i)
        {
<<<<<<< HEAD
            case 0:  break;
            case 1:  break;
            case 2:  break;
            case 3:  break;
            case 4:  break;
            case 5:  break;

            //default:
=======
            case 0:  Debug.Log("Spin Attack!"); yield return StartCoroutine(Spin()); break;
            case 1:  Debug.Log("Laser Attack!"); break;
            case 2:  Debug.Log("Punch Attack!"); yield return StartCoroutine(Punch()); break;
            case 3:  Debug.Log("Yeet Attack!"); break;
            case 4:  Debug.Log("IRA DEGLI DEI! Attack!"); yield return StartCoroutine(IDD()); break;
            case 5:  Debug.Log("Stomp Attack!"); yield return StartCoroutine(Stomp()); break;

            default: break;
>>>>>>> d88b26f6806a821434a40ba146acb8b364e9bf99
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
        GameObject stomptmp = GameObject.Instantiate(stomp,new Vector3(this.transform.position.x+5,this.transform.position.y-5,0),Quaternion.identity);
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

    IEnumerator IDD(){
        
        bossAnim.SetBool("iraDegliDei",true);
        yield return new WaitForSeconds(0.5f);
        GameObject iddtmp = GameObject.Instantiate(idd,new Vector3(this.transform.position.x+5,this.transform.position.y,0),Quaternion.identity);
        yield return new WaitForSeconds(1.3f);
        Destroy(iddtmp);
        yield return new WaitForSeconds(1f);
        bossAnim.SetBool("iraDegliDei",false);
    }

}
