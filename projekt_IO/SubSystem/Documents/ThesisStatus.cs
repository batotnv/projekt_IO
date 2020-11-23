using System;
using System.Collections.Generic;
using System.Text;

namespace projekt_IO.SubSystem.Documents
{
    public enum ThesisStatus
    {
        NotUploaded,  //jeszcze nie wgrana do systemu
        UploadedByStudent, //wgrana do systemu po raz pierwszy
        ModifiedByStudent, //zmodyfikowana przez studenta
        ToImprove, //do zmodyfikowania 
        UnderAntiPlagarismSystem, // wyslana do systemu antyplagiatowego
        WaitingForSupervisorAcceptance, //czekajaca na akceptacje przez promotora (po otrzymaniu reportu)
        ConfirmedBySupervisor, // zatwierdzona
        ReviewedByReviewer, //zrecenzowana
        Finished, //wszystko skonczone
    }
}
