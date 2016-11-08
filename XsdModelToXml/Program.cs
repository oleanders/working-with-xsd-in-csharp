using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XsdModelToXml
{
    class Program
    {
        static void Main(string[] args)
        {

            var arbeidstaker = new ArbeidstakerType
            {
                identifikatorer = new IdentifikatorType[]
                {
                  new IdentifikatorType() { identifikatortype = "FNR", identifikatorverdi = "12335435345" },
                  new IdentifikatorType() { identifikatortype = "RESNR", identifikatorverdi = "12335" }
                },
                fulltNavn = "Ole Olsen",
                navn = new PersonnavnType()
                {
                    fornavn = "Ole",
                    etternavn = "Olsen"
                }

            };
            
            // 1. xml serialization
            var serializer = new XmlSerializer(typeof(ArbeidstakerType));
            using (var writer = new StreamWriter(@"..\..\Models\ExampleXml\arbeidstaker-using-xml-serialization.xml"))
            {
                serializer.Serialize(writer, arbeidstaker);
            }

            // 2. data contract serialization
            var serializer2 = new DataContractSerializer(typeof(ArbeidstakerType));
            using (FileStream writer = new FileStream(@"..\..\Models\ExampleXml\arbeidstaker-using-data-contract-serialization.xml", FileMode.Create))
            {
                serializer2.WriteObject(writer, arbeidstaker);
            }
        }
    }
}
