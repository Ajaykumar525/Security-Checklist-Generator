using SSAFE.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSAFE.Infrastructure
{
    public class ResetChecklist
    {
        public static List<Planning> ResetPlanning()
        {
            List<Planning> Checklist = new List<Planning>
            {
                new Planning { Planning_ID = 1, Planning_Value = "Knowledge transfer of security requirements with the product owner", Planning_IsChecked = false },
                new Planning { Planning_ID = 2, Planning_Value = "Security stories elicitation from the product owner", Planning_IsChecked = false },
                new Planning { Planning_ID = 3, Planning_Value = "Additional security requirements recommendations by cyber security specialist", Planning_IsChecked = false },
                new Planning { Planning_ID = 4, Planning_Value = "Identify authentication and authorization requirements from user side", Planning_IsChecked = false },
                new Planning { Planning_ID = 5, Planning_Value = "Determine necessity and implementation of cryptography in the application", Planning_IsChecked = false }
            };

            return Checklist;
        }

        public static List<Analysis> ResetAnalysis()
        {
            List<Analysis> Checklist = new List<Analysis>
            {
                new Analysis { Analysis_ID = 1, Analysis_Value = "Conduct and analyze the feasibility study of all security requirements identified in planning phase", Analysis_IsChecked = false },
                new Analysis { Analysis_ID = 2, Analysis_Value = "Create a process and data flow diagram of the application", Analysis_IsChecked = false },
                new Analysis { Analysis_ID = 3, Analysis_Value = "On based of the diagrams, conduct a complete threat modelling of the application", Analysis_IsChecked = false },
                new Analysis { Analysis_ID = 4, Analysis_Value = "Identify potential threats outlined by threat modelling", Analysis_IsChecked = false },
                new Analysis { Analysis_ID = 5, Analysis_Value = "Discuss and negotiate the results with the product owner", Analysis_IsChecked = false },
                new Analysis { Analysis_ID = 6, Analysis_Value = "Identify potential threats outlined by threat modelling", Analysis_IsChecked = false },
                new Analysis { Analysis_ID = 7, Analysis_Value = "Find solutions so that threats are minimized and software design becomes more secure and efficient", Analysis_IsChecked = false },
                new Analysis { Analysis_ID = 8, Analysis_Value = "Conduct threat modelling second time to make sure threats are eliminated from the analysis phase", Analysis_IsChecked = false }
            };

            return Checklist;
        }

        public static List<Design> ResetDesign()
        {
            List<Design> Checklist = new List<Design>
            {
                new Design { Design_ID = 1, Design_Value = "Create a mind map of all the inputs to be taken from user", Design_IsChecked = false },
                new Design { Design_ID = 2, Design_Value = "Determine effecient input type(e.g dropbox) for every input to avoid rubbish data into database", Design_IsChecked = false },
                new Design { Design_ID = 3, Design_Value = "Enlist client side input validation requirements", Design_IsChecked = false },
                new Design { Design_ID = 4, Design_Value = "Enlist server side input validation requirements", Design_IsChecked = false },
                new Design { Design_ID = 5, Design_Value = "Determine secure protocols and other encryption requirements for secure means of communication", Design_IsChecked = false }
            };

            return Checklist;
        }

        public static List<Development> ResetDevelopment()
        {
            List<Development> Checklist = new List<Development>
            {
                new Development { Development_ID = 1, Development_Value = "Perform knowledge transfer (KT) of all security requirements identified to developing team", Development_IsChecked = false },
                new Development { Development_ID = 2, Development_Value = "If necessary, arrange cybersecurity lessons for the development team", Development_IsChecked = false },
                new Development { Development_ID = 3, Development_Value = "Ensure secure session management and use of CSRF token", Development_IsChecked = false },
                new Development { Development_ID = 4, Development_Value = "Override the runtime errors & exceptions using seperate error pages to hide sensitive information", Development_IsChecked = false },
                new Development { Development_ID = 5, Development_Value = "Sanitize the input data to avoid any malicious script to be executed on your server", Development_IsChecked = false },
                new Development { Development_ID = 6, Development_Value = "Keep the code loosely coupled so that maintenance and testing becomes easy", Development_IsChecked = false },
                new Development { Development_ID = 7, Development_Value = "To ensure added security, enforce pair programming with a pair mix of development & cybersecurity skills", Development_IsChecked = false }
            };

            return Checklist;
        }

        public static List<Testing_Integration> ResetTesting_Integration()
        {
            List<Testing_Integration> Checklist = new List<Testing_Integration>
            {
                new Testing_Integration { Testing_Integration_ID = 1, Testing_Integration_Value = "Prepare relevant security testing tools for the application i.e., SAST, DAST, etc.", Testing_Integration_IsChecked = false },
                new Testing_Integration { Testing_Integration_ID = 2, Testing_Integration_Value = "Try to break authentication & authorization using various techniques", Testing_Integration_IsChecked = false },
                new Testing_Integration { Testing_Integration_ID = 3, Testing_Integration_Value = "Identify input validation flaws and exploit them", Testing_Integration_IsChecked = false },
                new Testing_Integration { Testing_Integration_ID = 4, Testing_Integration_Value = "Perform SQL Injection to ensure database security", Testing_Integration_IsChecked = false },
                new Testing_Integration { Testing_Integration_ID = 5, Testing_Integration_Value = "Test the tolerance against Brute-Force attacks", Testing_Integration_IsChecked = false },
                new Testing_Integration { Testing_Integration_ID = 6, Testing_Integration_Value = "Execute Cross Site Scripting (XSS) attacks and verify same origin policy", Testing_Integration_IsChecked = false },
                new Testing_Integration { Testing_Integration_ID = 7, Testing_Integration_Value = "Challenge session management against various techniques and scenarios", Testing_Integration_IsChecked = false }
            };

            return Checklist;
        }

        public static List<Deployment> ResetDeployment()
        {
            List<Deployment> Checklist = new List<Deployment>
            {
                new Deployment { Deployment_ID = 1, Deployment_Value = "Determine a secure and reliable deployment server & database", Deployment_IsChecked = false },
                new Deployment { Deployment_ID = 2, Deployment_Value = "Keep a log of all events, erros & exceptions i.e., authentication, authorization, etc.", Deployment_IsChecked = false },
                new Deployment { Deployment_ID = 3, Deployment_Value = "Release periodical security patches of the application", Deployment_IsChecked = false },
                new Deployment { Deployment_ID = 4, Deployment_Value = "Receive feedback from the users regarding any potential necessary changes", Deployment_IsChecked = false }
            };
            return Checklist;
        }
    }
}