using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MasterClassExtensionMethod
{
    public class DebugCodes : MonoBehaviour
    {
        /// <summary>
        /// For this function we need to call it from update, and it draws a line between two points on scene view
        /// </summary>
        /// <param name="startPoint"></param>
        /// <param name="EndPoint"></param>
        /// <param name="color"></param>
        public static void DrawLineBetweenTwoObjects(Vector3 startPoint, Vector3 EndPoint, Color color)
        {
            Debug.DrawRay(startPoint, EndPoint, color);
        }
        public static void DrawLineBetweenTwoObjects(Vector2 startPoint, Vector2 EndPoint, Color color)
        {
            Debug.DrawRay(startPoint, EndPoint, color);
        }

    }

    public class PhysicCodes : MonoBehaviour
    {
        public class Movements : MonoBehaviour
        {
            /// <summary>
            /// Uses unity move towerds to move, does not use rigidbody, needs to be called on update
            /// </summary>
            /// <param name="objectToMove_"></param>
            /// <param name="endPos_"></param>
            /// <param name="speed_"></param>
            public static void MoveTowards(GameObject objectToMove_, Vector3 endPos_, float speed_)
            {
                objectToMove_.transform.position = Vector3.MoveTowards(objectToMove_.transform.position, endPos_, Time.deltaTime * speed_);
            }
            /// <summary>
            /// Uses unity move towerds to move, does not use rigidbody, needs to be called on update
            /// </summary>
            /// <param name="objectToMove_"></param>
            /// <param name="endPos_"></param>
            /// <param name="speed_"></param>
            public static void MoveTowards2D(GameObject objectToMove_, Vector2 endPos_, float speed_)
            {
                objectToMove_.transform.position = Vector2.MoveTowards(objectToMove_.transform.position, endPos_, Time.deltaTime * speed_);
            }
            /// <summary>
            /// moves the object to a position by using lerp, needs to be called on update
            /// </summary>
            /// <param name="objectToMove_"></param>
            /// <param name="endPos_"></param>
            /// <param name="speed_"></param>
            public static void Lerp(GameObject objectToMove_, Vector3 endPos_, float speed_)
            {
                objectToMove_.transform.position = Vector3.Lerp(objectToMove_.transform.position, endPos_, Time.deltaTime * speed_);
            }
            /// <summary>
            /// moves the object to a position by using lerp, needs to be called on update
            /// </summary>
            /// <param name="objectToMove_"></param>
            /// <param name="endPos_"></param>
            /// <param name="speed_"></param>
            public static void Lerp2D(GameObject objectToMove_, Vector2 endPos_, float speed_)
            {
                objectToMove_.transform.position = Vector2.Lerp(objectToMove_.transform.position, endPos_, Time.deltaTime * speed_);
            }
            /// <summary>
            /// Uses move position ( basically moves to the position you add, if you add (0,0,1) it will increase 1 z per second), objectToMove parameter needs a rigidbody, needs to be called on update
            /// </summary>
            /// <param name="objectToMove_"></param>
            /// <param name="endPos_"></param>
            /// <param name="speed_"></param>
            public static void MovePositionRigidBody(GameObject objectToMove_, Vector3 forceToAdd, float speed_)
            {
                objectToMove_.GetComponent<Rigidbody>().MovePosition(objectToMove_.transform.position + forceToAdd * Time.deltaTime * speed_);
            }
            /// <summary>
            /// Uses move position ( basically moves to the position you add, if you add (0,0,1) it will increase 1 z per second), objectToMove parameter needs a rigidbody, needs to be called on update
            /// </summary>
            /// <param name="objectToMove_"></param>
            /// <param name="endPos_"></param>
            /// <param name="speed_"></param>
            public static void MovePositionRigidBody2D(GameObject objectToMove_, Vector2 forceToAdd, float speed_)
            {
                objectToMove_.GetComponent<Rigidbody2D>().MovePosition(new Vector2(objectToMove_.transform.position.x, objectToMove_.transform.position.y) + forceToAdd * Time.deltaTime * speed_);
            }
        }

        public class Collisions : MonoBehaviour
        {
            public delegate void FunctionToBeCalledWhenObjectCollided();
            public static void CheackIfCollidedWithObject (FunctionToBeCalledWhenObjectCollided functionToCall)
            { //este codigo esta no projeto master class no pc ingles, ta a funcionar la mas aqui n
              }
        }
    }

    public class RecallFunctionWhenSomethingHappen
    {
        public delegate void FunctionToBeCalledWhenTimePassed();

        public static IEnumerator WaitSecondsThenReturn(FunctionToBeCalledWhenTimePassed functionToCall, float timeToWait)
        {
            

            //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(timeToWait);

            functionToCall();
            
        }

        
    }

    public class MathematicalReturnsCodes : MonoBehaviour
    {
        /// <summary>
        /// Returns a float that is the distance between 2 objects
        /// </summary>
        /// <param name="startPos"></param>
        /// <param name="endPos"></param>
        /// <returns>Float</returns>
        public static float DistanceBetweenTwoObjects(Vector3 startPos, Vector3 endPos)
        {
            return Vector3.Distance(startPos, endPos);
        }
        public static float DistanceBetweenTwoObjects(Vector2 startPos, Vector2 endPos)
        {
            return Vector3.Distance(startPos, endPos);
        }
    }

    public class IfChecksCodes : MonoBehaviour
    {
        /// <summary>
        /// if the object sended is being rendered by a camera it will return true, it will be true if the scene is looking at him, so this works better when built
        /// </summary>
        /// <param name="objectToCheckIfItsRendered"></param>
        /// <returns></returns>
        public static bool VisibleOnCamera(GameObject objectToCheckIfItsRendered)
        {
            if (objectToCheckIfItsRendered.GetComponent<Renderer>().isVisible)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


}