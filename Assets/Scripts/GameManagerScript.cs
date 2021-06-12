using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManagerScript : MonoBehaviour
{
    //constants
    const int ROBOT_LAYER = 6;

    public RobotMovement[] robots;
    public SoundManager soundManager;
    int activeRobotIndex = 0;
    int[] originalSources = { 1 };

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < robots.Length; ++i)
        {
            robots[i].setIndex(i);
        }

        Physics2D.IgnoreLayerCollision(ROBOT_LAYER, ROBOT_LAYER);
        soundManager.startMusic();
    }

    void Update()
    {
        List<int> repeaterQueue = new List<int>();
        List<int> inactiveList = new List<int>();
        List<int> activeList = new List<int>();

        for (int i = 0; i < robots.Length; ++i)
        {
            if (originalSources.Contains(i))
            {
                repeaterQueue.Add(i);
                activeList.Add(i);
            }
            else
            {
                inactiveList.Add(i);
            }
        }

        while (repeaterQueue.Count != 0)
        {
            int currentSource = repeaterQueue[0];
            repeaterQueue.RemoveAt(0);

            foreach (int robotIndex in inactiveList)
            {
                if (robots[currentSource].isInView(robots[robotIndex].transform))
                {
                    repeaterQueue.Add(robotIndex);
                    activeList.Add(robotIndex);
                    inactiveList.Remove(robotIndex);
                }
            }
        }

        // TODO: tell each robot what it's status is
        Debug.Log("Active:");
        foreach (int active in activeList)
        {
            Debug.Log(active);
        }
        Debug.Log("Inactive:");
        foreach (int inactive in inactiveList)
        {
            Debug.Log(inactive);
        }
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        robots[activeRobotIndex].moveRobot(movement);
    }

    public void setActiveRobot(int i)
    {
        if (robots[activeRobotIndex].isInView(robots[i].transform)) {
            activeRobotIndex = i;
        }
    }
}
