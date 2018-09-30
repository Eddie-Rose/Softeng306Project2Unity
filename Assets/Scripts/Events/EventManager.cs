using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager{

    public ProposalEvent getProposalEvent() {

        ProposalEvent pEvent = new ProposalEvent("risky Event", "quite a risky event", 1,1,0.5f);
        return pEvent;
    }
}
