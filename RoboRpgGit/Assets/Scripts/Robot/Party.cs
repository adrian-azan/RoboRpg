using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Utilities;
public class Party :Object
{
    // Start is called before the first frame update
    public Entity[] party;
    public Queue positions;
    public Entity leader;
   
    

    public Party(Entity leader, Entity test, int size)
    {
        this.leader = leader;
        positions = new Queue(40);
        party = new Entity[size]; 

        for (int i = 0; i < party.Length; i++)
        {
            party[i] = Instantiate(test,leader.transform.position,new Quaternion());
            party[i].Create();
        }
    }

    

    public void FixedUpdate()
    {
        if (Utilities.Space.DistanceFrom(positions.Back(), leader.transform.position) > .5)
        {
            
            positions.Enqueu(leader.transform.position);          
        }     

        for (int i = 0; i < party.Length; i++)
        {
            int queuePos = (positions._size/party.Length)*i;
            if (Utilities.Space.DistanceFrom(party[i], positions.At(queuePos)) > 2)
            { 
                party[i].SetDirection(positions.At(queuePos));
                party[i].SetVelocity();
            }

            else if (Utilities.Space.DistanceFrom(party[i], positions.At(queuePos)) < 1)
            {
                party[i].SetVelocity(0);
            }
        }
       

        for (int i = 0; i < positions._size; i++)
        {
       //     Debug.DrawLine(positions.At(i), positions.At(i) + new Vector3(0,10,0));
        }
    }





    public class Queue
    {
        private ArrayList _members;
        public  int _capacity {get; }
        public  int _size {get; set;}

        public Queue(int capacity)
        {
            _members = new ArrayList(capacity);
            _size = 0;
            _capacity = capacity;       
        }

        public Vector3 At(int index)
        {            
            if (index >= 0 && index < _size)
                return (Vector3)_members[index] ;
            return new Vector3() ;
        }
        public void Enqueu(Vector3 newMember)
        {
            if (_capacity > _size)
            {
                _members.Insert(0,newMember);
                _size++;
            }
            else
            {
                _members.RemoveAt(_capacity-1);
                _members.Insert(0,newMember);
            }
        }

        public void Deque()
        {
            if (_size > 0)
            {
                _members.RemoveAt(_capacity-1);
                _size--;
            }
        }

        public Vector3 Front()
        {
            if (_size > 0) 
                return (Vector3)_members[_size-1];
            return new Vector3();
        }

        public Vector3 Back()
        {
            return (_size > 0) ? (Vector3)_members[0] : new Vector3();
            
        }
    }
}
