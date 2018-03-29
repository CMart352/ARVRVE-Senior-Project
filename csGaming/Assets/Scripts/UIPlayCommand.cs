using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine;

public class UIPlayCommand : MonoBehaviour
{
    UIButtonClick btnInstance;
    WhileCommand whileInstance;
    GameObject Player;
    public Transform target;
	public Button submit;
	public Button clear;
	GameObject[] editBtn; 

	//Mairim
    //public Button playButton;
	//public Transform solutionPanel;
	//public GameObject player;
	//Vector3 originalPos;

    public Rigidbody playerRigidbody;
    public Animator anim;

    public List<List<string>> methodLoopCommands = new List<List<string>>();
    public List<int> methodLoopCount = new List<int>();

    int floormask;
    int loopCount;
    float camRayLength = 100f;

    private float moveSpeed = 3f;
    private float gridSize = 1f;

    private enum Orientation
    {
        Horizontal,
        Vertical
    };
    private Orientation gridOrientation = Orientation.Horizontal;
    private bool isMoving = false;
    private bool Lock = false;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector2 input;
    private float haxis;
    private float vaxis;
    private float t;
    private List<string> whileList = new List<string>();

    private float rotation = 0f;
    private Quaternion qTo = Quaternion.identity;

    // Use this for initialization
    void Start()
    {
        floormask = LayerMask.GetMask("Floor");

        Player = GameObject.FindGameObjectWithTag("Player");
        // playerRigidbody = GetComponent<Rigidbody>();

        //Button btn = playButton.GetComponent<Button>();
        btnInstance = GetComponent<UIButtonClick>();
        whileInstance = GetComponent<WhileCommand>();

        //btn.onClick.AddListener(TaskOnClick);

		//store original position of player
		//originalPos = player.transform.position;

    }

    void Animating(float h, float v)
    {
        bool walking = (h != 0 || v != 0);

        anim.SetBool("Moving", walking);
    }


    public void TaskOnClick()
    {
       /* 
   		print("Play button pressed!");
		/*If user had previously clicked the play Button, return player to original position and 
		 * clear commandList so that when user clicks it again, commands are not duplicated
		 
		if (btnInstance.commandList.Count == 0) {  //Solution Panel is empty, add commands to the list
			foreach (Transform child in solutionPanel) {
				if (child.name != "Command") { //Original prefab gets ignored
					btnInstance.commandList.Add (child.name);
				}
			StartCoroutine (Execute ());
			}
		} else { //Solution panel has commands, return to original position, and retry 
			btnInstance.commandList.Clear();
			//Move player to its original position
			player.transform.position = originalPos;
			TaskOnClick ();
		}

		*/
	
	foreach (string command in btnInstance.commandList) {
			Debug.Log (command);
		}
		StartCoroutine (Execute ());

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*if (btnInstance.methodActive || btnInstance.whileActive)
        {
            playButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            playButton.GetComponent<Button>().interactable = true;
        }*/

        if (!isMoving)
        {
            Animating(0, 0);
            input = new Vector2(haxis, vaxis);

            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            {
                input.y = 0;
            }
            else
            {
                input.x = 0;
            }

            if (input != Vector2.zero)
            {
                StartCoroutine(Move(Player.transform));
            }
        }
        else
        {
            Animating(1, 0);
        }
    }

    public IEnumerator Execute()
    {
        foreach (string command in btnInstance.commandList)
        {
            if (command.Equals("MoveLeft()"))
            {
                Debug.Log("moveLeft command issued.");
                haxis += -1;
                vaxis += 0;
                yield return new WaitForSeconds(1f);
            }
            else if (command.Equals("MoveRight()"))
            {
                haxis += 1;
                vaxis += 0;
                yield return new WaitForSeconds(1f);
            }
            else if (command.Equals("MoveUp()"))
            {
                haxis += 0;
                vaxis += 1;
                yield return new WaitForSeconds(1f);
            }
            else if (command.Equals("MoveDown()"))
            {
                haxis += 0;
                vaxis += -1;
                yield return new WaitForSeconds(1f);
            }
            else if (command.Equals("while()"))
            {
                yield return StartCoroutine(ExecuteLoop());
            }
            else
            {
                print("method found " + command);
                yield return StartCoroutine(ExecuteMethod(command));
            }
        }

        btnInstance.i = 0;
        btnInstance.commandList.Clear();

		/* Enable all controls */
		submit.interactable = true;
		clear.interactable = true; 

		editBtn = GameObject.FindGameObjectsWithTag ("Edits");

		foreach (GameObject btn in editBtn) {
			btn.GetComponent<Button>().interactable = true;
		}

        yield return new WaitForFixedUpdate();
    }

