using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��Ŀ�� ����
public class LockerManager : MonoBehaviour
{
    public LockerOpen[] lockers;
    public GameObject[] door;
    public float minTime;
    public float maxTime;    
    int active;    
   




    // Start is called before the first frame update
    void Start()
    {
        active = door.Length;        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(IEActiveDoor());
        }
    }

    void SuffleDoor()
    {
        //spawn.Lenght��ŭ ������ ���� index�� �����Ѵ�
        for (int i = 0; i < active; i++)
        {
            int rValue = Random.Range(0, active);
            var temp = lockers[i];
            lockers[i] = lockers[rValue];
            lockers[rValue] = temp;
        }

    }

    IEnumerator IEActiveDoor()
    {        
        SuffleDoor(); //ȣ��� �� �� �� ����    

        int count = Random.Range(1, active + 1);
        print(count);

        for (int i = 0; i < count; i++)
        {
            var locker = lockers[i];
            locker.OpenCloseRepeat();
            float activeTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(activeTime);
        }
    }

    //�� ���� ������ �����
    


}
