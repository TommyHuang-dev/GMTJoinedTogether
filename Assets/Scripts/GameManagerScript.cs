using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    //constants
    const int ROBOT_LAYER = 6;

    public RobotControl[] robots;
    public int[] originalSources = { 0 };

    // sound control
    public SoundManager soundManager;

    // Private fields
    int activeRobotIndex = 1;

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
        // Do we have to allocate each time ?
        List<int> repeaterQueue = new List<int>();
        List<int> inactiveList = new List<int>();
        List<int> activeList = new List<int>();

        // Setup which robots are repeaters, active and inactive
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

        // Figure out which robots are active and inactive
        while (repeaterQueue.Count != 0)
        {
            int currentSource = repeaterQueue[0];
            repeaterQueue.RemoveAt(0);

            List<int> plsDelete = new List<int>();
            foreach (int robotIndex in inactiveList)
            {
                if (robots[currentSource].isInView(robots[robotIndex].transform))
                {
                    repeaterQueue.Add(robotIndex);
                    activeList.Add(robotIndex);
                    plsDelete.Add(robotIndex);
                    drawRay(currentSource, robotIndex);
                }
            }
            foreach (int robotIndex in plsDelete)
            {
                inactiveList.Remove(robotIndex);
            }
        }

        // TODO: tell each robot what it's status is
        foreach (int active in activeList)
        {
            robots[active].activate();
        }

        foreach (int inactive in inactiveList)
        {
            robots[inactive].deactivate();
        }
    }

    void drawRay(int src, int target)
    {
        // Vector3 dir = robots[robot2].transform.position - robots[robot1].transform.position;
        //Debug.DrawRay(robots[robot1].transform.position, dir, Color.white, 0.0f, false);
        robots[target].setLineEndPoint(robots[src].transform.position);
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        robots[activeRobotIndex].moveRobot(movement);
    }

    public void setActiveRobot(int i)
    {
        //if (robots[activeRobotIndex].isInView(robots[i].transform)) {
            activeRobotIndex = i;
        //}
    }

    public void loadNextLevel()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings == nextScene) { nextScene = 0; }
        SceneManager.LoadScene(nextScene);
    }
}
