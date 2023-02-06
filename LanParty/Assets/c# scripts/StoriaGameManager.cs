using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoriaGameManager : MonoBehaviour
{
    public GameObject [] quesiti;
    public int [] quesitiRisolti = {-1, -1, -1}; // -1 = quesito non svolto | 0 = quesito errato | 1 = quesito corretto
    // Start is called before the first frame update
    int index = 0;
    void Start()
    {
        index = 0;
        quesiti = GameObject.FindGameObjectsWithTag("DataStoria");
    }
    // Update is called once per frame
    void Update()
    {

        Debug.Log(quesiti[index].GetComponent<storiaData>().immagine);

        GameObject.Find("ImageStoria").GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(quesiti[index].GetComponent<storiaData>().immagine);

        if(quesitiRisolti[2] != -1){
            StartCoroutine("tmp");
        }
    }
    IEnumerator tmp(){
        yield return new WaitForSeconds(2);
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameSchoolScene");
    }
    void checkAnswer(){

    }
}