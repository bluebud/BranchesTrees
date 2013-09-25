using System;
using System.Collections.Generic;
namespace SampleNamespace
{
    public class SampleClass
    {
        public static void Main()
        {
            Console.WriteLine("HI");
            Trunk trunk = new Trunk(12);
            
            trunk.printDetails();
            // Write hello world to the console
            System.Console.WriteLine("Hello World!");
        } // End of Main function (program statup)
    } // End of SampleClass
    
    //Tree
    // 1 trunk
    // branches 
    //sub branches
    //leaves
    public class RandOut
    {
        public RandOut()
        {
        }
        
        public int randResult(int randomInput)
        {
            Random randObj = new Random(randomInput);
            int rand = randObj.Next(1000);
            return rand;
        }
        public virtual void printDetails()
        {
        }
    }
    
    //First item created
    public class Trunk : RandOut
    {
        List<Branches> branches = new List<Branches>();
        List<int> positions = new List<int>();
        List<char> positionNames = new List<char>();
        int length; //length of the tree
        
        public Trunk(int randomInput)
        {
            //Do some random thing to position the branches.
            int rand = randResult(randomInput);
            length = rand *2;
            int randSend = rand;
            for(int i = 0; i< rand; i++)
            {
                positions.Add(i);
                positionNames.Add('B');
                branches.Add(new Branches(randSend++));
            }
        }
        
        public override void printDetails()
        {
            Console.WriteLine("1 Trunk of " + length + " length");
            for(int i=0;i<positions.Count;i++)
            {
                Console.WriteLine("Branch at position " + positions[i]);
                branches[i].printDetails();
            }
        }
    }
    
    //Branches spawn on top of trunk
    public class Branches : RandOut
    {
        List<SubBranches> subbranches = new List<SubBranches>();      
        List<Leaves> leaves = new List<Leaves>();
        List<char> positionNames = new List<char>();
        List<int> positions = new List<int>();
        int length;
        
        public Branches(int randomNumber)
        {
            //Do something with the randomNumber
            int rand = randResult(randomNumber);
            length = randomNumber%rand;
            int randomSend = rand;
            
            for(int i=0;i<rand;i++)
            {
                if(i%5 == 0)
                {
                    positions.Add(i);
                    positionNames.Add('l');   
                    leaves.Add(new Leaves(randomSend++));
                }
                else
                {
                    positions.Add(i);
                    positionNames.Add('S');
                    subbranches.Add(new SubBranches(randomSend++));
                    
                }
            }
        }
        public override void printDetails()
        {
            Console.WriteLine("Branch of length " + length);
            for(int i=0;i<positions.Count;i++)
            {
                if(positionNames[i] == 'S')
                {
                    Console.WriteLine("SubBranch at position " + positions[i]);
                    subbranches[i].printDetails();
                }
                else
                    leaves[i].printDetails();
            }
        }
    }
    
    //Sub branches spawn on top of branches
    public class SubBranches : RandOut
    {
        List<Leaves> leaves = new List<Leaves>();
        List<char> positionNames = new List<char>();
        List<int> positions = new List<int>();
        int length;
        
        public SubBranches(int randomNumber)
        {
            //Do something with the randomNumber
            int rand = randResult(randomNumber);
            length = rand%randomNumber;
            int randomSend = rand;
            
            for(int i=0;i<rand;i++)
            {
                positionNames.Add('L');
                positions.Add(i);
                leaves.Add(new Leaves(randomSend++));
            }
        }
        
        public override void printDetails()
        {
            Console.WriteLine("SubBranch of length " + length);
            for(int i=0;i<positions.Count;i++)
            {
                Console.WriteLine("Leaf at position " + positions[i]);
                leaves[i].printDetails();
            }
        }
        
    }
    
    //Leaves spawn on top of branches and subbranches
    public class Leaves : RandOut
    {
        bool largeLeaf;
        
        public Leaves(int randomNumber)
        {
            //Do something with the randomNumber
            int rand = randResult(randomNumber);
            if(rand%2 == 0)
                largeLeaf = true;
            else
                largeLeaf = false;
        }
        
        public override void printDetails()
        {
            if(largeLeaf == true)
                Console.WriteLine("LargeLeaf");
            else
                Console.WriteLine("SmallLeaf");
        }
        
    }
} // End of SampleNamespace

