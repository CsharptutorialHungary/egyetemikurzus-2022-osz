namespace ZWPARW.Object
{
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Leltar
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Azonosito")]
        public HashSet<LeltarAzonosito> azonosito = new HashSet<LeltarAzonosito>();
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class LeltarAzonosito 
    {


        private string termekField;

        private DateTime utolsoEllenorzesField;

        private int jelenDarabszamField;

        private int kivantDarabszamField;

        private int bruttoArField;

        private int GramSulyaField;

        private uint idField;

        /// <remarks/>
        public string Termek
        {
            get
            {
                return this.termekField;
            }
            set
            {
                this.termekField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public DateTime UtolsoEllenorzes
        {
            get
            {
                return this.utolsoEllenorzesField;
            }
            set
            {
                this.utolsoEllenorzesField = value;
            }
        }

        /// <remarks/>
        public int JelenDarabszam
        {
            get
            {
                return this.jelenDarabszamField;
            }
            set
            {
                this.jelenDarabszamField = value;
            }
        }

        /// <remarks/>
        public int KivantDarabszam
        {
            get
            {
                return this.kivantDarabszamField;
            }
            set
            {
                this.kivantDarabszamField = value;
            }
        }

        /// <remarks/>
        public int BruttoAr
        {
            get
            {
                return this.bruttoArField;
            }
            set
            {
                this.bruttoArField = value;
            }
        }

        /// <remarks/>
        public int GramSulya
        {
            get
            {
                return this.GramSulyaField;
            }
            set
            {
                this.GramSulyaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }


}
