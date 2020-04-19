﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoTask : MonoBehaviour
{

  public int taskNumber;


  public GameObject DoingTaskCanvas;
  public GameObject DoingTaskText;
  public GameObject DoingTaskPercent;
  public TaskBoard m_taskboard;
  private bool taskDone = false;
  private int timer = 0;
  private bool doingTask = false;
  void OnTriggerEnter(Collider other)
  {
    if (!taskDone && m_taskboard.getCurrentTaskNumber() == taskNumber && other.gameObject.tag == "Player")
    {
      DoingTaskText.GetComponent<UnityEngine.UI.Text>().text = m_taskboard.getTaskName(taskNumber);
      timer = 0;
      doingTask = true;
      DoingTaskCanvas.SetActive(true);
    }

  }
  void OnTriggerExit(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      doingTask = false;
      DoingTaskCanvas.SetActive(false);
    }

  }

  void changeTask() {
    m_taskboard.changeTaskboardText(2);
  }
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void FixedUpdate()
  {
    if(doingTask) {
      timer++;
      DoingTaskPercent.GetComponent<UnityEngine.UI.Text>().text = (timer / 3).ToString() + "%";
      if(timer > 300) {
        taskDone = true;
        m_taskboard.nextTask();
        doingTask = false;
        DoingTaskPercent.GetComponent<UnityEngine.UI.Text>().text = "Complete!";
      }
    }
  }
}