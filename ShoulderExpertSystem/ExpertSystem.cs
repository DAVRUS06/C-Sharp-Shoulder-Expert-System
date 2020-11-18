using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;



namespace ShoulderExpertSystem
{
    public struct ES_Node
    {
        public int RuleID;
        public int NextRuleID;
        public string Question;
        public string Diagnosis;
        public string SelfCare;
    }

    // The ExpertSystem class is the heart of the expert system. It reads the knowledgebase for the information then 
    //    uses that information to help provide the user with a answer to their questions/query.
    class ExpertSystem
    {
        private List<ES_Node> KnowledgeBase;
        private ES_Node CurrentRule;
        private int NumberOfRules;
        private string SystemName;
        private int RulesFired;

        // Returns the number of rules fired
        public int GetRulesFired()
        { return RulesFired; }

        // Returns the system name
        public string GetSystemName()
        { return SystemName; }

        //Returns the number of rules in the system
        public int GetNumberOfRules()
        { return NumberOfRules; }

        // Returns the current Node/Rule
        public ES_Node GetCurrentRule()
        { return CurrentRule; }

        // Returns the question of the current rule
        public string GetCurrentQuestion()
        { return CurrentRule.Question; }

        // Returns the diagnosis of the patient
        public string GetDiagnosis()
        { return CurrentRule.Diagnosis; }

        // Returns the self-care for the diagnosis for the patient
        public string GetSelfCare()
        { return CurrentRule.SelfCare; }

        // Get the Next Rule from the knowledgebase
        public void NextRule()
        {
            CurrentRule = KnowledgeBase.Find(x => x.RuleID == CurrentRule.NextRuleID);
            RulesFired++;
        }

        // Reset the Expert System to start from the beginning
        public void Reset()
        {
            CurrentRule = KnowledgeBase.Find(x => x.RuleID == 1);
            RulesFired = 1;
        }

        // Initializes the Expert System
        public int InitializeES()
        {
            //int test = LoadKnowledgeBase();
            if(LoadKnowledgeBase() == 0)
            {
                CurrentRule = KnowledgeBase.ElementAt(0);
                RulesFired = 1;
                return 0;
            }
            else
            {
                // Initialization failed return -1
                return -1;
            }
        }

        // Load the KnowledgeBase
        public int LoadKnowledgeBase()
        {
            try
            {
                KnowledgeBase = new List<ES_Node>();
                SystemName = "";
                string path = Directory.GetCurrentDirectory() + @"\rules.json";
                string JSON_text = System.IO.File.ReadAllText(path);

                JObject o = JObject.Parse(JSON_text);
                NumberOfRules = (int)o["numberofrules"];
                SystemName = (string)o["systemname"];
                
                ES_Node temp;
                // Get each rule from the JSON data
                for (int i = 0; i < NumberOfRules; i++)
                {
                    temp.RuleID = (int)o["rules"][i]["ruleid"];
                    temp.NextRuleID = (int)o["rules"][i]["nextruleid"];
                    temp.Question = (string)o["rules"][i]["question"];
                    temp.Diagnosis = (string)o["rules"][i]["diagnosis"];
                    temp.SelfCare = (string)o["rules"][i]["selfcare"];
                    // Add the rule variable into the list
                    KnowledgeBase.Add(temp);
                }
            }
            catch (Exception e)
            {
                // Something failed in the try block so return -1 for failure
                return -1;
            }

            // knowledgebase is empty so return failure
            if (KnowledgeBase.Count == 0)
                return -1;

            // If succeeded then return 0;
            return 0;
        }
    }
}
