using System;
using System.Collections.Generic;

namespace CreaBloc2
{
    //classe des composants du bloc
    class ElemBlocs
    {
        private String id;
        private String référence;
        private String designation;
        private String nomFichier;
        private bool obsolète;

        //constructeur
        public ElemBlocs(string id, string référence, string repère, String nomFichier, bool obsolète )
        {
            this.id = id;
            this.référence = référence;
            this.designation = repère;
            this.nomFichier = nomFichier;
            this.obsolète = obsolète;         
        }

        //getters
        public string getId() { return this.id; }
        public String getRef() { return this.référence; }
        public String  getDesignation() { return this.designation; }
        public String getNomFichier() { return this.nomFichier; }
        public bool getObsolète() { return this.obsolète; }

        //Setters
        public void setId(String newId) { this.id = newId; }
        public void setRef(String newRef) { this.référence = newRef; }
        public void setDesignation(String newDesigna) { this.designation = newDesigna; }
        public void setNomFichier(String newNom) { this.nomFichier = newNom; }
        public void setObsolète(bool newBool) { this.obsolète = newBool; }
       

    }

    //Classe du bloc
    class Blocs
    {
        
        private String id;
        private String réfBlock;
        private String num;
        private String repère;
        private String refComp;

        //constructeur
        public Blocs(string id, string réfBlock, string num, string repère, string refComp)
        {
            this.id = id;
            this.réfBlock = réfBlock;
            this.num = num;
            this.repère = repère;
            this.refComp = refComp;
        }

        //getters
        public string getId() { return this.id; }
        public String getRef() { return this.réfBlock; }
        public String getNum() { return this.num; }
        public String getRepère() { return this.repère; }
        public String getRefComp() { return this.refComp; }

        //Setters
        public void setId(String values) { this.id = values; }
        public void setRef(String values) { this.id = values; }
        public void setNum(String values) { this.id = values; }
        public void setRepère(String values) { this.id = values; }
        public void setRefComp(String values) { this.id = values; }


    }
}


