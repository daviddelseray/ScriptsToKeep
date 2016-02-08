using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScriptTimer : MonoBehaviour {

    public Text m_Timer;

    public int m_TimeMinutes;
   
    public int m_TimeSeconds;

	void Start ()
    {
        m_Timer.text = "" + m_TimeMinutes + ":" + m_TimeSeconds;
        Timer();
    }

	
	public void Timer ()
    {
        StartCoroutine(CoroutineTimer());
    }

    IEnumerator CoroutineTimer ()
    {

        while (m_TimeMinutes>=0)
        {
            
            
                while (m_TimeSeconds >= 1)
                {
                if (m_TimeSeconds <10)
                {
                    m_Timer.text = "" + m_TimeMinutes + ":" +"0"+ m_TimeSeconds;
                }
                    yield return new WaitForSeconds(1);
                    m_TimeSeconds--;
                m_Timer.text = "" + m_TimeMinutes + ":" + m_TimeSeconds;
                }

            m_TimeMinutes--;
            m_TimeSeconds = 60;
            
        }
        
        
    }
}