    public IEnumerator ExecuteLoop()
    {
        int i = 0;
        whileList = btnInstance.jaggedWhileList[0];
        loopCount = whileInstance.listCount[0];
        print("Before loop n = " + loopCount);
        while (i < loopCount)
        {
            print("IN loop");
            foreach (string command in btnInstance.jaggedWhileList[0])
            {
                print("current command = " + command);
                if (command.Equals("moveLeft()"))
                {
                    Debug.Log("moveLeft command issued.");
                    haxis += -1;
                    vaxis += 0;
                    yield return new WaitForSeconds(1f);
                }
                else if (command.Equals("moveRight()"))
                {
                    haxis += 1;
                    vaxis += 0;
                    yield return new WaitForSeconds(1f);
                }
                else if (command.Equals("moveUp()"))
                {
                    haxis += 0;
                    vaxis += 1;
                    yield return new WaitForSeconds(1f);
                }
                else if (command.Equals("moveDown()"))
                {
                    haxis += 0;
                    vaxis += -1;
                    yield return new WaitForSeconds(1f);
                }
                else
                {
                    print("Method found");
                    yield return StartCoroutine(ExecuteMethod(command));
                }
                /* else if (command.Equals("while()"))
                 {
                     StartCoroutine(ExecuteLoop());
                     yield return new WaitForSeconds((btnInstance.k) * whileInstance.n + 1);
                 }*/
            }
            i++;
        }
        btnInstance.jaggedWhileList.RemoveAt(0);
        whileInstance.listCount.RemoveAt(0);
        /*for(int j = 0; j < btnInstance.whileList.Length; j++)
        {
            btnInstance.whileList[j] = "";
        }*/

        yield return null;
    }

    public IEnumerator ExecuteMethod(string methodName)
    {
        List<string> commands = btnInstance.jaggedMethodList[methodName];

        foreach (string command in commands)
        {
            if (command.Equals("moveLeft()"))
            {
                Debug.Log("moveLeft command issued.");
                haxis += -1;
                vaxis += 0;
                yield return new WaitForSeconds(1f);
            }
            else if (command.Equals("moveRight()"))
            {
                haxis += 1;
                vaxis += 0;
                yield return new WaitForSeconds(1f);
            }
            else if (command.Equals("moveUp()"))
            {
                haxis += 0;
                vaxis += 1;
                yield return new WaitForSeconds(1f);
            }
            else if (command.Equals("moveDown()"))
            {
                haxis += 0;
                vaxis += -1;
                yield return new WaitForSeconds(1f);
            }
            else if (command.Equals("while()"))
            {
                yield return StartCoroutine(ExecuteMethodLoop(methodName));
            }
        }
        yield return null;
    }

    public IEnumerator ExecuteMethodLoop(string methodName)
    {

        int i = 0;
        if (methodLoopCommands.Count == 0)
        {
            foreach (MethodLoopParameters command in btnInstance.jaggedMethodLoopList)
            {
                if (command.MethodName == methodName)
                {
                    methodLoopCommands.Add(command.LoopCommands);
                    methodLoopCount.Add(command.LoopCount);
                }
            }
        }
        List<string> currentCommand = methodLoopCommands[0];
        int currentLoopCount = methodLoopCount[0];

        foreach (string s in currentCommand)
        {
            print("Current loop count = " + currentLoopCount);
            while (i < currentLoopCount)
            {
                print("command is " + s);
                if (s.Equals("moveLeft()"))
                {
                    haxis += -1;
                    vaxis += 0;
                    yield return new WaitForSeconds(1f);
                }
                else if (s.Equals("moveRight()"))
                {
                    haxis += 1;
                    vaxis += 0;
                    yield return new WaitForSeconds(1f);
                }
                else if (s.Equals("moveUp()"))
                {
                    haxis += 0;
                    vaxis += 1;
                    yield return new WaitForSeconds(1f);
                }
                else if (s.Equals("moveDown()"))
                {
                    haxis += 0;
                    vaxis += -1;
                    yield return new WaitForSeconds(1f);
                }
                i++;
            }
        }

        methodLoopCommands.RemoveAt(0);
        methodLoopCount.RemoveAt(0);

        yield return null;
    }

    public IEnumerator Move(Transform transform)
    {
        isMoving = true;

        startPosition = playerRigidbody.transform.position;
        t = 0;

        if (gridOrientation == Orientation.Horizontal)
        {
            endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
                startPosition.y, startPosition.z + System.Math.Sign(input.y) * gridSize);
        }
        else
        {
            endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
               startPosition.y + System.Math.Sign(input.y) * gridSize, startPosition.z);
        }

        playerRigidbody.transform.LookAt(endPosition);

        while (t < 1f)
        {
            t += Time.deltaTime * (moveSpeed / gridSize);

            playerRigidbody.transform.position = Vector3.Lerp(startPosition, endPosition, t);

            yield return null;
        }

        isMoving = false;
        Lock = false;
        haxis = 0;
        vaxis = 0;
        yield return 0;

    }

    //Work in progress
    void Turning()
    {

        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floormask))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            // Set the player's rotation to this new rotation.
            playerRigidbody.MoveRotation(newRotation);
        }
    }
}