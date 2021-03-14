using UnityEngine;


namespace povar3d
{
    public class AI : MonoBehaviour
    {

        Transform tr_Player;
        float f_RotSpeed = 3.0f, f_MoveSpeed = 2.0f;

        // Use this for initialization
        void Start()
        {

            tr_Player = GameObject.FindGameObjectWithTag("Player").transform;

        }

        // Update is called once per frame
        void Update()
        {
            /* Look at Player*/
            

            /* Move at Player*/
            if(Vector3.Distance(gameObject.transform.position, tr_Player.position) >= 2f)
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, f_MoveSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation
                                                  , Quaternion.LookRotation(tr_Player.position - transform.position)
                                                  , f_RotSpeed * Time.deltaTime);
                //transform.position += transform.forward * f_MoveSpeed * Time.deltaTime;
                //transform.GetComponent<Rigidbody>().AddForce(transform.forward * f_MoveSpeed * Time.deltaTime);
            }
        }
    }
}