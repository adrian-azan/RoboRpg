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
   
    public float buffer = .2f;
    

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

         for (int i = 0; i < positions.Size(); i++)
        {
             positions.Enqueu(leader.transform.position);       
        }
    }

    

    public void FixedUpdate()
    {
        if (Utilities.Space.DistanceFrom(leader,positions.Back()) > .5)
        {            
            positions.Enqueu(leader.transform.position);          
        }     

        for (int i = 0; i < party.Length; i++)
        {           
            int queuePos = ((int)(positions.Size()*buffer)/party.Length) * i;
            queuePos += (int)(positions.Size()*buffer);
            if (Utilities.Space.DistanceFrom(party[i], positions.At(queuePos)) > 3)
            { 
                party[i].entityController.SetDirection(positions.At(queuePos));
                party[i].entityController.SetVelocity();
            }

            else if (Utilities.Space.DistanceFrom(party[i], positions.At(queuePos)) < 2)
            {
                party[i].entityController.SetVelocity(0);
            }
        }       

        for (int i = 0; i < (int)positions.Size()*buffer; i++)
        {
            Debug.DrawLine(positions.At(i), positions.At(i) + new Vector3(0,10,0),Color.red);
        }

        for (int i = (int)(positions.Size()*buffer); i < positions.Size(); i++)
        {
            Debug.DrawLine(positions.At(i), positions.At(i) + new Vector3(0,10,0),Color.blue);
        }
    }





    public class Queue
    {
        private ArrayList _items;        
        public Queue(int capacity)
        {
            _items = new ArrayList(capacity);
            
            for (int i = 0; i < capacity;i++)
            {
                _items.Add(new Vector3());
            }
        }

        public int Size()
        {
            return _items.Count;
        }

        public Vector3 At(int index)
        {            
            if (index >= 0 && index < _items.Count)
                return (Vector3)_items[index] ;
            return new Vector3() ;
        }
        public void Enqueu(Vector3 newItem)
        {           
            Dequeu();
            _items.Insert(0,newItem);           
        }

        public void Dequeu()
        {            
            _items.RemoveAt(_items.Count-1);            
        }

        public Vector3 Front()
        {           
            return (Vector3)_items[_items.Count-1];           
        }

        public Vector3 Back()
        {
            return (Vector3)_items[0];            
        }
    }
}
