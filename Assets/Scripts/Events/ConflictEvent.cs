using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * An event which can show conflicts between employees.
 */
public class ConflictEvent : CustomEvent {
    // The stats of each current employee, used to find the likelihood of a conflict.
    List<Stats> _employees;

    public ConflictEvent(List<Stats> employeeStats) {
        _employees = employeeStats;
    }
	public override void consequence() {
        // unused atm
    }
}
