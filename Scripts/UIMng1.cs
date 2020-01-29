using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMng1 : MonoBehaviour
{
    public GameObject Select;
    public GameObject AT;

    public Button done;

    //public List<Dropdown> dropDowns;
    public List<Text> TestInfos;

    private int ExIdx;
    private List<int> Counts = new List<int> { 0, 0, 0 };

    public void Update()
    {
        /*  if (dropDowns[0].value != dropDowns[1].value &&
              dropDowns[1].value != dropDowns[2].value &&
              dropDowns[2].value != dropDowns[0].value)
              done.interactable = true;
          else
              done.interactable = false;
              */
        if (Input.GetKeyDown(KeyCode.F1))
        {
            setEx(0);
        }
    }

    public void setSelect()
    {
        int idx = 0;
        foreach (var item in TestInfos)
        {
            item.text = string.Format("Test {0}\n{1}", idx + 1, Counts[idx]);
            idx++;
        }

        /*FindObjectOfType<LogWriter>().AddText(
            string.Format("실험 1 : {0}, {1}, {2} 순서로 사용자가 지정\n",
            dropDowns[0].value, dropDowns[1].value, dropDowns[2].value));*/

        bool isExpDone = false;
        Counts.ForEach((int i) => { if (i == 9) isExpDone = true; });
        if (isExpDone)
        {
            FindObjectOfType<LogWriter>().SaveText();
            //EXP DONE
        }

        //dropDowns.ForEach((Dropdown d) => { d.value = 0; });
        Select.SetActive(true);
        AT.SetActive(false);
    }

    public void setEx(int idx)
    {
        Select.SetActive(false);
        AT.SetActive(true);
        ExIdx = idx;
        FindObjectOfType<ExpInfo1>().StartExp(ExIdx, Counts[ExIdx]);
        Counts[ExIdx]++;
    }
}