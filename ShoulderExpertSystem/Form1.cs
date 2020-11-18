using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoulderExpertSystem
{
    public partial class Form1 : Form
    {
        ExpertSystem ES;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Run();
        }

        // The expert system will begin to run 
        // Getting the information from the knowledgebase and then asking the questions to the user
        public void Run()
        {
            // Initialize the object
            ES = new ExpertSystem();
            textBoxQuestion.SelectionLength = 0;
            // Make sure the system loads correctly
            if(ES.InitializeES() == 0)
            {
                this.Text = ES.GetSystemName();
                labelSystemStatus.Text = "Loaded rules.json successfully.";
                labelSystemStatus.ForeColor = System.Drawing.Color.LimeGreen;
                labelSystemName.Text = ES.GetSystemName();
                labelNumOfRules.Text = ES.GetNumberOfRules().ToString();
                textBoxQuestion.Text = ES.GetCurrentQuestion();
                labelRulesFired.Text = ES.GetRulesFired().ToString();
                buttonYes.Enabled = true;
                buttonNo.Enabled = true;
            }
            else
            {
                labelSystemStatus.Text = "Failed to load rules.json.";
                labelSystemStatus.ForeColor = System.Drawing.Color.Red;
                labelSystemName.Text = "Failed to load system name.";
                labelSystemName.ForeColor = System.Drawing.Color.Red;
                labelNumOfRules.Text = "Failed to load system rule count.";
                labelNumOfRules.ForeColor = System.Drawing.Color.Red;
            }
        }


        // User is answering yes to the question being displayed in the UI
        // Program will then provide the diagnosis and self care information to the user
        private void buttonYes_Click(object sender, EventArgs e)
        {
            buttonYes.Enabled = false;
            buttonNo.Enabled = false;
            textBoxDiagnosis.Text = ES.GetDiagnosis();
            textBoxSelfCare.Text = ES.GetSelfCare();
            buttonReset.Enabled = true;
        }

        // User is answering no to the question being displayed in the UI
        // Program will then provide the next question from the knowledgebase to ask the user
        private void buttonNo_Click(object sender, EventArgs e)
        {
            //if(ES.GetRulesFired() != ES.GetNumberOfRules())
            if(ES.GetCurrentRule().NextRuleID != -1)
            {
                ES.NextRule();
                textBoxQuestion.Text = ES.GetCurrentQuestion();
                labelRulesFired.Text = ES.GetRulesFired().ToString();
                labelQuestion.Text = "Question " + ES.GetRulesFired().ToString() + ": ";
            }
            

            // Triggers when the final rule in the knowledgebase has been reached. There are no more questions to be asked
            // Instead provides the user with the "seek proffesional help" general message
            if (ES.GetCurrentRule().NextRuleID == -1)
            {
                buttonYes.Enabled = false;
                buttonNo.Enabled = false;
                buttonReset.Enabled = true;
                textBoxQuestion.Text = ES.GetCurrentQuestion();
                textBoxDiagnosis.Text = ES.GetDiagnosis();
                textBoxSelfCare.Text = ES.GetSelfCare();
                labelRulesFired.Text = ES.GetRulesFired().ToString();
                labelQuestion.Text = "Question " + ES.GetRulesFired().ToString() + ": ";
            }


        }

        // Resets the expert system. Starts from the begining of the knowledgebase and then continues as normal
        private void buttonReset_Click(object sender, EventArgs e)
        {
            ES.Reset();
            labelSystemName.Text = ES.GetSystemName();
            labelNumOfRules.Text = ES.GetNumberOfRules().ToString();
            textBoxQuestion.Text = ES.GetCurrentQuestion();
            textBoxDiagnosis.Text = "";
            textBoxSelfCare.Text = "";
            labelRulesFired.Text = ES.GetRulesFired().ToString();
            buttonReset.Enabled = false;
            buttonYes.Enabled = true;
            buttonNo.Enabled = true;
            labelQuestion.Text = "Question 1: ";
        }
    }
}
