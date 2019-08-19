using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using System.Text.RegularExpressions;
using Newtonsoft;
using Json.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ZOO_Animal_classification
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class Animal
        {
            private int hair, feathers, eggs, milk, airborne, aquatic, predator, toothed, backbone, breathes, venomous, fins, tail, domestic, catsize;
            private int legs;
            public Animal()
                {
                hair= 1;
                feathers = 0;
                eggs = 0;
                milk = 1;
                airborne = 0;
                aquatic = 0;
                predator = 1;
                toothed = 1;
                backbone = 1;
                breathes = 1;
                venomous = 0;
                fins = 0;
                tail = 0;
                domestic = 0;
                catsize = 1;
                legs = 4;
                }
            public Animal(int Hair,int Feathers, int Eggs,int Milk,int Airborne,int Aquatic,int Predator,int Toothed,int Backbone,int Breathes,int Venomous,int Fins,int Tail,int Domestic,int Catsize, int Legs )
            {
                hair = Hair;
                feathers = Feathers;
                eggs = Eggs;
                milk = Milk;
                airborne = Airborne;
                aquatic = Aquatic;
                predator = Predator;
                toothed = Toothed;
                backbone = Backbone;
                breathes = Breathes;
                venomous = Venomous;
                fins = Fins;
                tail = Tail;
                domestic = Domestic;
                catsize =Catsize;
                legs = Legs;
            }
            public int gethair()
            {
                return this.hair;
            }
            public int getfeathers()
            {
                return this.feathers;
            }
            public int geteggs()
            {
                return this.eggs;
            }
            public int getmilk()
            {
                return this.milk;
            }
            public int getairborne()
            {
                return this.airborne;
            }
            public int getaquatic()
            {
                return this.feathers;
            }
            public int getpredator()
            {
                return this.predator;
            }
            public int gettoothed()
            {
                return this.toothed;
            }
            public int getbackbone()
            {
                return this.backbone;
            }
            public int getbreathes()
            {
                return this.breathes;
            }
            public int getvenomous()
            {
                return this.venomous;
            }
            public int getfins()
            {
                return this.fins;
            }
            public int gettail()
            {
                return this.tail;
            }
            public int getdomestic()
            {
                return this.domestic;
            }
            public int getcatsize()
            {
                return this.catsize;
            }
            public int getlegs()
            {
                return this.legs;
            }

        };
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public string CreateJson(string jsonAzure)
        {
            string temp = jsonAzure.Substring(23);
            string tempjson = Reverse(temp);
            tempjson = tempjson.Substring(3);
            string jsonString = Reverse(tempjson);

            jsonString = jsonString.Replace("Scored Probabilities for Class \\\"Mammal\\\"", "cLemon");
            jsonString = jsonString.Replace("Scored Probabilities for Class \\\"Bird\\\"", "cLimes");
            jsonString = jsonString.Replace("Scored Probabilities for Class \\\"Reptile\\\"", "cMandarine");
            jsonString = jsonString.Replace("Scored Probabilities for Class \\\"Fish\\\"", "cPlum");
            jsonString = jsonString.Replace("Scored Probabilities for Class \\\"Amphibian\\\"", "cCocos");
            jsonString = jsonString.Replace("Scored Probabilities for Class \\\"Bug\\\"", "cPapaya");
            jsonString = jsonString.Replace("Scored Probabilities for Class \\\"Invertebrate\\\"", "cPeach");
            jsonString = jsonString.Replace("Scored Labels", "score");
            return jsonString;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Animal ziv = new Animal(0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 1, 0, 2);//kokos
            var client = new RestClient("https://ussouthcentral.services.azureml.net/workspaces/c8f8d54293054df997070fac57ee9366/services/da2db6f9f6d947458210709e2da232bb/execute?api-version=2.0&format=swagger");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Postman-Token", "e8414b95-b5c7-4d92-9fa6-16c0c942414d");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Authorization", "Bearer YHYI44U79uvZ1iWWKaTJXVmjBIx3tj5XwsTTCKdRStNQIjsVOZdxKNDwTueGALuddwmIbAQXGMHgE9xhZquCDQ==");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\r\n\"Inputs\": {\r\n\"input1\":\r\n[\r\n{\r\n'hair': \""
                + ziv.gethair() + "\",   \r\n'feathers': \""
                + ziv.getfeathers() + "\",\r\n'eggs': \""
                + ziv.geteggs() + "\",\r\n'milk': \""
                + ziv.getmilk() + "\",\r\n'airborne': \""
                + ziv.getairborne() + "\",\r\n'aquatic': \""
                + ziv.getaquatic() + "\",\r\n'predator': \""
                + ziv.getpredator() + "\",\r\n'toothed': \""
                + ziv.gettoothed() + "\",\r\n'backbone': \""
                + ziv.getbackbone() + "\",\r\n'breathes': \""
                + ziv.getbreathes() + "\",\r\n'venomous': \""
                + ziv.getvenomous() + "\",\r\n'fins': \""
                + ziv.getfins() + "\",\r\n'legs': \""
                + ziv.getlegs() + "\",\r\n'tail': \""
                + ziv.gettail() + "\",\r\n'domestic': \""
                + ziv.getdomestic() + "\",\r\n'catsize': \""
                + ziv.getcatsize() + "\",\r\n}\r\n],\r\n},\r\n\"GlobalParameters\":  {\r\n}\r\n}\r\n", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string ResponseContentString = response.Content.ToString();
            string json = CreateJson(ResponseContentString);
            Animal animal = JsonConvert.DeserializeObject<Animal>(json);
            
            
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
