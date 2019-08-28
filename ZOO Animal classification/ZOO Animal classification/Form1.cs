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
using System.Globalization;

namespace ZOO_Animal_classification
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.BackgroundImage = Properties.Resources.pozadina;
            InitializeComponent();
        }
        public class Animal
        {
            private int hair, feathers, eggs, milk, airborne, aquatic, predator, toothed, backbone, breathes, venomous, fins, tail, domestic, catsize;
            private int legs;
            public string probabilityMammal;
            public string probabilityBird;
            public string probabilityReptile;
            public string probabilityFish;
            public string probabilityAmphibian;
            public string probabilityBug;
            public string probabilityInvertebrate;
            public string score;
            Random rnd = new Random();
            public Animal()//defaultni konstruktor
                {
                hair= 0;
                feathers = 0;
                eggs = 1;
                milk = 0;
                airborne = 0;
                aquatic = 1;
                predator = 1;
                toothed = 0;
                backbone = 0;
                breathes = 0;
                venomous = 0;
                fins = 0;
                tail = 0;
                domestic = 0;
                catsize = 0;
                legs = 4;
                }
            public Animal(int Hair,int Feathers, int Eggs,int Milk,int Airborne,int Aquatic,int Predator,int Toothed,int Backbone,int Breathes,int Venomous,int Fins,int Tail,int Domestic,int Catsize, int Legs )//paramatarski konstruktor
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
            public int GetHair()
            {
                return this.hair;
            }
            public int GetFeathers()
            {
                return this.feathers;
            }
            public int GetEggs()
            {
                return this.eggs;
            }
            public int GetMilk()
            {
                return this.milk;
            }
            public int GetAirborne()
            {
                return this.airborne;
            }
            public int GetAquatic()
            {
                return this.feathers;
            }
            public int GetPredator()
            {
                return this.predator;
            }
            public int GetToothed()
            {
                return this.toothed;
            }
            public int GetBackbone()
            {
                return this.backbone;
            }
            public int GetBreathes()
            {
                return this.breathes;
            }
            public int GetVenomous()
            {
                return this.venomous;
            }
            public int GetFins()
            {
                return this.fins;
            }
            public int GetTail()
            {
                return this.tail;
            }
            public int GetDomestic()
            {
                return this.domestic;
            }
            public int GetCatsize()
            {
                return this.catsize;
            }
            public int GetLegs()
            {
                return this.legs;
            }
            public void SetHair()
            {
                this.hair=rnd.Next(0,2);
            }
            public void SetFeathers()
            {
                this.feathers=rnd.Next(0,2);
            }
            public void SetEggs()
            {
                this.eggs=rnd.Next(0,2);
            }
            public void SetMilk()
            {
                this.milk= rnd.Next(0, 2);
            }
            public void SetAirborne()
            {
                this.airborne= rnd.Next(0, 2);
            }
            public void SetAquatic()
            {
               this.aquatic= rnd.Next(0, 2);
            }
            public void SetPredator()
            {
                this.predator= rnd.Next(0, 2);
            }
            public void SetToothed()
            {
                this.toothed= rnd.Next(0, 2);
            }
            public void SetBackbone()//kičma
            {
                this.backbone= rnd.Next(0, 2);
            }
            public void SetBreathes()
            {
                this.breathes= rnd.Next(0, 2);
            }
            public void SetVenomous()
            {
                this.venomous= rnd.Next(0, 2);
            }
            public void SetFins()
            {
               this.fins= rnd.Next(0, 2);
            }
            public void SetTail()
            {
               this.tail= rnd.Next(0, 2);
            }
            public void SetDomestic()
            {
               this.domestic= rnd.Next(0, 2);
            }
            public void SetCatsize()
            {
               this.catsize= rnd.Next(0, 2);
            }
            public void SetLegs()
            {
               this.legs= rnd.Next(0, 9);
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

            jsonString = jsonString.Replace("Scored Probabilities for Class \\\"1\\\"", "probabilityMammal");
            jsonString = jsonString.Replace("Scored Probabilities for Class \\\"2\\\"", "probabilityBird");
            jsonString = jsonString.Replace("Scored Probabilities for Class \\\"3\\\"", "probabilityReptile");
            jsonString = jsonString.Replace("Scored Probabilities for Class \\\"4\\\"", "probabilityFish");
            jsonString = jsonString.Replace("Scored Probabilities for Class \\\"5\\\"", "probabilityAmphibian");
            jsonString = jsonString.Replace("Scored Probabilities for Class \\\"6\\\"", "probabilityBug");
            jsonString = jsonString.Replace("Scored Probabilities for Class \\\"7\\\"", "probabilityInvertebrate");
            jsonString = jsonString.Replace("Scored Labels", "score");
            return jsonString;
        }
        public void Enumerate(string score)
        {
            if (score == "1")
            {
                textBox24.Text = "Mammal";
            }
            else if (score == "2")
            {
                textBox24.Text = "Bird";
            }
            else if (score == "3")
            {
                textBox24.Text = "Reptile";
            }
            else if (score == "4")
            {
                textBox24.Text = "Fish";
            }
            else if (score == "5")
            {
                textBox24.Text = "Amphibian";
            }
            else if (score == "6")
            {
                textBox24.Text = "Bug";
            }
            else if (score == "7")
            {
                textBox24.Text = "Invertebrate";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Animal ziv = new Animal();//crab
            var client = new RestClient("https://ussouthcentral.services.azureml.net/workspaces/c8f8d54293054df997070fac57ee9366/services/da2db6f9f6d947458210709e2da232bb/execute?api-version=2.0&format=swagger");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Postman-Token", "e8414b95-b5c7-4d92-9fa6-16c0c942414d");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Authorization", "Bearer YHYI44U79uvZ1iWWKaTJXVmjBIx3tj5XwsTTCKdRStNQIjsVOZdxKNDwTueGALuddwmIbAQXGMHgE9xhZquCDQ==");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\r\n\"Inputs\": {\r\n\"input1\":\r\n[\r\n{\r\n'hair': \""
                + ziv.GetHair() + "\",   \r\n'feathers': \""
                + ziv.GetFeathers() + "\",\r\n'eggs': \""
                + ziv.GetEggs() + "\",\r\n'milk': \""
                + ziv.GetMilk() + "\",\r\n'airborne': \""
                + ziv.GetAirborne() + "\",\r\n'aquatic': \""
                + ziv.GetAquatic() + "\",\r\n'predator': \""
                + ziv.GetPredator() + "\",\r\n'toothed': \""
                + ziv.GetToothed() + "\",\r\n'backbone': \""
                + ziv.GetBackbone() + "\",\r\n'breathes': \""
                + ziv.GetBreathes() + "\",\r\n'venomous': \""
                + ziv.GetVenomous() + "\",\r\n'fins': \""
                + ziv.GetFins() + "\",\r\n'legs': \""
                + ziv.GetLegs() + "\",\r\n'tail': \""
                + ziv.GetTail() + "\",\r\n'domestic': \""
                + ziv.GetDomestic() + "\",\r\n'catsize': \""
                + ziv.GetCatsize() + "\",\r\n}\r\n],\r\n},\r\n\"GlobalParameters\":  {\r\n}\r\n}\r\n", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string ResponseContentString = response.Content.ToString();
            string json = CreateJson(response.Content);
            var animal = JsonConvert.DeserializeObject<Animal>(json);
            richTextBox2.Text = json;
            Display(animal);
            ReadValues(ziv);
        }

        public Animal GenerateAnimal() {
            Animal animal = new Animal();
            animal.SetHair();
            animal.SetFeathers();
            animal.SetEggs();
            animal.SetMilk();
            animal.SetAirborne();
            animal.SetAquatic();
            animal.SetPredator();
            animal.SetToothed();
            animal.SetBackbone();
            animal.SetBreathes();
            animal.SetVenomous();
            animal.SetFins();
            animal.SetLegs();
            animal.SetTail();
            animal.SetDomestic();
            animal.SetCatsize();
            return animal;
        }

        public void ReadValues(Animal animal) {
            textBox1.Text = (animal.GetHair()).ToString();
            textBox2.Text = (animal.GetFeathers()).ToString();
            textBox3.Text = (animal.GetEggs()).ToString();
            textBox4.Text = (animal.GetMilk()).ToString();
            textBox16.Text = (animal.GetAirborne()).ToString();
            textBox5.Text = (animal.GetAquatic()).ToString();
            textBox6.Text = (animal.GetPredator()).ToString();
            textBox7.Text = (animal.GetToothed()).ToString();
            textBox8.Text = (animal.GetBackbone()).ToString();
            textBox9.Text = (animal.GetBreathes()).ToString();
            textBox10.Text = (animal.GetVenomous()).ToString();
            textBox11.Text = (animal.GetFins()).ToString();
            textBox12.Text = (animal.GetLegs()).ToString();
            textBox13.Text = (animal.GetTail()).ToString();
            textBox14.Text = (animal.GetDomestic()).ToString();
            textBox15.Text = (animal.GetCatsize()).ToString();
        }
        

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Animal GeneratedAnimal = GenerateAnimal();
            var client = new RestClient("https://ussouthcentral.services.azureml.net/workspaces/c8f8d54293054df997070fac57ee9366/services/da2db6f9f6d947458210709e2da232bb/execute?api-version=2.0&format=swagger");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Postman-Token", "e8414b95-b5c7-4d92-9fa6-16c0c942414d");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Authorization", "Bearer YHYI44U79uvZ1iWWKaTJXVmjBIx3tj5XwsTTCKdRStNQIjsVOZdxKNDwTueGALuddwmIbAQXGMHgE9xhZquCDQ==");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\r\n\"Inputs\": {\r\n\"input1\":\r\n[\r\n{\r\n'hair': \""
                + GeneratedAnimal.GetHair() + "\",   \r\n'feathers': \""
                + GeneratedAnimal.GetFeathers() + "\",\r\n'eggs': \""
                + GeneratedAnimal.GetEggs() + "\",\r\n'milk': \""
                + GeneratedAnimal.GetMilk() + "\",\r\n'airborne': \""
                + GeneratedAnimal.GetAirborne() + "\",\r\n'aquatic': \""
                + GeneratedAnimal.GetAquatic() + "\",\r\n'predator': \""
                + GeneratedAnimal.GetPredator() + "\",\r\n'toothed': \""
                + GeneratedAnimal.GetToothed() + "\",\r\n'backbone': \""
                + GeneratedAnimal.GetBackbone() + "\",\r\n'breathes': \""
                + GeneratedAnimal.GetBreathes() + "\",\r\n'venomous': \""
                + GeneratedAnimal.GetVenomous() + "\",\r\n'fins': \""
                + GeneratedAnimal.GetFins() + "\",\r\n'legs': \""
                + GeneratedAnimal.GetLegs() + "\",\r\n'tail': \""
                + GeneratedAnimal.GetTail() + "\",\r\n'domestic': \""
                + GeneratedAnimal.GetDomestic() + "\",\r\n'catsize': \""
                + GeneratedAnimal.GetCatsize() + "\",\r\n}\r\n],\r\n},\r\n\"GlobalParameters\":  {\r\n}\r\n}\r\n", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string ResponseContentString = response.Content.ToString();
            string json = CreateJson(ResponseContentString);
            Animal animal = JsonConvert.DeserializeObject<Animal>(json);
            richTextBox2.Text = json;
            Display(animal);
            ReadValues(GeneratedAnimal);
        }

        private void button4_Click(object sender, EventArgs e)//see existing classes
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
        private void Display(Animal animal)
        {
            textBox17.Text = animal.probabilityMammal.ToString();
            textBox18.Text = animal.probabilityBird.ToString();
            textBox19.Text = animal.probabilityReptile.ToString();
            textBox20.Text = animal.probabilityFish.ToString();
            textBox21.Text = animal.probabilityAmphibian.ToString();
            textBox22.Text = animal.probabilityBug.ToString();
            textBox23.Text = animal.probabilityInvertebrate.ToString();
            Enumerate(animal.score);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((int.Parse(textBox1.Text) != 0 && int.Parse(textBox1.Text) != 1) || (int.Parse(textBox2.Text) != 0 && int.Parse(textBox2.Text) != 1) || (int.Parse(textBox3.Text) != 0 && int.Parse(textBox3.Text) != 1) || (int.Parse(textBox4.Text) != 0 && int.Parse(textBox4.Text) != 1) || (int.Parse(textBox16.Text) != 0 && int.Parse(textBox16.Text) != 1) || (int.Parse(textBox5.Text) != 0 && int.Parse(textBox5.Text) != 1) || (int.Parse(textBox6.Text) != 0 && int.Parse(textBox6.Text) != 1) || (int.Parse(textBox7.Text) != 0 && int.Parse(textBox7.Text) != 1) || (int.Parse(textBox8.Text) != 0 && int.Parse(textBox8.Text) != 1) || (int.Parse(textBox9.Text) != 0 && int.Parse(textBox9.Text) != 1) || (int.Parse(textBox10.Text) != 0 && int.Parse(textBox10.Text) != 1) || (int.Parse(textBox11.Text) != 0 && int.Parse(textBox11.Text) != 1) || (int.Parse(textBox13.Text) != 0 && int.Parse(textBox13.Text) != 1) || (int.Parse(textBox14.Text) != 0 && int.Parse(textBox14.Text) != 1) || (int.Parse(textBox15.Text) != 0 && int.Parse(textBox15.Text) != 1) || (int.Parse(textBox12.Text)!=0 && int.Parse(textBox12.Text) != 2 && int.Parse(textBox12.Text) != 4 && int.Parse(textBox12.Text) != 8))
            {
                MessageBox.Show("Invalid input, all features are allowed be 0 or 1, and legs are allowed to be 0, 2, 4 or 8. Please check your input and click 'Check Probabilities' button again, or see the instructions by clicking 'How to Use' button.");
                textBox1.Text = "0";
                textBox2.Text = "0";
                textBox3.Text = "1";
                textBox4.Text = "0";
                textBox16.Text = "0";
                textBox5.Text = "0";
                textBox6.Text = "1";
                textBox7.Text = "1";
                textBox8.Text = "0";
                textBox9.Text = "0";
                textBox10.Text = "0";
                textBox11.Text = "0";
                textBox12.Text = "4";
                textBox13.Text = "0";
                textBox14.Text = "0";
                textBox15.Text = "0";
            }
            else { 
            Animal animal = new Animal(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text), int.Parse(textBox16.Text), int.Parse(textBox5.Text), int.Parse(textBox6.Text), int.Parse(textBox7.Text), int.Parse(textBox8.Text), int.Parse(textBox9.Text), int.Parse(textBox10.Text), int.Parse(textBox11.Text), int.Parse(textBox13.Text), int.Parse(textBox14.Text), int.Parse(textBox15.Text), int.Parse(textBox12.Text));
            var client = new RestClient("https://ussouthcentral.services.azureml.net/workspaces/c8f8d54293054df997070fac57ee9366/services/da2db6f9f6d947458210709e2da232bb/execute?api-version=2.0&format=swagger");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Postman-Token", "e8414b95-b5c7-4d92-9fa6-16c0c942414d");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Authorization", "Bearer YHYI44U79uvZ1iWWKaTJXVmjBIx3tj5XwsTTCKdRStNQIjsVOZdxKNDwTueGALuddwmIbAQXGMHgE9xhZquCDQ==");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\r\n\"Inputs\": {\r\n\"input1\":\r\n[\r\n{\r\n'hair': \""
                + animal.GetHair() + "\",   \r\n'feathers': \""
                + animal.GetFeathers() + "\",\r\n'eggs': \""
                + animal.GetEggs() + "\",\r\n'milk': \""
                + animal.GetMilk() + "\",\r\n'airborne': \""
                + animal.GetAirborne() + "\",\r\n'aquatic': \""
                + animal.GetAquatic() + "\",\r\n'predator': \""
                + animal.GetPredator() + "\",\r\n'toothed': \""
                + animal.GetToothed() + "\",\r\n'backbone': \""
                + animal.GetBackbone() + "\",\r\n'breathes': \""
                + animal.GetBreathes() + "\",\r\n'venomous': \""
                + animal.GetVenomous() + "\",\r\n'fins': \""
                + animal.GetFins() + "\",\r\n'legs': \""
                + animal.GetLegs() + "\",\r\n'tail': \""
                + animal.GetTail() + "\",\r\n'domestic': \""
                + animal.GetDomestic() + "\",\r\n'catsize': \""
                + animal.GetCatsize() + "\",\r\n}\r\n],\r\n},\r\n\"GlobalParameters\":  {\r\n}\r\n}\r\n", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string ResponseContentString = response.Content.ToString();
            string json = CreateJson(ResponseContentString);
            Animal animaldeserialized = JsonConvert.DeserializeObject<Animal>(json);
            richTextBox2.Text = json;
            Display(animaldeserialized);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.Show();
        }
    }
}
