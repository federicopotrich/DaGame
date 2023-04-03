using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatematicaGameManager : MonoBehaviour
{
    public ArrayList matrix;
    public int[] row;

    public int[,] bigTable = new int[5,5];
    public GameObject [] cells;

    public Sprite [] numbers;
    // Start is called before the first frame update
    void Start()
    {
        int [,] matrix = nextBigTable();
            
        
        
    }

    private int[,] nextBigTable() {
        //preparo la tabella con i valori ordinati
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                bigTable[i,j] = i+1;
            }
        }
        
        //mescolo la tabella
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                int tmpI = Random.Range(0, 4);
                int tmpJ = Random.Range(0, 4);
                int tmp = bigTable[i,j];
                bigTable[i,j] = bigTable[tmpI,tmpJ];
                bigTable[tmpI,tmpJ] = tmp;
            }
        }
        
        int k = 0;
        for(int i = 0; i < 5; i++){
            for(int j = 0; j < 5; j++){       
                cells[k].AddComponent<cell>();
                cells[k].GetComponent<cell>().value = bigTable[i,j];
                cells[k].GetComponent<cell>().row = j;
                cells[k].GetComponent<cell>().col = i;
                cells[k].GetComponent<UnityEngine.UI.Image>().sprite = numbers[bigTable[i, j]-1];
                k++;
            }
        }
        return bigTable;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void eventMouseCellListener(){
        
    }
}


public class cell : MonoBehaviour
{
    public int col;
    public int row;
    public int value;
}