using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Complete Weighted digraph implementation to track an employee's dispositions towards the other employees
 */
public class InteractionGraph {
    public List<Stats> nodes; // the employees
    public List<Relationship> edges; // dispositions

    /**
     * Basic constructor for empty digraph
     */
    public InteractionGraph() {
        this.nodes = new List<Stats>();
        this.edges = new List<Relationship>();
    }


    /**
     * Constructor for digraph based on a list of employees
     */
    public InteractionGraph(List<Stats> employees) {
        this.nodes = employees;

        /* add edge to each employee from each employee */
        foreach (Stats src in nodes) {
            foreach (Stats tgt in nodes) {
                if(!src.Equals(tgt)) {
                    Relationship disp = new Relationship(src, tgt);
                    disp.setDisposition(src.compatiblility(tgt)); // use the compatibility function to get a base disposition
                    edges.Add(disp);
                    src.relationships.Add(disp);
                }
            }
        }
    }
    
    /**
     * Add a new node (employee) and all associated edges.
     */
    public void addNode(Stats employee) {
        foreach (Stats tgt in nodes) {
            Relationship outDisp = new Relationship(employee, tgt);
            Relationship inDisp = new Relationship(tgt, employee);
            outDisp.setDisposition(employee.compatiblility(tgt)); // use the compatibility function to get a base disposition
            outDisp.setDisposition(tgt.compatiblility(employee)); // use the compatibility function to get a base disposition
            edges.Add(outDisp);
            edges.Add(inDisp);
            employee.relationships.Add(outDisp);
            tgt.relationships.Add(inDisp);

        }
    }
    
    /**
     * remove a node (employee) and all associated edges.
     */
    public void removeNode(Stats employee) {
        if(this.nodes.Contains(employee)) {
            foreach(Relationship edge in edges) {
                if(edge.source.Equals(employee) || edge.target.Equals(employee)) { 
                    edges.Remove(edge); // remove edges to or from the employee
                }
            }

            nodes.Remove(employee);
        }
        
    }


    public List<Relationship> getEdges() {
        return this.edges;
    }


    /**
     * This method returns how all the dispositions of the other employees in relation to the 
     * inputted one
     */
    public List<Relationship> getEdgesRelatingToEmployee(Stats employee)
    {
        List<Relationship> employeeRelationships = new List<Relationship>();
        
        //Loops through all the edges to filter the source being the input
        foreach (Relationship r in edges)
        {
            if (r.source.name == employee.name)
                employeeRelationships.Add(r);

        }
        return employeeRelationships;
    }

    /**
     * Returns the number of nodes (employees) in the graph
     */ 
    public int numNodes() {
        return nodes.Count;
    }



    public class Relationship {
        public int disposition; // how much the source employee likes the target employee
        public Stats target;
        public Stats source;


        /**
         * constructor, base disposition is 0
         */
        public Relationship(Stats src, Stats tgt) {
            this.target = tgt;
            this.source = src;
            this.disposition = 0;
        }


        public void setDisposition(int disp) {
            if (disp > 25) {
                disp = 25;
            } else if (disp < 0) {
                disp = 0;
            }
            this.disposition = disp;
        }

        public void incrementDisposition(int disp) {
            this.disposition += disp;
            if (this.disposition > 25) {
                this.disposition = 25;
            } else if (this.disposition < 0) {
                this.disposition = 0;
            }
        }
    }

	
}
