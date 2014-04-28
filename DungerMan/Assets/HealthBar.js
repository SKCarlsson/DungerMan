var health : float;

var maxHealth : float;

 

var adjustment : float= 2.3f;

private var worldPosition : Vector3= new Vector3();

private var screenPosition : Vector3= new Vector3();

private var myTransform : Transform;

private var myCamera : Camera;

private var healthBarHeight : int= 5;

private var healthBarLeft : int= 110;

private var barTop : int= 1;

private var myStyle : GUIStyle= new GUIStyle();

private var myCam : GameObject;

myCam = GameObject.Find("Camera(Clone)"); //I removed the space from the camera's name in the Unity Inspector, so you will probably need to change this

 

function Awake() 
{

    myTransform = transform;

    myCamera = Camera.main;

    health = 50; //arbritrarily chosen values to show that this script works

    maxHealth = 100;

}

 

function OnGUI()
{

    worldPosition = new Vector3(myTransform.position.x, myTransform.position.y + adjustment,myTransform.position.z);

    screenPosition = myCamera.WorldToScreenPoint(worldPosition);

    

        GUI.color = Color.red;

        GUI.HorizontalScrollbar(Rect (screenPosition.x - healthBarLeft / 2, Screen.height - screenPosition.y - barTop, 100, 0), 0, health, 0, maxHealth); //displays a healthbar

        

        GUI.color = Color.red;

        GUI.contentColor = Color.red;                 

        GUI.Label(Rect(screenPosition.x - healthBarLeft / 2, Screen.height - screenPosition.y - barTop+5, 100, 100), ""+health+"/"+maxHealth); //displays health in text format

    

}