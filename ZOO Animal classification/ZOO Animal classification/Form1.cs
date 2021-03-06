﻿using System;
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
            this.BackgroundImage = Properties.Resources.image;
            InitializeComponent();
        }
        public class Animal
        {
            private int hair, feathers, eggs, milk, airborne, aquatic, predator, toothed, backbone, breathes, venomous, fins, tail, domestic, catsize;
            private int legs;
            public string resMammal;
            public string resBird;
            public string resReptile;
            public string resFish;
            public string resAmphibian;
            public string resBug;
            public string resInvertebrate;
            Random rnd = new Random();
            public Animal()//defaultni konstruktor
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

            jsonString = jsonString.Replace("Scored Probabilities for Class \\\"Mammal\\\"", "resMammal");
            jsonString = jsonString.Replace("Scored Probabilities for Class \\\"Bird\\\"", "resBird");
            jsonString = jsonString.Replace("Scored Probabilities for Class \\\"Reptile\\\"", "resReptile");
            jsonString = jsonString.Replace("Scored Probabilities for Class \\\"Fish\\\"", "resFish");
            jsonString = jsonString.Replace("Scored Probabilities for Class \\\"Amphibian\\\"", "resAmphibian");
            jsonString = jsonString.Replace("Scored Probabilities for Class \\\"Bug\\\"", "resBug");
            jsonString = jsonString.Replace("Scored Probabilities for Class \\\"Invertebrate\\\"", "resInvertebrate");
            jsonString = jsonString.Replace("Scored Labels", "score");
            return jsonString;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Animal ziv = new Animal();//kokos
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
            string json = CreateJson(ResponseContentString);
            Animal animal = JsonConvert.DeserializeObject<Animal>(json);
            richTextBox2.Text = ResponseContentString;
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
            richTextBox2.Text = ResponseContentString;
            ReadValues(GeneratedAnimal);
        }
    }
}
